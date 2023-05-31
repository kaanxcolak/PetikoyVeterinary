using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.ViewModels
{
    public class BaseNumericVM
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
