using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.Models
{
    [Table("ContactClinics")]
    public class ContactClinic:BaseNumeric
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string PetInfo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string SurName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Question { get; set; }    
    }
}
