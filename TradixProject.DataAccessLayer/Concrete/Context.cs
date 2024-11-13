using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradixProject.EntityLayer.Concrete;

namespace TradixProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FATMA\\SQLEXPRESS;initial catalog=TradixProjectDb;integrated Security=true;TrustServerCertificate=True");

        }
        public DbSet<Class1> Class1Entities { get; set; }  // Class1 için DbSet tanımı
    }
}
    

