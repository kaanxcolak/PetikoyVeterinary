using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetikoyVeterinaryEntityLayer.IdentityModels;
using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryDataLayer
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        {

        }

        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<ContactClinic> ContactClinic { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<PetInfoBlog> PetInfoBlog { get; set; }
        

    }
}
