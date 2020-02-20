using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dreams.Web.Data.Entities
{
    public class IngredientEntity
    {

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 10, ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Descripcion { get; set; }


        
    }
}
