using PetikoyVeterinaryDataLayer.InterfacesOfRepo;
using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryDataLayer.ImplementationsOfRepo
{
    public class PetRepo : Repository<Pet, int>, IPetRepo
    {
        public PetRepo(MyContext context) : base(context)
        {

        }
    }
}
