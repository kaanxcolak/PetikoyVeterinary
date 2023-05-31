using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.Models
{
    [Table("Animals")]
    public class Animal : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Species { get; set; } //Tür

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Breed { get; set; } //ırk

        [Required]
        public string Sex { get; set; } //Cinsiyet
        public DateTime BirthDate { get; set; }
        public string Coat { get; set; }     //Kürkü- renk

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public int Explanation { get; set; }
    }
}
