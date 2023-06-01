using PetikoyVeterinaryDataLayer.InterfacesOfRepo;
using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryDataLayer.ImplementationsOfRepo
{
    
    public class PetInfoBlogRepo : Repository<PetInfoBlog, int>, IPetInfoBlogRepo
    {
        public PetInfoBlogRepo(MyContext context) : base(context)
        {

        }
    }
}
