using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_TBservices",
                table: "TBservices",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBmywork",
                table: "TBmywork",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBcontect",
                table: "TBcontect",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBservices",
                table: "TBservices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBmywork",
                table: "TBmywork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBcontect",
                table: "TBcontect");
        }
    }
}
