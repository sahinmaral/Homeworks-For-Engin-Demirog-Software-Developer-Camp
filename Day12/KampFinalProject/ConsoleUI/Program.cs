﻿using Business.Concrete;

using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest(out var productManager);

            //CategoryTest(out var categoryManager);


        }

        private static void CategoryTest(out CategoryManager categoryManager)
        {
            categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest(out ProductManager productManager)
        {
            productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
