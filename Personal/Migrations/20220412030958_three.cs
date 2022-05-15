using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_TBaboutme",
                table: "TBaboutme",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBaboutme",
                table: "TBaboutme");
        }
    }
}
