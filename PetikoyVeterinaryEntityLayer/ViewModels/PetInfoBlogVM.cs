using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.ViewModels
{
    public class PetInfoBlogVM:BaseNumericVM
    {
        public int PetId { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 3)]
        public string BlogText { get; set; }

        public string? Picture { get; set; }


        public PetVM? Pet { get; set; }
    }
}
