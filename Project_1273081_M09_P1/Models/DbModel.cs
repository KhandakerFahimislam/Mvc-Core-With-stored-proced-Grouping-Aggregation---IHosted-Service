using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Project_1273081_M09_P1.Models
{
   public enum Role { SeniorTeacher = 1, AssistentTeacher, JuniorTeacher, GuestTeacher }

    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required,StringLength(50)]
        public string TeacherName { get; set; } = default!;

        [Required,EnumDataType(typeof(Role))]
        public Role? Role { get; set; } = default!;
        [Required,Column(TypeName ="Money")]

        public decimal ExpectSalary { get; set; }
        [Required,StringLength(50)]
        public string? Picture { get; set; } = default!;

        public bool? IsReadyToPrivateCoaching {get; set; } 
        
        public virtual ICollection<Subject> Subjects { get; set; } =new List<Subject>();    

    }
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime? CourseDuration { get; set; }
       
        [Required]

        public int? ExrtaClass { get; set; }

       
        [Required,ForeignKey("Teacher")]

        public int TeacherId { get; set; }

        public virtual Teacher? Teacher {get; set; } 
    }
    public class TeacherDbContext : DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; } = default!;

        public DbSet<Subject> Subjects { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Random random = new();
            for (int i = 1; i <= 5; i++)
            {
                modelBuilder.Entity<Teacher>().HasData(
                  new Teacher { TeacherId = i, TeacherName = "Teacher " + i, Role = (Role)random.Next(1, 5), ExpectSalary = random.Next(1000, 2000) * 1.00M, IsReadyToPrivateCoaching = true, Picture = i + ".jpg" }

             );
            }
            for (int i = 1; i <= 8; i++)
            {
                modelBuilder.Entity<Subject>().HasData(
                   new Subject { SubjectId = i, CourseDuration = DateTime.Now.AddDays(-1 * random.Next(200, 500)), ExrtaClass = random.Next(100, 300), TeacherId = i % 5 == 0 ? 5 : i % 5 }

               );
            }

        }

    }
}
