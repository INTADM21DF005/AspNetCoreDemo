using AspCoreWebApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebApp.DB
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            LoadCategoriesAndSubCategories();
        }

        public void LoadCategoriesAndSubCategories()
        {
            if (this.Categories.Any() && this.SubCategories.Any())
            {
                return;
            }
            Categories.AddRange(new List<Category>
            {
                new Category { Id=1, Name = "Category1"},
                new Category { Id=2, Name = "Category2"},
                new Category { Id=3, Name = "Category3"},
                new Category { Id=4, Name = "Category4"},
                new Category { Id=5,Name = "Category5"},
            });
            SubCategories.AddRange(new List<SubCategory>
            {
                new SubCategory { Id =1, Name = "SubCategory1", CategoryId = 1},
                new SubCategory { Id =2, Name = "SubCategory2", CategoryId = 2},
                new SubCategory { Id =3, Name = "SubCategory3", CategoryId = 1},
                new SubCategory { Id =4, Name = "SubCategory4", CategoryId = 3},
                new SubCategory { Id =5, Name = "SubCategory5", CategoryId = 4},
                new SubCategory { Id =6, Name = "SubCategory6", CategoryId = 4}
            });
            
        }

        public List<Category> GetCategories()
        {
            return this.Categories.Local.ToList<Category>();
        }

        public List<SubCategory> GetSubCategories()
        {
            return this.SubCategories.Local.ToList<SubCategory>();
        }
    }
}
