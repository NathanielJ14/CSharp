#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

// Whatever you need in here for info
    [Required(ErrorMessage = "First Name is required!")]
    public string FirstName { get; set; }


    [Required(ErrorMessage = "Last Name is required!")]
    public string LastName { get; set; }


    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }


    [Required(ErrorMessage = "Password is required!")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [Required(ErrorMessage = "Confirm Password is required!")]
    [DataType(DataType.Password)]
    [NotMapped]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }
    

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Wedding> AllWeddings { get; set; } = new List<Wedding>();

    public List<Guest> AllGuests { get; set; } = new List<Guest>();
}


public class UniqueEmailAttribute : ValidationAttribute
{    

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   

        if (value == null)
        {           
            return new ValidationResult("Email is required");   
        } 
        
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if (_context.Users.Any(u => u.Email == value.ToString()))
        {
            return new ValidationResult("Email is already taken!");
        }
        else {   
            return ValidationResult.Success;  
        }  
    }
}
