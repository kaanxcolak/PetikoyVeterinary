using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.IdentityModels
{
    public class AppUser:IdentityUser
    {
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50,MinimumLength =2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50,MinimumLength =2)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsPassive { get; set; }

        [Required]
        [StringLength(11,MinimumLength =11)]
        [RegularExpression("^[0-9]*",ErrorMessage ="Telefon rakamlardan oluşmalıdır")]

        public override string PhoneNumber { get; set; }



    }
}
