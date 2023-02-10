using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)//to pass parameters to the base class,which is DbContext, so have to configure the DbContext
        { 
        }
        //have to create category table inside the database that the file are currently working on
        public DbSet<Category> Categories { get; set; }
    }
}
