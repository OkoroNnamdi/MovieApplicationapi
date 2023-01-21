using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieManagement.DataAccess.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "biographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_biographies_actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genres_movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName" },
                values: new object[] { 1, "Ifeanyi", false, "Madu" });

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName" },
                values: new object[] { 2, "Edeh", false, "Chinyere" });

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName" },
                values: new object[] { 3, "Akah", false, "Emeka" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "Id", "ActorId", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The coming of our lord jesus", false, "The lord is coming " },
                    { 2, 2, "The lord jesus is the lord", false, "The lord is great " },
                    { 3, 1, "Who is like him", false, "The lord is good " },
                    { 4, 3, "The giver of life presentaion", false, "Offering the lord " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_biographies_ActorId",
                table: "biographies",
                column: "ActorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_genres_MovieId",
                table: "genres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_ActorId",
                table: "movies",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "biographies");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "actors");
        }
    }
}
