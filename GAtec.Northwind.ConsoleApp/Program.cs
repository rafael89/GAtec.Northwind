using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Northwind.Data;
using GAtec.Northwind.Business;
using GAtec.Northwind.Domain.Model;
using GAtec.Northwind.Util;

namespace GAtec.Northwind.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NorthwindSettings.ApplicationName);

            // Define a instance of ICategoryRepository
            var categoryRepository = new CategoryRepository();

            // Define a service and inject (manually) the dependency from ICategoryRepository
            var categoryService = new CategoryService(categoryRepository);

            // create a new category
            var category = new Category
            {
                Name = "Instruments",
                Description = "Musical instruments"
            };

            // call the Add method from category service
            categoryService.Add(category);
        }
    }
}
