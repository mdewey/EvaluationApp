using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Data.Migrations
{
    public partial class DofUupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LecturesId",
                table: "DataOfUnderstanding",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataOfUnderstanding_LecturesId",
                table: "DataOfUnderstanding",
                column: "LecturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfUnderstanding_Lectures_LecturesId",
                table: "DataOfUnderstanding",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfUnderstanding_Lectures_LecturesId",
                table: "DataOfUnderstanding");

            migrationBuilder.DropIndex(
                name: "IX_DataOfUnderstanding_LecturesId",
                table: "DataOfUnderstanding");

            migrationBuilder.DropColumn(
                name: "LecturesId",
                table: "DataOfUnderstanding");
        }
    }
}
