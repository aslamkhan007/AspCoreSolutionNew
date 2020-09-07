using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSolution.Models
{
    public class RentOutBoat
    {
        public int SrId { get; set; }

        [Required(ErrorMessage = "Enter RegisterId")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to Fifty characters.")]
        public string RegisterId { get; set; }

        [Required(ErrorMessage = "Enter Your CustomerName")]
        [StringLength(100, ErrorMessage = "Name should be less than or equal to Fifty characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Enter BoatName")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to Fifty characters.")]
        public string BoatName { get; set; }

    }
}
