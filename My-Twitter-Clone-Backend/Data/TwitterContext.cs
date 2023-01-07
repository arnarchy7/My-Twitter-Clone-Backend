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

        public DbSet<LikedTweet> LikedTweets { get; set; }

        public DbSet<LikedReply> LikedReplies { get; set; }


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
            User u6 = new User { UserId = 6, DisplayName = "Ég", Handle = "UmMigFráMérTilMín", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/User-avatar.svg/2048px-User-avatar.svg.png" };

            modelBuilder.Entity<User>().HasData(u1, u2, u3, u4, u5, u6);
            

            Tweet t1 = new Tweet { Id = 1, UserId = 1, TweetBody = "Hello World", TweetCreated = new DateTime(2022, 12, 10, 19, 30, 00, DateTimeKind.Local), LikeCount = 2, RetweetCount = 1, };
            Tweet t2 = new Tweet { Id = 2, UserId = 4, TweetBody = "Oh Father Where Art Thou?", TweetCreated = new DateTime(2022, 12, 10, 19, 35, 00, DateTimeKind.Local), LikeCount = 1 };
            Tweet t3 = new Tweet { Id = 3, UserId = 5, TweetBody = "Bonjour tout le monde", TweetCreated = new DateTime(2022, 12, 10, 19, 40, 00, DateTimeKind.Local), LikeCount = 1 };
            Tweet t4 = new Tweet { Id = 4, UserId = 3, TweetBody = "Bond, James Bond. Shaken, not stirred.", TweetCreated = new DateTime(2022, 12, 11, 15, 30, 00, DateTimeKind.Local),  };
            Tweet t5 = new Tweet { Id = 5, UserId = 2, TweetBody = "Nei, Pepsi er ekki í lagi. Ég vil Kók!", TweetCreated = new DateTime(2022, 12, 12, 18, 45, 00, DateTimeKind.Local), LikeCount = 23, RetweetCount = 10 };
            Tweet t6 = new Tweet { Id = 6, UserId = 4, TweetBody = "Ég kom alla leið frá Nazareth, labbandi á tánum!", TweetCreated = new DateTime(2022, 12, 24, 18, 00, 00, DateTimeKind.Local), LikeCount = 3, RetweetCount = 1 };
            Tweet t7 = new Tweet { Id = 7, UserId = 1, TweetBody = "Is there life on mars?", TweetCreated = new DateTime(2022, 12, 26, 01, 00, 00, DateTimeKind.Local), LikeCount = 2 };
            Tweet t8 = new Tweet { Id = 8, UserId = 2, TweetBody = "Hvað heitir austfirska íþróttin þar sem menn reyna að fella hvorn annan með kústskafti....Austur-Skaftfellingar", TweetCreated = new DateTime(2022, 12, 27, 20, 00, 00, DateTimeKind.Local), LikeCount = 6, RetweetCount = 2 };
            Tweet t9 = new Tweet { Id = 9, UserId = 6, TweetBody = "💖", TweetCreated = new DateTime(2023, 01, 01, 00, 00, 00, DateTimeKind.Local), LikeCount = 8 };


            modelBuilder.Entity<Tweet>().HasData(t1, t2, t3, t4, t5, t6, t7, t8, t9);

            Reply r1 = new Reply { Id = 1, UserId = 4, Body = "Allo, Allo", CreatedAt = new DateTime(2022, 12, 11, 00, 00, 00, DateTimeKind.Local), LikeCount = 1, TweetId = 3 };
            Reply r2 = new Reply { Id = 2, UserId = 4, Body = "Hi yourself", CreatedAt = new DateTime(2022, 12, 11, 00, 00, 00, DateTimeKind.Local), LikeCount = 1, TweetId = 1 };
            Reply r3 = new Reply { Id = 3, UserId = 6, Body = "So, a watered down martini? ", CreatedAt = new DateTime(2022, 12, 14, 00, 00, 00, DateTimeKind.Local), LikeCount = 2, TweetId = 4 };
            Reply r4 = new Reply { Id = 4, UserId = 6, Body = "Heyr, Heyr!", CreatedAt = new DateTime(2022, 12, 15, 15, 00, 00, DateTimeKind.Local), LikeCount = 1, TweetId = 5 };
            Reply r5 = new Reply { Id = 5, UserId = 2, Body = "Þér er ekki boðið!", CreatedAt = new DateTime(2022, 12, 24, 18, 05, 00, DateTimeKind.Local), LikeCount = 5, TweetId = 6 };
            Reply r6 = new Reply { Id = 6, UserId = 5, Body = "😂", CreatedAt = new DateTime(2022, 12, 27, 20, 05, 00, DateTimeKind.Local), LikeCount = 1, TweetId = 8 };
            Reply r7 = new Reply { Id = 7, UserId = 6, Body = "Haha", CreatedAt = new DateTime(2022, 12, 27, 20, 10, 00, DateTimeKind.Local), LikeCount = 1, TweetId = 8 };

            modelBuilder.Entity<Reply>().HasData(r1, r2, r3, r4, r5, r6, r7 );
            modelBuilder.Entity<Reply>().
                HasOne(x => x.User).WithMany(x => x.Replies).OnDelete(DeleteBehavior.SetNull);

            LikedTweet lt1 = new LikedTweet { Id = 1, TweetId = 1, UserId = 6 };
            LikedTweet lt2 = new LikedTweet { Id = 2, TweetId = 5, UserId = 6 };
            LikedTweet lt3 = new LikedTweet { Id = 3, TweetId = 2, UserId = 6 };
            LikedTweet lt4 = new LikedTweet { Id = 4, TweetId = 3, UserId = 6 };
            LikedTweet lt5 = new LikedTweet { Id = 5, TweetId = 8, UserId = 6 };

            modelBuilder.Entity<LikedTweet>().HasData(lt1, lt2, lt3, lt4, lt5);

            LikedReply lr1 = new LikedReply { Id = 1, ReplyId = 5, UserId = 6 };
            LikedReply lr2 = new LikedReply { Id = 2, ReplyId = 6, UserId = 6 };

            modelBuilder.Entity<LikedReply>().HasData(lr1, lr2); 
        }

       
    }
}
