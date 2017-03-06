namespace ForumMVC.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models;
    using ViewModels;

    public class HomeService : Service
    {
        public TopTenTopicsViewModel RetrieveTopTen(bool isLogged)
        {
            var topTenTopics = this.TopicRepository.RetrieveLastTen().ToList();
            TopTenTopicsViewModel vm = new TopTenTopicsViewModel()
            {
                IsLogged = isLogged
            };

            List<TopicViewModel> topicViewModels = new List<TopicViewModel>();

            foreach (var topic in topTenTopics)
            {
                topicViewModels.Add(new TopicViewModel()
                {
                    Id = topic.Id,
                    Title = topic.Title,
                    Author = topic.Author.Username,
                    AuthorId = topic.Author.Id,
                    Category = topic.Category.Name,
                    PostedOn = topic.PostedOn,
                    Replies = topic.Replies.Count,
                });
            }

            vm.Topics = topicViewModels;
            return vm;
        }

        public List<string> GetAllCategories()
        {
            List<string> categories = this.CategoryRepository.All().Select(c => c.Name).ToList();
            return categories;
        }

        public List<TopicViewModel> GetAllTopicsInCategory(string categoryName)
        {
            List<Topic> topicsInCategory = this.TopicRepository
                .All(t => t.Category.Name == categoryName).ToList();
            List<TopicViewModel> vm = new List<TopicViewModel>();

            foreach (var topic in topicsInCategory)
            {
                ConfigureAutomapper(topic);
                vm.Add(Mapper.Map<TopicViewModel>(topic));
            }

            return vm;
        }

    }
}
