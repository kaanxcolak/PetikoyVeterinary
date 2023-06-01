using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.Models
{
    [Table("PetInfoBlogs")]
    public class PetInfoBlog:BaseNumeric
    {
        public int PetId { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 3)]
        public string BlogText { get; set; }
        
        public string? Picture { get; set; }


        [ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }

    }
}
