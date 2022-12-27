using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDemo.Migrations
{
    public partial class updateDbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AcademicYears",
                column: "Id",
                values: new object[]
                {
                    new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                    new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Physics" },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "Math" },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), "English" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AcademicYearId", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new DateTimeOffset(new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Rum", "Nancy", "Swashbuckler Rye" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AcademicYearId", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Ships", "Berry", "Griffin Beak Eldritch" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Marks", "StudentId", "SubjectId" },
                values: new object[] { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), 80, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b") });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Marks", "StudentId", "SubjectId" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 100, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"));

            migrationBuilder.DeleteData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"));
        }
    }
}
