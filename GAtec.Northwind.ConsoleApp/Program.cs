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
            //Print the name in app.config
            //Console.WriteLine(NorthwindSettings.ApplicationName);

            // Define a instance of ICategoryRepository
            var categoryRepository = new CategoryRepository();

            // Define a service and inject (manually) the dependency from ICategoryRepository
            var categoryService = new CategoryService(categoryRepository);

            void ShowMainMenu()
            {
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("------" + NorthwindSettings.ApplicationName + "------");
                Console.WriteLine("-----------------------------");

                Console.WriteLine(" 0 - Exit");
                Console.WriteLine(" 1 - Create Category");
                Console.WriteLine(" 2 - Update Category");
                Console.WriteLine(" 3 - Delete Category");
                Console.WriteLine(" 4 - Select Category");
                Console.WriteLine(" 5 - List all categories");
            }

            int option;
            do
            {
                ShowMainMenu();

                Console.Write("\nType a option: ");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        Console.Clear();

                        // create a new category
                        Console.Write("Type a name for a category, like 'Instruments': ");
                        var nameCategory = Console.ReadLine();

                        Console.Write("Type a description for a category, like 'Musical instruments': ");
                        var descriptionCategory = Console.ReadLine();

                        var category = new Category
                        {
                            Name = nameCategory,
                            Description = descriptionCategory
                        };

                        // call the Add method from category service
                        categoryService.Add(category);

                        if (categoryService.Validation.Any())
                        {
                            foreach (var item in categoryService.Validation)
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                        }

                        break;

                    case 2:

                        Console.Clear();

                        // update a exists category
                        Console.Write("Type a valid id for update: ");
                        var idCategoryUpdate = int.Parse(Console.ReadLine());

                        Console.Write("Type a name for Update: ");
                        var nameCategoryUpdate = Console.ReadLine();

                        Console.Write("Type a description for Update: ");
                        var descriptionCategoryUpdate = Console.ReadLine();

                        var categoryUpdate = new Category
                        {
                            Id = idCategoryUpdate,
                            Name = nameCategoryUpdate,
                            Description = descriptionCategoryUpdate
                        };

                        categoryService.Update(categoryUpdate);


                        break;

                    case 3:

                        Console.Clear();

                        Console.Write("Type a valid id for delete: ");

                        var idDelete = int.Parse(Console.ReadLine());

                        categoryService.Delete(idDelete);

                        break;

                    case 4:

                        Console.Clear();

                        Console.Write("Type a valid id for select: ");

                        var idSelect = int.Parse(Console.ReadLine());

                        var select = categoryService.GetCategory(idSelect);

                        Console.WriteLine($"{select.Id} - {select.Name} - {select.Description}");

                        Console.ReadLine();

                        break;

                    case 5:

                        Console.Clear();

                        var categories = categoryService.GetCategories();
                        foreach (var c in categories)
                        {
                            Console.WriteLine($"{c.Id} - {c.Name} - {c.Description}");
                        }

                        Console.ReadLine();

                        break;
                }

            } while (option != 0);

        }
    }
}