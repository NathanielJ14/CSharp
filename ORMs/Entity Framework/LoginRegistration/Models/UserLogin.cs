#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.Models;


public class UserLogin
{
    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string EmailLogin { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string PasswordLogin { get; set; }

}

