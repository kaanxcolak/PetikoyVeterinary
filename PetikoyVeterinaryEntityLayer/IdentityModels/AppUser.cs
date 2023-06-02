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
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string TcNo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public override string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public override string PhoneNumber { get; set; }




    }
}
