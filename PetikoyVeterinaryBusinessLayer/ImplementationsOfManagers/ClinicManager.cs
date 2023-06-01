using AutoMapper;
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
    public class ClinicManager : Manager<ClinicVM, Clinic, int>, IClinicManager
    {
        public ClinicManager(IClinicRepo repo, IMapper mapper)
            : base(repo, mapper, "District")
        {
        }
    }
}
