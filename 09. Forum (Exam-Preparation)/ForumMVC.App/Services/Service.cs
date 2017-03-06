namespace ForumMVC.App.Services
{
    using System;
    using AutoMapper;
    using BindingModels;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Models;
    using ViewModels;

    public abstract class Service
    {
        private readonly IForumContext context;

        protected Service()
            :this(new ForumContext())
        {

        }

        protected Service(IForumContext context)
        {
            this.context = context;
        }

        public UserRepository UsersRepository => new UserRepository(this.context);

        public LoginRepository LoginRepository => new LoginRepository(this.context);

        public TopicRepository TopicRepository => new TopicRepository(this.context);

        public CategoryRepository CategoryRepository => new CategoryRepository(this.context);

        public ReplyRepository ReplyRepository => new ReplyRepository(this.context);


        public IForumContext Context => this.context;

        public int SaveChanges() => this.context.SaveChanges();

        protected void ConfigureAutomapper()
        {
            Mapper.Initialize(action =>
                 action.CreateMap<RegisterUserBindingModel, User>()
            );
        }

        protected void ConfigureAutomapper(Topic topicEntity)
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<Topic, TopicViewModel>()
                    .ForMember(t => t.Category, expression => expression.MapFrom(x => topicEntity.Category.Name))
                    .ForMember(t => t.Author, expression => expression.MapFrom(x => topicEntity.Author.Username))
                    .ForMember(t => t.Replies, expression => expression.MapFrom(x => topicEntity.Replies.Count));
                action.CreateMap<Reply, ReplyViewModel>()
                    .ForMember(r => r.Author, expression => expression.MapFrom(x => x.Topic.Author.Username));
            });
        }
        protected void ConfigureAutomapper(Reply replyEntity)
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<Reply, ReplyViewModel>()
                    .ForMember(r => r.Author, 
                    expression => expression.MapFrom(x => replyEntity.Author.Username))
                    .ForMember(r => r.AuthorId,
                    expression => expression.MapFrom(x => replyEntity.Author.Id));
            });
        }

        protected void ConfigureAutomapper(User currentUser, CreateTopicBindingModel ctbm)
        {
            Mapper.Initialize(action =>
                action.CreateMap<CreateTopicBindingModel, Topic>()
                .ForMember(t => t.Category, expression => expression.MapFrom(x => this.CategoryRepository.Find(c => c.Name == ctbm.CategoryName)))
                .ForMember(t => t.PostedOn, expression => expression.MapFrom(x => DateTime.Now))
                .ForMember(t => t.Author, expression => expression.MapFrom(x => currentUser))
            );
        }
    }
}
