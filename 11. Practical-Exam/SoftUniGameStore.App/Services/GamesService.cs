namespace SoftUniGameStore.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Models;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class GamesService : Service
    {
        public List<AdminGameViewModel> RetrieveAllGames()
        {
            List<AdminGameViewModel> games = this.GameRepository
                .All()
                .Select(g => new AdminGameViewModel()
                {
                    Id = g.Id,
                    Name = g.Title,
                    Price = g.Price,
                    Size = g.Size
                }).ToList();

            return games;
        }

        public void AddGame(GameBindingModel agbm)
        {
            Game gameEntity = Mapper.Map<Game>(agbm);
            this.GameRepository.Insert(gameEntity);
            this.SaveChanges();
        }

        public void EditGame(int id, GameBindingModel agbm)
        {
            Game gameEntity = this.GameRepository.Find(id);
            gameEntity.Title = agbm.Title;
            gameEntity.Description = agbm.Description;
            gameEntity.ImageThumbnail = agbm.ImageThumbnail;
            gameEntity.Price = agbm.Price;
            gameEntity.Size = agbm.Size;
            gameEntity.Trailer = agbm.Trailer;
            gameEntity.ReleaseDate = DateTime.Parse(agbm.ReleaseDate);
            this.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            Game gameEntity = this.GameRepository.Find(id);
            this.GameRepository.Delete(gameEntity);
            this.SaveChanges();
        }

        public EditGameViewModel CreateEditGameViewModel(int id)
        {
            Game gameEntity = this.GameRepository.Find(id);
            EditGameViewModel egvm = Mapper.Map<EditGameViewModel>(gameEntity);
            return egvm;
        }

        public GameDetailsViewModel CreateGameDetailsViewModel(int id, HttpSession session)
        {
            Game gameEntity = this.GameRepository.Find(id);
            GameDetailsViewModel gdvm = Mapper.Map<GameDetailsViewModel>(gameEntity);
            gdvm.IsLogged = base.IsAuthenticated(session);
            if (gdvm.IsLogged)
            {
                gdvm.IsAdmin = base.IsAdmin();
            }

            return gdvm;
        }
    }
}
