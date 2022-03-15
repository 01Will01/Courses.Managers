
using Courses.Manager.Shared.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Manager.Domain.DTOs
{
    public class UserDTO: Entity
    {
        [Required]
        [Column(TypeName = "string")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "string")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}