using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCB.Models.InfraBaseModels
{
    public sealed class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            LinkRolesMenus = new HashSet<LinkRolesMenu>();
        }
        [Key]
        [Display(Name = "شناسه مجوز")]
        public int RoleId { get; set; }
        [Display(Name = " عنوان مجوز")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(100,ErrorMessage = "{0}  نباید بیشتر از 100 حرف باشد")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(250,ErrorMessage = "{0}  نباید بیشتر از 250 حرف باشد")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<LinkRolesMenu> LinkRolesMenus { get; set; }
    }
}
