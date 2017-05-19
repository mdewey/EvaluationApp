using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Data.Migrations
{
    public partial class AppUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Lecturers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_ApplicationUserId",
                table: "Lecturers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_AspNetUsers_ApplicationUserId",
                table: "Lecturers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_AspNetUsers_ApplicationUserId",
                table: "Lecturers");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_ApplicationUserId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Lecturers");
        }
    }
}
