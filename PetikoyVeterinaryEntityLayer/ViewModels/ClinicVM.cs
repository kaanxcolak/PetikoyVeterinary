using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.ViewModels
{
    public class ClinicVM:BaseNumericVM
    {
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        
        public DistrictVM? District { get; set; }
    }
}
