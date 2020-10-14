using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCB.Models.InfraBaseModels
{
    public sealed class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
            LinkRolesMenus = new HashSet<LinkRolesMenus>();
        }
        [Key]
        [Display(Name = "شناسه نقش")]
        public int RoleId { get; set; }
        [Display(Name = " عنوان نقش")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(100,ErrorMessage = "{0}  نباید بیشتر از 100 حرف باشد")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(250,ErrorMessage = "{0}  نباید بیشتر از 250 حرف باشد")]
        public string Description { get; set; }

        public ICollection<Users> Users { get; set; }
        public ICollection<LinkRolesMenus> LinkRolesMenus { get; set; }
    }
}
