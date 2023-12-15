using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Acess_Layer.Migrations
{
    public partial class OneToOneStudentAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Addresses",
                newName: "Address1");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Addresses",
                newName: "StudentAdressId");

            migrationBuilder.AddColumn<int>(
                name: "AddressStudentAdressId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressStudentAdressId",
                table: "Students",
                column: "AddressStudentAdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressStudentAdressId",
                table: "Students",
                column: "AddressStudentAdressId",
                principalTable: "Addresses",
                principalColumn: "StudentAdressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressStudentAdressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressStudentAdressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressStudentAdressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "StudentAdressId",
                table: "Addresses",
                newName: "AdressId");
        }
    }
}
