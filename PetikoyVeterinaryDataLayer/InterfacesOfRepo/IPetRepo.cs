﻿using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryDataLayer.InterfacesOfRepo
{
    public interface IPetRepo:IRepository<Pet,int>
    {
    }
}
