using PetikoyVeterinaryDataLayer.InterfacesOfRepo;
using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryDataLayer.ImplementationsOfRepo
{
    
    public class ContactClinicRepo : Repository<ContactClinic, int>, IContactClinicRepo
    {
        public ContactClinicRepo(MyContext context) : base(context)
        {

        }
    }
}
