
using Courses.Manager.Domain.Enums;
using Courses.Manager.Shared.Entity;

namespace Courses.Manager.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public EPermissions Permissions { get; set; }
    }
}
