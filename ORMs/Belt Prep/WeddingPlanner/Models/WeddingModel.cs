#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    // Whatever you need in here for info
    [Required]
    public string WedderOne { get; set; }
    [Required]

    public string WedderTwo { get; set; }

    [Required]
    [DateInFuture]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    private DateTime date;

    [Required]

    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId {get; set;}
    public User? User { get; set; }

    public List<Guest> AllGuests { get; set; } = new List<Guest>();
    

}




public class DateInFutureAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Date is required!!!");
        }

        DateTime date;

        if (DateTime.TryParse(value.ToString(), out date))
        {
            if (date < DateTime.Today)
            {
                return new ValidationResult("The date must be in the future.");
            }
        }

        return ValidationResult.Success;
    }
}