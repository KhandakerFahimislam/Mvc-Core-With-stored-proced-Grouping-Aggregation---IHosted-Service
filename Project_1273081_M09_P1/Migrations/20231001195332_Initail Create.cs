using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_1273081_M09_P1.Migrations
{
    /// <inheritdoc />
    public partial class InitailCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    ExpectSalary = table.Column<decimal>(type: "Money", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsReadyToPrivateCoaching = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDuration = table.Column<DateTime>(type: "date", nullable: false),
                    ExrtaClass = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "ExpectSalary", "IsReadyToPrivateCoaching", "Picture", "Role", "TeacherName" },
                values: new object[,]
                {
                    { 1, 1775.00m, true, "1.jpg", 2, "Teacher 1" },
                    { 2, 1641.00m, true, "2.jpg", 3, "Teacher 2" },
                    { 3, 1159.00m, true, "3.jpg", 4, "Teacher 3" },
                    { 4, 1243.00m, true, "4.jpg", 3, "Teacher 4" },
                    { 5, 1200.00m, true, "5.jpg", 2, "Teacher 5" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "CourseDuration", "ExrtaClass", "TeacherId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 31, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3736), 290, 1 },
                    { 2, new DateTime(2023, 2, 4, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3778), 211, 2 },
                    { 3, new DateTime(2022, 8, 16, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3790), 111, 3 },
                    { 4, new DateTime(2022, 9, 24, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3802), 299, 4 },
                    { 5, new DateTime(2022, 10, 14, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3827), 142, 5 },
                    { 6, new DateTime(2022, 11, 11, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3840), 138, 1 },
                    { 7, new DateTime(2022, 12, 25, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3851), 118, 2 },
                    { 8, new DateTime(2023, 1, 27, 1, 53, 32, 270, DateTimeKind.Local).AddTicks(3861), 293, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");
            string sqlI = @"CREATE PROC InsertTeacher @n VARCHAR(50), @S MONEY, @R INT,  @pi VARCHAR(50), @Is BIT
                         AS
                         INSERT INTO Teachers ( TeacherName, ExpectSalary, Role, Picture, IsReadyToPrivateCoaching)
                         VALUES (@n, @s, @R, @pi, @Is )

                         GO";
            migrationBuilder.Sql(sqlI);
            string sqlU = @"CREATE PROC UpdateTeacher @i INT, @n VARCHAR(50), @s MONEY, @R INT, @pi VARCHAR(50), @Is BIT
                         AS
                         UPDATE Teachers SET TeacherName=@n,ExpectSalary=@s, Role=@R, Picture=@pi, IsReadyToPrivateCoaching=@Is
                         WHERE TeacherId=@i
                         GO";
            migrationBuilder.Sql(sqlU);
            string sqlD = @"CREATE PROC DeleteTeacher @i INT
                         AS
                         DELETE Teachers 
                         WHERE TeacherId=@i
                         GO";
            migrationBuilder.Sql(sqlD);
            string sqlS = @"CREATE PROC InsertSubject @C  DATE, @E INT, @Tid INT
                         AS
                         INSERT INTO Subjects ([CourseDuration], ExrtaClass, TeacherId)
                         VALUES (@C,@E, @Tid )
                         GO";
            migrationBuilder.Sql(sqlS);
            string sqlSU = @"CREATE PROC UpdateSubject @id INT, @C DATE, @E INT, @Tid INT
                         AS
                         UPDATE Subjects SET [CourseDuration]=@C,ExrtaClass=@E, TeacherId=@Tid
                         WHERE SubjectId = @id
                         GO";
            migrationBuilder.Sql(sqlSU);
            string sqlDU = @"CREATE PROC DeleteSubject @id INT
                     AS
                     DELETE Subjects 
                     WHERE SubjectId = @id
                     GO";
            migrationBuilder.Sql(sqlDU);



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.Sql("DROP PROC InsertTeacher");
            migrationBuilder.Sql("DROP PROC UpdateTeacher");
            migrationBuilder.Sql("DROP PROC DeleteTeacher");
            migrationBuilder.Sql("DROP PROC InsertSubject");
            migrationBuilder.Sql("DROP PROC UpdateSubject");
            migrationBuilder.Sql("DROP PROC DeleteSubject");

        }
    }
}
