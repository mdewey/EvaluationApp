using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Data.Migrations
{
    public partial class TablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "LectureID",
                table: "Students",
                newName: "QuestionID");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "Lecturers",
                newName: "CourseID");

            migrationBuilder.AddColumn<int>(
                name: "DataofUnderstandingId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionsId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Lecturers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturesId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DataofUnderstandingId",
                table: "Students",
                column: "DataofUnderstandingId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_QuestionsId",
                table: "Students",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_StudentsId",
                table: "Lectures",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CoursesId",
                table: "Lecturers",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturesId",
                table: "Courses",
                column: "LecturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectures_LecturesId",
                table: "Courses",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Courses_CoursesId",
                table: "Lecturers",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Students_StudentsId",
                table: "Lectures",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_DataOfUnderstanding_DataofUnderstandingId",
                table: "Students",
                column: "DataofUnderstandingId",
                principalTable: "DataOfUnderstanding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Questions_QuestionsId",
                table: "Students",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectures_LecturesId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Courses_CoursesId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Students_StudentsId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_DataOfUnderstanding_DataofUnderstandingId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Questions_QuestionsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DataofUnderstandingId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_QuestionsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_StudentsId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_CoursesId",
                table: "Lecturers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LecturesId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DataofUnderstandingId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "LecturesId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "Students",
                newName: "LectureID");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Lecturers",
                newName: "ClassID");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
