namespace ForumMVC.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity.Validation;
    using AutoMapper;
    using BindingModels;
    using Models;
    using ViewModels;

    public class TopicsService : Service
    {
        public List<string> RetrieveAllCategories()
        {
            return this.CategoryRepository.All().Select(c => c.Name).ToList();
        }

        public void CreateTopic(CreateTopicBindingModel ctbm)
        {
            User currentUser = this.LoginRepository.RetrieveCurrentlyLogged();
            ConfigureAutomapper(currentUser, ctbm);
            try
            {
                Topic topicEntity = Mapper.Map<Topic>(ctbm);
                this.TopicRepository.Insert(topicEntity);
                this.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                // 
            }

        }

        public TopicDetailsViewModel RetreiveTopicDetailsViewModel(int id)
        {
            Topic topicEntity = this.TopicRepository.Find(id);
            ConfigureAutomapper(topicEntity);
            TopicViewModel tvm = Mapper.Map<TopicViewModel>(topicEntity);
            List<ReplyViewModel> rvModels = new List<ReplyViewModel>();
            User currentUser = this.LoginRepository.RetrieveCurrentlyLogged();
            List<Reply> replies = topicEntity.Replies.ToList();
            foreach (Reply replyEntity in replies)
            {
                ConfigureAutomapper(replyEntity);
                rvModels.Add(Mapper.Map<ReplyViewModel>(replyEntity));
            }

            return new TopicDetailsViewModel()
            {
                Topic = tvm,
                ReplyViewModels = rvModels
            };
        }


        public void CreateReply(int id, CreateReplyBindingModel crbm)
        {
            Topic topicEntity = this.TopicRepository.Find(id);
          

            try
            {
                Reply replyEntity = new Reply()
                {
                    Author = this.LoginRepository.RetrieveCurrentlyLogged(),
                    ImageUrl = crbm.ImageUrl,
                    Text = crbm.Text,
                    Topic = topicEntity,
                    PostedOn = DateTime.Now
                };
                this.ReplyRepository.Insert(replyEntity);
                this.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                //
            }

        }

        public int DeleteTopic(int id)
        {
            Topic topicEntity = this.TopicRepository.Find(id);
            //List<Reply> repliesInTopic = topicEntity.Replies.ToList();
            //foreach (Reply reply in repliesInTopic)
            //{
            //    this.Context.Detach(reply);
            //}

            //this.Context.Detach(topicEntity);
            this.TopicRepository.Delete(topicEntity);
            this.SaveChanges();

            return this.LoginRepository.RetrieveCurrentlyLogged().Id;
        }
    }
}
