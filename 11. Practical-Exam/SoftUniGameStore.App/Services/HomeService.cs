namespace SoftUniGameStore.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class HomeService : Service
    {
        public List<GameHomeViewModel> RetrieveAllGamesForHome()
        {
            List<GameHomeViewModel> games = this.GameRepository
                .All()
                .Select(g => new GameHomeViewModel()
                {
                    Description = g.Description,
                    Id = g.Id,
                    ImageThumbnail = g.ImageThumbnail,
                    Price = g.Price,
                    Size = g.Size,
                    Title = g.Title
                })
                .ToList();

            return games;
        }

        public bool CartExists(string sessionId)
        {
            Cart existingCart = this.CartRepository.Find(c => c.SessionId == sessionId);

            return existingCart != null;
        }

        public void CreateNewCart(string sessionId)
        {
            Cart cartEntity = new Cart()
            {
                SessionId = sessionId
            };

            this.CartRepository.Insert(cartEntity);
            this.SaveChanges();
        }

        public void AddGameToCart(int id, string sessionId)
        {
            User currentUser = this.SessionRepository.RetrieveCurrentlyLogged();
            Cart existingCart = this.CartRepository.Find(c => c.SessionId == sessionId);
            Game existingGame = this.GameRepository.Find(id);

            if (currentUser != null && currentUser.Games.Any(g => g.Id == existingGame.Id))
            {
                return;
            }

            if (existingCart.Games.All(g => g.Id != existingGame.Id))
            {
                existingCart.Games.Add(existingGame);
                this.SaveChanges();
            }
        }

        public void DeleteFromCart(int id, string sessionId)
        {
            Cart cartEntity = this.CartRepository.Find(c => c.SessionId == sessionId);
            Game gameEntity = this.GameRepository.Find(id);

            cartEntity.Games.Remove(gameEntity);
            this.SaveChanges();
        }

        public List<CartGameViewModel> RetrieveAllGamesForCart(string sessionId)
        {
            Cart existingCart = this.CartRepository.Find(c => c.SessionId == sessionId);

            return existingCart.Games.Select(g => new CartGameViewModel()
            {
                Description = g.Description,
                Id = g.Id,
                ImageThumbnail = g.ImageThumbnail,
                Price = g.Price,
                Title = g.Title
            }).ToList();
        }

        public CartViewModel CreateCartViewModel(HttpSession session)
        {
            IEnumerable<CartGameViewModel> games = this.RetrieveAllGamesForCart(session.Id);
            bool isLogged = this.IsAuthenticated(session);
            bool isAdmin = false;
            if (isLogged)
            {
                isAdmin = this.IsAdmin();
            }

            return new CartViewModel()
            {
                Games = games,
                IsAdmin = isAdmin,
                IsLogged = isLogged,
                TotalPrice = games.Sum(g => g.Price)
            };
        }

        public HomeViewModel CreateHomeViewModel(HttpSession session)
        {
            List<GameHomeViewModel> games = this.RetrieveAllGamesForHome();
            bool isLogged = this.IsAuthenticated(session);
            bool isAdmin = false;
            if (isLogged)
            {
                isAdmin = this.IsAdmin();
            }

            return new HomeViewModel()
            {
                Games = games,
                IsAdmin = isAdmin,
                IsLogged = isLogged
            };
        }

        public void Order(HttpSession session)
        {
            User currentUser = this.SessionRepository.RetrieveCurrentlyLogged();
            Cart currentCart = this.CartRepository.Find(c => c.SessionId == session.Id);
            List<Game> allGamesInCart = currentCart.Games.ToList();
            foreach (Game game in allGamesInCart)
            {
                if (currentUser.Games.All(g => g.Id != game.Id))
                {
                    currentUser.Games.Add(game);
                }
            }

            currentCart.Games.Clear();
            this.SaveChanges();
        }
    }
}
