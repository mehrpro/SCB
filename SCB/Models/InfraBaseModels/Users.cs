using System.ComponentModel.DataAnnotations;


namespace SCB.Models.InfraBaseModels
{
    public class Users
    {


        [Key]
        [Display(Name = " شناسه کاربری")]
        public int UserId { get; set; }
        [Display(Name = "نام کاربر")]
        [StringLength(150, ErrorMessage = "{0}  نباید بیشتر از 150 حرف باشد")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        public string FullName { get; set; }
        [Display(Name = "ایمیل کاربر")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        public string Email { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [MinLength(8, ErrorMessage = "{0}  نباید کمتر از 8 حرف باشد")]
        [StringLength(16, ErrorMessage = "{0}  نباید بیشتر از 16 حرف باشد")]
        public string Password { get; set; }
        [Display(Name = "شرکت")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        public int CompanyId { get; set; }
        [Display(Name = "نقش کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        public int? RoleId { get; set; }
        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(11, ErrorMessage = "{0}  نباید بیشتر از 11 حرف باشد")]
        public string PhoneNumber { get; set; }
        [Display(Name = "تاییدیه تلفن همراه")]
        public bool PhoneSuccess { get; set; }
        [Display(Name = "تاییدیه ایمیل")]
        public bool EmailSuccess { get; set; }


        public virtual Roles Roles { get; set; }
        public virtual Companys Companys { get; set; }
    }
}
