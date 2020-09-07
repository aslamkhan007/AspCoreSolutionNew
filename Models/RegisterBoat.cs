using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSolution.Models
{
    public class RegisterBoat
    {
     
        public int SrId { get; set; }

        [Required(ErrorMessage = "Enter BoatName")]
        [StringLength(15, ErrorMessage = "Name should be less than or equal to Fifty characters.")]
        public string BoatName { get; set; }

        [Required(ErrorMessage = "Enter Your BoatSpeed")]        
        public decimal BoatSpeed { get; set; }

        
        public string RegisterId { get; set; }

    }
}
