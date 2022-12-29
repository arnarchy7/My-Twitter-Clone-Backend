using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Twitter_Clone_Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Handle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TweetBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TweetCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RetweetCount = table.Column<int>(type: "int", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TweetId = table.Column<int>(type: "int", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RetweetCount = table.Column<int>(type: "int", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DisplayName", "Handle", "ImageURL" },
                values: new object[,]
                {
                    { 1, "John Smith", "J.Smith", "https://comicvine.gamespot.com/a/uploads/square_medium/8/80111/3259571-john%20smith%207.png" },
                    { 2, "Jón Jónsson", "Nonni", "https://www.gunnarf.is/static/gallery/vesturaettarmyndir/sm/crop-jon-olafur-jonsson-2.jpg?v2" },
                    { 3, "James Bond", "007", "https://www.classical-guitar-music.com/wp-content/uploads/2017/10/8446295874_91e78074e61.jpg" },
                    { 4, "Jesus H Christ", "SonOfGod", "https://i1.sndcdn.com/avatars-000310363975-0nia22-t240x240.jpg" },
                    { 5, "Joan of Arc", "BurntWitch", "https://royalarmouries.org/wp-content/uploads/2020/08/1024px-Joan_of_Arc_miniature_graded-e1597418920698-350x350.jpg" },
                    { 6, "Ég", "UmMigFráMérTilMín", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/User-avatar.svg/2048px-User-avatar.svg.png" }
                });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "LikeCount", "RetweetCount", "TweetBody", "TweetCreated", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 1, "Hello World", new DateTime(2022, 12, 10, 19, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 2, null, null, "Hi yourself", new DateTime(2022, 12, 10, 19, 35, 0, 0, DateTimeKind.Local), 4 },
                    { 3, null, null, "Bonjour tout le monde", new DateTime(2022, 12, 10, 19, 40, 0, 0, DateTimeKind.Local), 5 },
                    { 4, null, null, "Bond, James Bond. Shaken, not stirred.", new DateTime(2022, 12, 11, 15, 30, 0, 0, DateTimeKind.Local), 3 },
                    { 5, null, null, "Nei, Pepsi er ekki í lagi. Ég vil Kók!", new DateTime(2022, 12, 12, 18, 45, 0, 0, DateTimeKind.Local), 2 }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Body", "CreatedAt", "LikeCount", "RetweetCount", "TweetId", "UserId" },
                values: new object[] { 1, "Allo, Allo", new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), 1, null, 1, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_TweetId",
                table: "Replies",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
