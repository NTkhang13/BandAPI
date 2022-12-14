using BandAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BandAPI.ValidationAttributes
{
    public class TitleAndDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var album = (AlbumManipulationDto)validationContext.ObjectInstance;

            if(album.Title == album.Description)
            {
                return new ValidationResult("The title  and description need to be different", new[] { "AlbumManipulationDto" });
            }
            return ValidationResult.Success;
        }
    }
}
