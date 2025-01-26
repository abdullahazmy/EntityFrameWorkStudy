using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore2.Migrations
{
    /// <inheritdoc />
    public partial class RefactorNewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.EnsureSchema(
                name: "Blogging");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts",
                newSchema: "Blogging");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameIndex(
                name: "IX_Post_BlogId",
                schema: "Blogging",
                table: "Posts",
                newName: "IX_Posts_BlogId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Blogs",
                type: "varchar(150)",
                maxLength: 200,
                nullable: false,
                comment: "This is a comment in the database, behind Posts",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                schema: "Blogging",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "BlogId");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookKey);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                schema: "Blogging",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                schema: "Blogging",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                schema: "Blogging",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Posts",
                schema: "Blogging",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BlogId",
                table: "Post",
                newName: "IX_Post_BlogId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 200,
                oldComment: "This is a comment in the database, behind Posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
