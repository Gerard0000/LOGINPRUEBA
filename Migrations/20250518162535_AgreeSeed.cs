using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginPrueba.Migrations
{
    /// <inheritdoc />
    public partial class AgreeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Court_Municipality_MunicipalityId",
                table: "Court");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipality_Departments_DepartmentId",
                table: "Municipality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Court",
                table: "Court");

            migrationBuilder.RenameTable(
                name: "Municipality",
                newName: "Municipalities");

            migrationBuilder.RenameTable(
                name: "Court",
                newName: "Courts");

            migrationBuilder.RenameIndex(
                name: "IX_Municipality_DepartmentId",
                table: "Municipalities",
                newName: "IX_Municipalities_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Municipality_CodMunHn",
                table: "Municipalities",
                newName: "IX_Municipalities_CodMunHn");

            migrationBuilder.RenameIndex(
                name: "IX_Court_Name",
                table: "Courts",
                newName: "IX_Courts_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Court_MunicipalityId",
                table: "Courts",
                newName: "IX_Courts_MunicipalityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courts",
                table: "Courts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Municipalities_MunicipalityId",
                table: "Courts",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Departments_DepartmentId",
                table: "Municipalities",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Municipalities_MunicipalityId",
                table: "Courts");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipalities_Departments_DepartmentId",
                table: "Municipalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courts",
                table: "Courts");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                newName: "Municipality");

            migrationBuilder.RenameTable(
                name: "Courts",
                newName: "Court");

            migrationBuilder.RenameIndex(
                name: "IX_Municipalities_DepartmentId",
                table: "Municipality",
                newName: "IX_Municipality_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Municipalities_CodMunHn",
                table: "Municipality",
                newName: "IX_Municipality_CodMunHn");

            migrationBuilder.RenameIndex(
                name: "IX_Courts_Name",
                table: "Court",
                newName: "IX_Court_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Courts_MunicipalityId",
                table: "Court",
                newName: "IX_Court_MunicipalityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Court",
                table: "Court",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Court_Municipality_MunicipalityId",
                table: "Court",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipality_Departments_DepartmentId",
                table: "Municipality",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
