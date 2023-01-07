﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Twitter_Clone_Backend.Data;

#nullable disable

namespace My_Twitter_Clone_Backend.Migrations
{
    [DbContext(typeof(TwitterContext))]
    [Migration("20230105163250_MoreSeeds")]
    partial class MoreSeeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.LikedReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ReplyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LikedReplies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ReplyId = 5,
                            UserId = 6
                        },
                        new
                        {
                            Id = 2,
                            ReplyId = 6,
                            UserId = 6
                        });
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.LikedTweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LikedTweets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TweetId = 1,
                            UserId = 6
                        },
                        new
                        {
                            Id = 2,
                            TweetId = 5,
                            UserId = 6
                        },
                        new
                        {
                            Id = 3,
                            TweetId = 2,
                            UserId = 6
                        },
                        new
                        {
                            Id = 4,
                            TweetId = 3,
                            UserId = 6
                        },
                        new
                        {
                            Id = 5,
                            TweetId = 8,
                            UserId = 6
                        });
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.Reply", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int?>("RetweetCount")
                        .HasColumnType("int");

                    b.Property<int?>("TweetId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Replies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Allo, Allo",
                            CreatedAt = new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            LikeCount = 1,
                            TweetId = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 2,
                            Body = "Hi yourself",
                            CreatedAt = new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            LikeCount = 1,
                            TweetId = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 3,
                            Body = "So, a watered down martini? ",
                            CreatedAt = new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            LikeCount = 2,
                            TweetId = 4,
                            UserId = 6
                        },
                        new
                        {
                            Id = 4,
                            Body = "Heyr, Heyr!",
                            CreatedAt = new DateTime(2022, 12, 15, 15, 0, 0, 0, DateTimeKind.Local),
                            LikeCount = 1,
                            TweetId = 5,
                            UserId = 6
                        },
                        new
                        {
                            Id = 5,
                            Body = "Þér er ekki boðið!",
                            CreatedAt = new DateTime(2022, 12, 24, 18, 5, 0, 0, DateTimeKind.Local),
                            LikeCount = 5,
                            TweetId = 6,
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            Body = "😂",
                            CreatedAt = new DateTime(2022, 12, 27, 20, 5, 0, 0, DateTimeKind.Local),
                            LikeCount = 1,
                            TweetId = 8,
                            UserId = 5
                        },
                        new
                        {
                            Id = 7,
                            Body = "Haha",
                            CreatedAt = new DateTime(2022, 12, 27, 20, 10, 0, 0, DateTimeKind.Local),
                            LikeCount = 1,
                            TweetId = 8,
                            UserId = 6
                        });
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.Tweet", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int?>("RetweetCount")
                        .HasColumnType("int");

                    b.Property<string>("TweetBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TweetCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LikeCount = 2,
                            RetweetCount = 1,
                            TweetBody = "Hello World",
                            TweetCreated = new DateTime(2022, 12, 10, 19, 30, 0, 0, DateTimeKind.Local),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            LikeCount = 1,
                            TweetBody = "Oh Father Where Art Thou?",
                            TweetCreated = new DateTime(2022, 12, 10, 19, 35, 0, 0, DateTimeKind.Local),
                            UserId = 4
                        },
                        new
                        {
                            Id = 3,
                            LikeCount = 1,
                            TweetBody = "Bonjour tout le monde",
                            TweetCreated = new DateTime(2022, 12, 10, 19, 40, 0, 0, DateTimeKind.Local),
                            UserId = 5
                        },
                        new
                        {
                            Id = 4,
                            TweetBody = "Bond, James Bond. Shaken, not stirred.",
                            TweetCreated = new DateTime(2022, 12, 11, 15, 30, 0, 0, DateTimeKind.Local),
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            LikeCount = 23,
                            RetweetCount = 10,
                            TweetBody = "Nei, Pepsi er ekki í lagi. Ég vil Kók!",
                            TweetCreated = new DateTime(2022, 12, 12, 18, 45, 0, 0, DateTimeKind.Local),
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            LikeCount = 3,
                            RetweetCount = 1,
                            TweetBody = "Ég kom alla leið frá Nazareth, labbandi á tánum!",
                            TweetCreated = new DateTime(2022, 12, 24, 18, 0, 0, 0, DateTimeKind.Local),
                            UserId = 4
                        },
                        new
                        {
                            Id = 7,
                            LikeCount = 2,
                            TweetBody = "Is there life on mars?",
                            TweetCreated = new DateTime(2022, 12, 26, 1, 0, 0, 0, DateTimeKind.Local),
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            LikeCount = 6,
                            RetweetCount = 2,
                            TweetBody = "Hvað heitir austfirska íþróttin þar sem menn reyna að fella hvorn annan með kústskafti....Austur-Skaftfellingar",
                            TweetCreated = new DateTime(2022, 12, 27, 20, 0, 0, 0, DateTimeKind.Local),
                            UserId = 2
                        },
                        new
                        {
                            Id = 9,
                            LikeCount = 8,
                            TweetBody = "💖",
                            TweetCreated = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            UserId = 6
                        });
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.User", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UserId"), 1L, 1);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Handle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DisplayName = "John Smith",
                            Handle = "J.Smith",
                            ImageURL = "https://comicvine.gamespot.com/a/uploads/square_medium/8/80111/3259571-john%20smith%207.png"
                        },
                        new
                        {
                            UserId = 2,
                            DisplayName = "Jón Jónsson",
                            Handle = "Nonni",
                            ImageURL = "https://www.gunnarf.is/static/gallery/vesturaettarmyndir/sm/crop-jon-olafur-jonsson-2.jpg?v2"
                        },
                        new
                        {
                            UserId = 3,
                            DisplayName = "James Bond",
                            Handle = "007",
                            ImageURL = "https://www.classical-guitar-music.com/wp-content/uploads/2017/10/8446295874_91e78074e61.jpg"
                        },
                        new
                        {
                            UserId = 4,
                            DisplayName = "Jesus H Christ",
                            Handle = "SonOfGod",
                            ImageURL = "https://i1.sndcdn.com/avatars-000310363975-0nia22-t240x240.jpg"
                        },
                        new
                        {
                            UserId = 5,
                            DisplayName = "Joan of Arc",
                            Handle = "BurntWitch",
                            ImageURL = "https://royalarmouries.org/wp-content/uploads/2020/08/1024px-Joan_of_Arc_miniature_graded-e1597418920698-350x350.jpg"
                        },
                        new
                        {
                            UserId = 6,
                            DisplayName = "Ég",
                            Handle = "UmMigFráMérTilMín",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/User-avatar.svg/2048px-User-avatar.svg.png"
                        });
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.LikedReply", b =>
                {
                    b.HasOne("My_Twitter_Clone_Backend.Models.User", "User")
                        .WithMany("LikedReplies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.LikedTweet", b =>
                {
                    b.HasOne("My_Twitter_Clone_Backend.Models.User", "User")
                        .WithMany("LikedTweets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.Reply", b =>
                {
                    b.HasOne("My_Twitter_Clone_Backend.Models.Tweet", "Tweet")
                        .WithMany("Replies")
                        .HasForeignKey("TweetId");

                    b.HasOne("My_Twitter_Clone_Backend.Models.User", "User")
                        .WithMany("Replies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Tweet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.Tweet", b =>
                {
                    b.HasOne("My_Twitter_Clone_Backend.Models.User", "User")
                        .WithMany("Tweets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.Tweet", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("My_Twitter_Clone_Backend.Models.User", b =>
                {
                    b.Navigation("LikedReplies");

                    b.Navigation("LikedTweets");

                    b.Navigation("Replies");

                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}