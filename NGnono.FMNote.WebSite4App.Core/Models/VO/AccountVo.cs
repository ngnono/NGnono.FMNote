using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGnono.Framework.Models;

namespace NGnono.FMNote.WebSite4App.Core.Models.VO
{
    public class LoginVO : BaseVO
    {
        [Required]
        [StringLength(32, MinimumLength = 6)]
        [Display(Name = "帐号")]
        public string UserName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }

    public class RegisterVO : BaseVO
    {
        [Required]
        [RegularExpression("^[a-zA-Z]{1}[a-zA-Z0-9_]{5,31}$", ErrorMessage = "用户名必须以字母开头,可包含数字、字母、下划线,最少6位最多32位。")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [StringLength(32, MinimumLength = 1)]
        [Display(Name = "昵称")]
        public string ScreenName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "电子邮件地址")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordVO : BaseVO
    {
        [Required]
        [StringLength(32, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "OldPassword")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class EditUserInfoVO : BaseVO
    {
        [StringLength(32, MinimumLength = 6)]
        [Display(Name = "昵称")]
        public string ScreenName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "电子邮件地址")]
        public string Email { get; set; }
    }
}
