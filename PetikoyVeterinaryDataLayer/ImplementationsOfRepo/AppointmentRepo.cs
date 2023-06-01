using PetikoyVeterinaryDataLayer.InterfacesOfRepo;
using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryDataLayer.ImplementationsOfRepo
{
    public class AppointmentRepo : Repository<Appointment, int>, IAppointmentRepo
    {
        public AppointmentRepo(MyContext context) : base(context)
        {

        }
    }
}
