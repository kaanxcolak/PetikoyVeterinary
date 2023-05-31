using AutoMapper;
using PetikoyVeterinaryEntityLayer.Models;
using PetikoyVeterinaryEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.Mappings
{
    public class Maps:Profile
    {

        public Maps()
        {
            //AutoMapper sayesinde modellerimiz ile VMlerimizi birleştirdik
            CreateMap<Animal, AnimalVM>().ReverseMap();
            CreateMap<City, CityVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<District, DistrictVM>().ReverseMap();
        }
        

    }
}
