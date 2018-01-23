using System;
using System.Collections.Generic;
using GAtec.Northwind.Domain.Business;
using GAtec.Northwind.Domain.Model;
using GAtec.Northwind.Domain.Repository;

namespace GAtec.Northwind.Business
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository CategoryRepository { get; set; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("The name is empty.");
            }

            CategoryRepository.Add(category);
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new System.NotImplementedException();
        }
    }
}