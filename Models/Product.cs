using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    public class Product:IValidatableObject
    {
        public enum Category { Toy, Technique, Clothes, Transport }

        public int Id { get; set; }
        public Category Type { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "The description of at least three characters")]
        public string Description { get; set; }

        [Range(0, 100000)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0}")]
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Description))
            {
                if (Description.Trim() == Name)
                    yield return new ValidationResult("The description cannot be the same as the Name.", new[] { nameof(Description) });

                if (!Description.StartsWith(Name, StringComparison.OrdinalIgnoreCase))
                    yield return new ValidationResult("The description must start with the Name of the product.", new[] { nameof(Description) });
            }
        }
    }
}
