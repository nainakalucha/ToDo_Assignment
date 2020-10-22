using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adform_ToDo.DAL.Migrations
{
    public partial class ToDoMigrationv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    LabelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Labels_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    ToDoListId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdationDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.ToDoListId);
                    table.ForeignKey(
                        name: "FK_ToDoLists_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    ToDoItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdationDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    ToDoListId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.ToDoItemId);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoItems_ToDoLists_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoLists",
                        principalColumn: "ToDoListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToDoListLabels",
                columns: table => new
                {
                    ListMappingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelId = table.Column<long>(nullable: false),
                    ToDoListId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListLabels", x => x.ListMappingId);
                    table.ForeignKey(
                        name: "FK_ToDoListLabels_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoListLabels_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "LabelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoListLabels_ToDoLists_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoLists",
                        principalColumn: "ToDoListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItemLabels",
                columns: table => new
                {
                    ItemMappingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelId = table.Column<long>(nullable: false),
                    ToDoItemId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItemLabels", x => x.ItemMappingId);
                    table.ForeignKey(
                        name: "FK_ToDoItemLabels_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoItemLabels_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "LabelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoItemLabels_ToDoItems_ToDoItemId",
                        column: x => x.ToDoItemId,
                        principalTable: "ToDoItems",
                        principalColumn: "ToDoItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "LastName", "Password", "UserName", "UserRole" },
                values: new object[] { 1L, "Sunaina", "Kalucha", "MTIzNDU=", "Sunaina", "Admin" });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "LabelId", "CreatedBy", "Description" },
                values: new object[,]
                {
                    { 1L, 1L, "Review" },
                    { 2L, 1L, "Watch" },
                    { 3L, 1L, "Pay" },
                    { 4L, 1L, "Criticise" }
                });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CreatedBy", "CreationDate", "Description", "UpdationDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 890, DateTimeKind.Local).AddTicks(4183), "List of movies to watch", null },
                    { 2L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(182), "List of movies to review", null },
                    { 3L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(233), "List of movies to pay", null },
                    { 4L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(236), "List of meals to cook", null },
                    { 5L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(238), "List of moview to watch", null }
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "ToDoItemId", "CreatedBy", "CreationDate", "Notes", "ToDoListId", "UpdationDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(654), "Watch horror movies", 1L, null },
                    { 5L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1347), "Watch Kids Movies", 1L, null },
                    { 2L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1319), "Review action movies", 2L, null },
                    { 4L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1345), "Review thriller movies", 2L, null },
                    { 3L, 1L, new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1342), "Pay romantic movies", 3L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_CreatedBy",
                table: "Labels",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemLabels_CreatedBy",
                table: "ToDoItemLabels",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemLabels_LabelId",
                table: "ToDoItemLabels",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemLabels_ToDoItemId",
                table: "ToDoItemLabels",
                column: "ToDoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_CreatedBy",
                table: "ToDoItems",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoListId",
                table: "ToDoItems",
                column: "ToDoListId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListLabels_CreatedBy",
                table: "ToDoListLabels",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListLabels_LabelId",
                table: "ToDoListLabels",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListLabels_ToDoListId",
                table: "ToDoListLabels",
                column: "ToDoListId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_CreatedBy",
                table: "ToDoLists",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItemLabels");

            migrationBuilder.DropTable(
                name: "ToDoListLabels");

            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
