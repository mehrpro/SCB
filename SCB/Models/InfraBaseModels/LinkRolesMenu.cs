using System.ComponentModel.DataAnnotations;
using SCB.Models.InfraBaseModels;

namespace SCB.Models.InfraBaseModels
{
    public class LinkRolesMenu
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menus { get; set; }
        public virtual Role Roles { get; set; }
    }
}
