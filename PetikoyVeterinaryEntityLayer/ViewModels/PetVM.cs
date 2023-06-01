using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.ViewModels
{
    public class PetVM:BaseNumericVM
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Species { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Breed { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Sex { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Coat { get; set; }
    }
}
