using Microsoft.EntityFrameworkCore;
using My_Twitter_Clone_Backend.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml;

namespace My_Twitter_Clone_Backend.Data
{
    public class TwitterContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Reply> Replies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Twitter;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User u1 = new User { UserId = 1, DisplayName = "John Smith", Handle = "J.Smith", ImageURL = "https://comicvine.gamespot.com/a/uploads/square_medium/8/80111/3259571-john%20smith%207.png" };
            User u2 = new User { UserId = 2, DisplayName = "Jón Jónsson", Handle = "Nonni", ImageURL = "https://www.gunnarf.is/static/gallery/vesturaettarmyndir/sm/crop-jon-olafur-jonsson-2.jpg?v2" };
            User u3 = new User { UserId = 3, DisplayName = "James Bond", Handle = "007", ImageURL = "https://www.classical-guitar-music.com/wp-content/uploads/2017/10/8446295874_91e78074e61.jpg" };
            User u4 = new User { UserId = 4, DisplayName = "Jesus H Christ", Handle = "SonOfGod", ImageURL = "https://i1.sndcdn.com/avatars-000310363975-0nia22-t240x240.jpg" };
            User u5 = new User { UserId = 5, DisplayName = "Joan of Arc", Handle = "BurntWitch", ImageURL = "https://royalarmouries.org/wp-content/uploads/2020/08/1024px-Joan_of_Arc_miniature_graded-e1597418920698-350x350.jpg" };
            User u6 = new User { UserId = 6, DisplayName = "Ég", Handle = "UmMigFráMérTilMín", ImageURL= "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/User-avatar.svg/2048px-User-avatar.svg.png" };

            modelBuilder.Entity<User>().HasData(u1, u2, u3, u4, u5, u6);
            

            Tweet t1 = new Tweet { Id = 1, UserId = 1, TweetBody = "Hello World", TweetCreated = new DateTime(2022, 12, 10, 19, 30, 00, DateTimeKind.Local), LikeCount = 2, RetweetCount = 1, };
            Tweet t2 = new Tweet { Id = 2, UserId = 4, TweetBody = "Hi yourself", TweetCreated = new DateTime(2022, 12, 10, 19, 35, 00, DateTimeKind.Local), };
            Tweet t3 = new Tweet { Id = 3, UserId = 5, TweetBody = "Bonjour tout le monde", TweetCreated = new DateTime(2022, 12, 10, 19, 40, 00, DateTimeKind.Local) };
            Tweet t4 = new Tweet { Id = 4, UserId = 3, TweetBody = "Bond, James Bond. Shaken, not stirred.", TweetCreated = new DateTime(2022, 12, 11, 15, 30, 00, DateTimeKind.Local) };
            Tweet t5 = new Tweet { Id = 5, UserId = 2, TweetBody = "Nei, Pepsi er ekki í lagi. Ég vil Kók!", TweetCreated = new DateTime(2022, 12, 12, 18, 45, 00, DateTimeKind.Local) };

            modelBuilder.Entity<Tweet>().HasData(t1, t2, t3, t4, t5);

            Reply r1 = new Reply { Id = 1, UserId = 4, Body = "Allo, Allo", CreatedAt = new DateTime(2022, 12, 11, 00, 00, 00, DateTimeKind.Local), LikeCount = 1, TweetId = 1 };

            modelBuilder.Entity<Reply>().HasData(r1);
            modelBuilder.Entity<Reply>().
                HasOne(x => x.User).WithMany(x => x.Replies).OnDelete(DeleteBehavior.SetNull);
        }

       
    }
}
