namespace SoftUniGameStore.App
{
    using System;
    using AutoMapper;
    using BindingModels;
    using Models;
    using SimpleHttpServer;
    using SimpleMVC;
    using Utillities.IssueTracker.App.Utillities;
    using ViewModels;

    public class AppStart
    {
        public static void Main(string[] args)
        {
            ConfigureAutomapping();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniGameStore.App");
        }

        public static void ConfigureAutomapping()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<GameBindingModel, Game>()
                    .ForMember(g => g.ReleaseDate, config => config.MapFrom(x => DateTime.Parse(x.ReleaseDate)));
                action.CreateMap<Game, GameHomeViewModel>();
                action.CreateMap<Game, EditGameViewModel>()
                    .ForMember(g => g.ReleaseDate, config => config.MapFrom(x => x.ReleaseDate.ToString("yyyy/MM/dd")));
                action.CreateMap<Game, GameDetailsViewModel>()
                    .ForMember(g => g.ReleaseDate, config => config.MapFrom(x => x.ReleaseDate.ToString("dd/MM/yyyy")));
                action.CreateMap<Game, GameProfileViewModel>()
                   .ForMember(g => g.ReleaseDate, config => config.MapFrom(x => x.ReleaseDate.ToString("dd/MM/yyyy")));
            });
        }
    }
}
