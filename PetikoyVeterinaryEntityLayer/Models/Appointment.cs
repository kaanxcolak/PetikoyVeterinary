using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.Models
{
    [Table("Appointments")]
    public class Appointment:BaseNumeric
    {
        public int ClinicId { get; set; }
        public DateTime DateTime { get; set; }
        public string Customer { get; set; }
        public string? Details { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCompleted { get; set; }



        [ForeignKey("ClinicId")]
        public virtual Clinic Clinic { get; set; }
    }
}
