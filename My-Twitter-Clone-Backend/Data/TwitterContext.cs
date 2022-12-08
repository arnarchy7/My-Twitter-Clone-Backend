using Microsoft.EntityFrameworkCore;
using My_Twitter_Clone_Backend.Models;
using System.Reflection.Metadata;

namespace My_Twitter_Clone_Backend.Data
{
    public class TwitterContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Retweet> Retweets { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Twitter;Trusted_Connection=True");
        }
    }
}
