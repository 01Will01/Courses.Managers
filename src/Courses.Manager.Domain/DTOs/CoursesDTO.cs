
using Courses.Manager.Domain.Enums;
using Courses.Manager.Shared.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Manager.Domain.DTOs
{
    public class CoursesDTO: Entity
    {
        [Required]
        [Column(TypeName = "string")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "Duração")]
        public int Duration  { get; set; }

        [Required]
        [Column(TypeName = "enum")]
        [Display(Name = "Status")]
        public ECourseStatus Status { get; set; }
    }
}
