using System;
using System.Data.Entity;

namespace DAL.Models
{
    public class DataContexts : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoriess { get; set; }

        public DbSet<CategoryLists> CategoriesLists { get; set; }

        public DbSet<Logins> Logins { get; set; }

        public string cs = "Data Source=DESKTOP-NEJ1R7D;initial Catalog = SQLPractice;integrated security = true;";

        public bool UserLogins(Logins lo)
        {
            throw new NotImplementedException();
        }
    }
}
