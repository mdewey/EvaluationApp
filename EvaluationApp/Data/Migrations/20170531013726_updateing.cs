using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Data.Migrations
{
    public partial class updateing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfUnderstanding_Lectures_LecturesId",
                table: "DataOfUnderstanding");

            migrationBuilder.AlterColumn<int>(
                name: "LecturesId",
                table: "DataOfUnderstanding",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfUnderstanding_Lectures_LecturesId",
                table: "DataOfUnderstanding",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfUnderstanding_Lectures_LecturesId",
                table: "DataOfUnderstanding");

            migrationBuilder.AlterColumn<int>(
                name: "LecturesId",
                table: "DataOfUnderstanding",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfUnderstanding_Lectures_LecturesId",
                table: "DataOfUnderstanding",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
