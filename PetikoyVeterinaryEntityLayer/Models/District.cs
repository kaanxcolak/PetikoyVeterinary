using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.Models
{
    public class District:BaseNumeric
    {
        //Name, CityId, City
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")] //CityId' ye yazdığım int değerinin City Tablosunda karşığı olmak zorunda
        public virtual City City { get; set; } //CityId propertsi Foreign Key olacağı için burada City Tablosu ile ilişki kuruldu

        //Not: İlişkiler burada kurulacağı gibi MYCONTEXT classı içindeki OnModelCreating metodu ezilerek (override) kurulabilir.

       


    }
}
