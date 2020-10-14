using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCB.Models.InfraBaseModels
{
    public class Company
    {
        public Company()
        {
            Users= new HashSet<User>();
        }

        [Key]
       [Display(Name = " شناسه شرکت")]
        public int CompanyId { get; set; }
        [Display(Name = "نام شرکت")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(250, ErrorMessage = "{0}  نباید بیشتر از 250 حرف باشد")]
        public string CompanyName { get; set; }
        [Display(Name = "آدرس ")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(250, ErrorMessage = "{0}  نباید بیشتر از 250 حرف باشد")]
        public string CompanyAddress { get; set; }
        [Display(Name = "تلفن ")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(11, ErrorMessage = "{0}  نباید بیشتر از 11 حرف باشد")] //08738239014
        public string PhoneNumber { get; set; }
        [Display(Name = "فکس")]
        [StringLength(11, ErrorMessage = "{0}  نباید بیشتر از 11 حرف باشد")]
        public string FaxNumber { get; set; }
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل صحیح وارد نشده است")]
        [StringLength(250, ErrorMessage = "{0}  نباید بیشتر از 250 حرف باشد")]
        public string Email { get; set; }
        [Display(Name = "وب سایت")]
        [StringLength(250, ErrorMessage = "{0}  نباید بیشتر از 250 حرف باشد")]
        public string Website { get; set; }



        public virtual ICollection<User> Users{ get; set; }
    }
}
