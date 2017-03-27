using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using estore_model;

namespace estore_repository.Migrations
{
    public class SeedLibrary
    {
        private StoreDB _context;

        public SeedLibrary(StoreDB context)
        {
            _context = context;
        }

        public void Category()
        {
            _context.Categories.AddOrUpdate(
              c => c.CategoryId,
              new Category {
                  CategoryId = 1,
                  Name = "Брюки в клеточку",
                  SortOrder = 1
              },
              new Category
              {
                  CategoryId = 2,
                  Name = "Перчатки",
                  SortOrder = 2
              },
              new Category
              {
                  CategoryId = 3,
                  Name = "Рубашки",
                  SortOrder = 3
              },
              new Category
              {
                  CategoryId = 4,
                  Name = "Перчатки",
                  SortOrder = 4
              },
              new Category
              {
                  CategoryId = 5,
                  Name = "Обувь",
                  SortOrder = 5
              },
              new Category
              {
                  CategoryId = 6,
                  Name = "Кроссовки",
                  SortOrder = 1,
                  ParentId = 5
              },
              new Category
              {
                  CategoryId = 7,
                  Name = "Туфли",
                  SortOrder = 2,
                  ParentId = 5
              }
            );

        }
    }
}
