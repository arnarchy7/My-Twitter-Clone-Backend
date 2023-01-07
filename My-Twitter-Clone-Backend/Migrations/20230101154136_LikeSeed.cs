using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Twitter_Clone_Backend.Migrations
{
    public partial class LikeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReplyId",
                table: "LikedReplies",
                newName: "TweetId");

            migrationBuilder.InsertData(
                table: "LikedTweets",
                columns: new[] { "Id", "TweetId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 6 },
                    { 2, 5, 6 },
                    { 3, 2, 6 },
                    { 4, 3, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LikedTweets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LikedTweets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LikedTweets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LikedTweets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "TweetId",
                table: "LikedReplies",
                newName: "ReplyId");
        }
    }
}
