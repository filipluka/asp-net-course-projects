using System.ComponentModel.DataAnnotations;
using WebApp.Filters;

namespace WebApp.ViewModels;

public class SignUpViewModel
{
    [Required]
    [Display(Name = "FirstName", Prompt = "Enter your First Name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Display(Name = "LastName", Prompt = "Enter your Last Name")]
    public string LastName { get; set; } = null!;

    [Required]
    [Display(Name = "E-mail address", Prompt = "Enter your e-mail address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "ConfirmPassword", Prompt = "Enter your password again")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage="Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;

    [CheckBoxRequired]
    [Display(Name = "I agree to the Terms & Conditions", Prompt = "Terms and Conditions")]
    public bool TermsAndConditions { get; set; }
  
}
