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
            CreateMap<Appointment, AppointmentVM>().ReverseMap();
            CreateMap<City, CityVM>().ReverseMap();
            CreateMap<Clinic, ClinicVM>().ReverseMap();
            
            CreateMap<District, DistrictVM>().ReverseMap();
            CreateMap<Pet, PetVM>().ReverseMap();
            CreateMap<PetInfoBlog, PetInfoBlogVM>().ReverseMap();
            CreateMap<AppointmentVM, AppointmentViewModel>().ReverseMap();
            CreateMap<ContactClinic, ContactClinicVM>().ReverseMap();

        }
        

    }
}
