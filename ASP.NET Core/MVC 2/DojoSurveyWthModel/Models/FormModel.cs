#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWthModel.Models;
public class Info 
{
    
    [MinLength(2, ErrorMessage = "Name must be atleast 2 characters.")]
    [Required(ErrorMessage ="Field is required")]
    public string Name {get; set;}
    public string Location {get; set;}
    public string Langauge {get; set;}
    [MinLength(3)]
    public string? Comment {get; set;}
}