#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }
    // Whatever you need in here for info
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required(ErrorMessage = "DOB is required!")]
    [DateInPast]
    public DateTime DOB { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes { get; set; } = new List<Dish>();

    public int Age
    {
        get
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DOB.Year;
            if (DOB > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }

}


public class DateInPastAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("DOB is required!!!");
        }

        DateTime date;

        if (DateTime.TryParse(value.ToString(), out date))
        {
            if (date >= DateTime.Today)
            {
                return new ValidationResult("The date must be in the past.");
            }
        }

        return ValidationResult.Success;
    }
}
