using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBotTelegram
{
    public  class TestDbContext : DbContext
    {
        public TestDbContext() :
            base("TestDbContext")
        {
            Database.SetInitializer<TestDbContext>(new CreateDatabaseIfNotExists<TestDbContext>());
        }

        public DbSet<Products> products { get; set; }
    }
}
