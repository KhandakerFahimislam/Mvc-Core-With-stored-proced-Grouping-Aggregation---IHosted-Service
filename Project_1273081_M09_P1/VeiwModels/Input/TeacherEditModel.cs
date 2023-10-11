using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_1273081_M09_P1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_1273081_M09_P1.VeiwModels.Input
{
    public class TeacherEditModel
    {
        public int TeacherId { get; set; }
        [Required, StringLength(50)]
        public string TeacherName { get; set; } = default!;

        [Required, EnumDataType(typeof(Role))]
        public Role Role { get; set; } = default!;
        [Required, Column(TypeName = "Money")]

        public decimal ExpectSalary { get; set; }
     
        public IFormFile? Picture { get; set; } = default!;

        public bool IsReadyToPrivateCoaching { get; set; }

        public virtual List<Subject> Subjects { get; set; } = new List<Subject>();


    }
}
