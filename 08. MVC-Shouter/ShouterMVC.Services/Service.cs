using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouterMVC.Services
{
    using AutoMapper;
    using BindingModels.BindingModels;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Models;
    using Tools;
    using ViewModels;

    public abstract class Service
    {
        private readonly IShouterContext context;

        protected Service()
            : this(new ShouterContext())
        {

        }

        protected Service(IShouterContext context)
        {
            this.context = context;
        }

        protected UserRepository UsersRepository => new UserRepository(this.context);

        protected LoginRepository LoginRepository => new LoginRepository(this.context);

        protected ShoutRepository ShoutRepository => new ShoutRepository(this.context);

        public IShouterContext Context => this.context;

        protected int SaveChanges() => this.context.SaveChanges();

        // Mapping users
        protected void ConfigureMapper(RegisterUserBindingModel rubm)
        {
            Mapper.Initialize(action =>
                action.CreateMap<RegisterUserBindingModel, User>()
                .ForMember(u => u.Birthdate, expression => expression.MapFrom(x => DateTime.Parse(rubm.Birthdate)))
            );
        }

        // Mapping shouts
        protected void ConfigureMapper()
        {
            Mapper.Initialize(action =>
                action.CreateMap<Shout, ShoutViewModel>()
                .ForMember(s => s.RelativeTime,
                expression => expression.MapFrom(x => RelativeTimeCalculator.Calculate(x)))
                .ForMember(s => s.Username, expression => expression.MapFrom(x => x.Shouter.Username))
                );
        }

    }
}
