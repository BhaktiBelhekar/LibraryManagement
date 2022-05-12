using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Data.Migrations
{
    public partial class phase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddBook",
                columns: table => new
                {
                    BookNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddBook", x => x.BookNo);
                });

            
            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    Student_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.Student_Id);
                });

            
            migrationBuilder.CreateTable(
                name: "IssueBook",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookNo = table.Column<int>(type: "int", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddBooksBookNo = table.Column<int>(type: "int", nullable: true),
                    StudentDetailsStudent_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBook", x => x.id);
                    table.ForeignKey(
                        name: "FK_IssueBook_AddBook_AddBooksBookNo",
                        column: x => x.AddBooksBookNo,
                        principalTable: "AddBook",
                        principalColumn: "BookNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueBook_StudentDetail_StudentDetailsStudent_Id",
                        column: x => x.StudentDetailsStudent_Id,
                        principalTable: "StudentDetail",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnBook",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookNo = table.Column<int>(type: "int", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Return_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fine = table.Column<int>(type: "int", nullable: false),
                    AddBooksBookNo = table.Column<int>(type: "int", nullable: true),
                    StudentDetailsStudent_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnBook", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReturnBook_AddBook_AddBooksBookNo",
                        column: x => x.AddBooksBookNo,
                        principalTable: "AddBook",
                        principalColumn: "BookNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnBook_StudentDetail_StudentDetailsStudent_Id",
                        column: x => x.StudentDetailsStudent_Id,
                        principalTable: "StudentDetail",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_IssueBook_AddBooksBookNo",
                table: "IssueBook",
                column: "AddBooksBookNo");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBook_StudentDetailsStudent_Id",
                table: "IssueBook",
                column: "StudentDetailsStudent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnBook_AddBooksBookNo",
                table: "ReturnBook",
                column: "AddBooksBookNo");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnBook_StudentDetailsStudent_Id",
                table: "ReturnBook",
                column: "StudentDetailsStudent_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "IssueBook");

            migrationBuilder.DropTable(
                name: "ReturnBook");


            migrationBuilder.DropTable(
                name: "AddBook");

            migrationBuilder.DropTable(
                name: "StudentDetail");
        }
    }
}
