using System.ComponentModel.DataAnnotations;
using SCB.Models.InfraBaseModels;

namespace SCB.Models.InfraBaseModels
{
    public class LinkRolesMenus
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public virtual Menus Menus { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
