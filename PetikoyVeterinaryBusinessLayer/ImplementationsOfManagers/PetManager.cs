﻿using AutoMapper;
using PetikoyVeterinaryBusinessLayer.InterfacesOfManagers;
using PetikoyVeterinaryDataLayer.InterfacesOfRepo;
using PetikoyVeterinaryEntityLayer.Models;
using PetikoyVeterinaryEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryBusinessLayer.ImplementationsOfManagers
{
    public class PetManager : Manager<PetVM, Pet, int>, IPetManager
    {
        public PetManager(IPetRepo repo, IMapper mapper)
            : base(repo, mapper, "District")
        {
        }
    }
}
