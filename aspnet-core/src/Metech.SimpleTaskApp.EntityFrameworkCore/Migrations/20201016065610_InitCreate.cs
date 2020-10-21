using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metech.SimpleTaskApp.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_People_AssignedPersonId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "StsPeople");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedPersonId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "State",
                table: "Tasks",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StsPeople",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StsPeople",
                table: "StsPeople",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StsPeople_AssignedPersonId",
                table: "Tasks",
                column: "AssignedPersonId",
                principalTable: "StsPeople",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StsPeople_AssignedPersonId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StsPeople",
                table: "StsPeople");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "StsPeople",
                newName: "People");

            migrationBuilder.AlterColumn<long>(
                name: "AssignedPersonId",
                table: "Tasks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "People",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_People_AssignedPersonId",
                table: "Tasks",
                column: "AssignedPersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
