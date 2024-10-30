using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DiaryModel> DiaryEntries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaryModel>().HasData(

                   new DiaryModel
                   {
                       Id = 1,
                       Title = "Learning HTML",
                       Content = "How to set Css",
                       Created = DateTime.Now
                   },
        new DiaryModel
        {
            Id = 2,
            Title = "Went Shopping",
            Content = "Went to shopping with Joe",
            Created = DateTime.Now
        }
                                      );
        }
    }
}
