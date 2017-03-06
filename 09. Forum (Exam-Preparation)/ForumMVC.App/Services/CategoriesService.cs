namespace ForumMVC.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Models;
    using ViewModels;

    public class CategoriesService : Service
    {
        public List<CategoryViewModel> RetrieveAll()
        {
            User currentlyLogged = this.LoginRepository.RetrieveCurrentlyLogged();

            return this.CategoryRepository.All().Select(category => new CategoryViewModel()
            {
                Id = category.Id,
                CategoryName = category.Name,
            }).ToList();
        }

        public bool CreateCategory(CreateCategoryBindingModel ccbm)
        {
            Category existingCategory = this.CategoryRepository
                .Find(c => c.Name == ccbm.CategoryName);

            if (existingCategory == null)
            {
                Category categoryEntity = new Category()
                {
                    Name = ccbm.CategoryName
                };

                this.CategoryRepository.Insert(categoryEntity);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public void EditCategory(int id, string newCategoryName)
        {
            Category categoryEntity = this.CategoryRepository.Find(id);
            categoryEntity.Name = newCategoryName;
            this.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category categoryEntity = this.CategoryRepository.Find(id);
            //List<Topic> topics = categoryEntity.Topics.ToList();
            //foreach (var topic in topics)
            //{
            //    List<Reply> replies = topic.Replies.ToList();
            //    foreach (var reply in replies)
            //    {
            //        this.Context.Detach(reply);
                  
            //    }

            //    this.Context.Detach(topic);
            //}

            //this.Context.Detach(categoryEntity);
            this.CategoryRepository.Delete(categoryEntity);
            this.SaveChanges();
        }
    }
}
