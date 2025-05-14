using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "ImgUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Science fiction legend", "/images/authors/asimov.jpg", "Isaac Asimov" },
                    { 2, "Physicist and cosmologist", "/images/authors/hawking.jpg", "Stephen Hawking" },
                    { 3, "Queen of Mystery", "/images/authors/christie.jpg", "Agatha Christie" },
                    { 4, "Biographer of geniuses", "/images/authors/isaacson.jpg", "Walter Isaacson" },
                    { 5, "Greek philosopher", "/images/authors/plato.jpg", "Plato" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Futuristic science & tech", "Science Fiction" },
                    { 2, "Books about past events", "History" },
                    { 3, "Life stories of people", "Biography" },
                    { 4, "Suspense & detective fiction", "Mystery" },
                    { 5, "Ideas, logic, and life", "Philosophy" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CategoryId", "Description", "ISBN", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Isaac Asimov", 5, 1, "Sci-fi classic", "1111111111", 8, "Foundation" },
                    { 2, "Stephen Hawking", 2, 1, "Cosmology made easy", "2222222222", 5, "A Brief History of Time" },
                    { 3, "Agatha Christie", 6, 4, "Detective Hercule Poirot solves a case", "3333333333", 6, "Murder on the Orient Express" },
                    { 4, "Walter Isaacson", 2, 3, "Biography of Steve Jobs", "4444444444", 4, "Steve Jobs" },
                    { 5, "Plato", 7, 5, "Philosophical dialogue", "5555555555", 7, "The Republic" }
                });

            migrationBuilder.InsertData(
                table: "AuthorsOfBooks",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorsOfBooks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorsOfBooks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthorsOfBooks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorsOfBooks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthorsOfBooks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Photos");
        }
    }
}
