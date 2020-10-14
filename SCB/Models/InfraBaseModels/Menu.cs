using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCB.Models.InfraBaseModels
{
    public class Menu
    {
        public Menu()
        {
            LinkRolesMenus = new HashSet<LinkRolesMenu>();
        }
        [Key]
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int ParentId { get; set; }

        public virtual ICollection<LinkRolesMenu> LinkRolesMenus { get; set; }
    }
}
