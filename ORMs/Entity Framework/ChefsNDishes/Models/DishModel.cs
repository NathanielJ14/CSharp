#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Dish
{
    [Key]
	public int DishId { get; set; }
// Whatever you need in here for info
    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; }
    
    [Required (ErrorMessage = "Calories is Required")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0.")]
    public int Calories { get; set; }
    [Required (ErrorMessage = "Tastiness is Required")]
    public int Tastiness { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }

    public Chef? Creator { get; set; }
}