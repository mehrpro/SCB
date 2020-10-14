using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCB.Models.InfraBaseModels
{
    public class Menus
    {
        public Menus()
        {
            LinkRolesMenus = new HashSet<LinkRolesMenus>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int ParentId { get; set; }

        public virtual ICollection<LinkRolesMenus> LinkRolesMenus { get; set; }
    }
}
