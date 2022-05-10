using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hw2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: true),
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Birthday", "Name" },
                values: new object[] { 1, new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher Nolan" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Birthday", "Name" },
                values: new object[] { 2, new DateTime(1971, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe Russo" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Birthday", "Name" },
                values: new object[] { 3, new DateTime(1944, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Lucas" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "DirectorId", "Genre", "Rating", "ReleaseDate", "Title" },
                values: new object[] { 1, 2, "Super Hero", (byte)8, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers Endgame" });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
