using Courses.Manager.Shared.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Courses.Manager.Domain.Enums
{
    public enum ECourseStatus
    {
        [Display(Name = "Previsto")]
        [StringValue("Previsto")]
        Expected,

        [Display(Name = "Em Andamento")]
        [StringValue("Em Andamento")]
        InProgress,

        [Display(Name = "Concluído")]
        [StringValue("Concluído")]
        Complete

    }
}
