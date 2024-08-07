using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class AccountDetailsViewModel
{
    public AccountBasicInfo? Basic { get; set; }
    public AccountAddressInfo? Address { get; set; }
}

public class AccountBasicInfo
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

    [Display(Name = "Phone (optional)", Prompt = "Enter your phone number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Bio (optional)", Prompt = "Add a short bio..")]
    public string? Bio { get; set; }

}

public class AccountAddressInfo
{

    [Required]
    [Display(Name = "Address Line 1", Prompt = "Enter your first address line")]
    public string AddressLine_1 { get; set; } = null!;

    [Display(Name = "Address Line 2 (optional)", Prompt = "Enter your second address line")]
    public string? AddressLine_2 { get; set; }

    [Required]
    [Display(Name = "Postal Code", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;

    [Required]
    [Display(Name = "City", Prompt = "Enter city")]
    public string City { get; set; } = null!;

}