using Courses.Manager.Domain.Enums;
using Courses.Manager.Shared.Entity;

namespace Courses.Manager.Domain.Entities
{
    public class Course: Entity
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public ECourseStatus Status { get; set; }
    }
}
