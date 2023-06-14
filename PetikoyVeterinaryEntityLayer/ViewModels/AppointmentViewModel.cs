using PetikoyVeterinaryEntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.ViewModels
{
    public class AppointmentViewModel
    {
        public AppUser CustomerInfo { get; set; }
        public int ClinicId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Details { get; set; }
        public string? Customer { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCompleted { get; set; }


        public ClinicVM? Clinic { get; set; }
    }
}
