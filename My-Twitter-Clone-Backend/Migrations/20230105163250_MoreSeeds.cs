using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Twitter_Clone_Backend.Migrations
{
    public partial class MoreSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TweetId",
                table: "LikedReplies",
                newName: "ReplyId");

            migrationBuilder.InsertData(
                table: "LikedReplies",
                columns: new[] { "Id", "ReplyId", "UserId" },
                values: new object[,]
                {
                    { 1, 5, 6 },
                    { 2, 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "LikedTweets",
                columns: new[] { "Id", "TweetId", "UserId" },
                values: new object[] { 5, 8, 6 });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1,
                column: "TweetId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Body", "CreatedAt", "LikeCount", "RetweetCount", "TweetId", "UserId" },
                values: new object[,]
                {
                    { 2, "Hi yourself", new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), 1, null, 1, 4 },
                    { 3, "So, a watered down martini? ", new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), 2, null, 4, 6 },
                    { 4, "Heyr, Heyr!", new DateTime(2022, 12, 15, 15, 0, 0, 0, DateTimeKind.Local), 1, null, 5, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LikeCount", "TweetBody" },
                values: new object[] { 1, "Oh Father Where Art Thou?" });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 3,
                column: "LikeCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LikeCount", "RetweetCount" },
                values: new object[] { 23, 10 });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "LikeCount", "RetweetCount", "TweetBody", "TweetCreated", "UserId" },
                values: new object[,]
                {
                    { 6, 3, 1, "Ég kom alla leið frá Nazareth, labbandi á tánum!", new DateTime(2022, 12, 24, 18, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 7, 2, null, "Is there life on mars?", new DateTime(2022, 12, 26, 1, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 8, 6, 2, "Hvað heitir austfirska íþróttin þar sem menn reyna að fella hvorn annan með kústskafti....Austur-Skaftfellingar", new DateTime(2022, 12, 27, 20, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 9, 8, null, "💖", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 6 }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Body", "CreatedAt", "LikeCount", "RetweetCount", "TweetId", "UserId" },
                values: new object[] { 5, "Þér er ekki boðið!", new DateTime(2022, 12, 24, 18, 5, 0, 0, DateTimeKind.Local), 5, null, 6, 2 });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Body", "CreatedAt", "LikeCount", "RetweetCount", "TweetId", "UserId" },
                values: new object[] { 6, "😂", new DateTime(2022, 12, 27, 20, 5, 0, 0, DateTimeKind.Local), 1, null, 8, 5 });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Body", "CreatedAt", "LikeCount", "RetweetCount", "TweetId", "UserId" },
                values: new object[] { 7, "Haha", new DateTime(2022, 12, 27, 20, 10, 0, 0, DateTimeKind.Local), 1, null, 8, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LikedReplies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LikedReplies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LikedTweets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.RenameColumn(
                name: "ReplyId",
                table: "LikedReplies",
                newName: "TweetId");

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1,
                column: "TweetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LikeCount", "TweetBody" },
                values: new object[] { null, "Hi yourself" });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 3,
                column: "LikeCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LikeCount", "RetweetCount" },
                values: new object[] { null, null });
        }
    }
}
