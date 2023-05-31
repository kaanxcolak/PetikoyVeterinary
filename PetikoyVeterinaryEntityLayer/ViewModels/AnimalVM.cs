using PetikoyVeterinaryEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.ViewModels
{
    public class AnimalVM : BaseNumericVM
    {
        public string Name { get; set; }        
        public string Species { get; set; } //Tür        
        public string Breed { get; set; } //ırk        
        public string Sex { get; set; } //Cinsiyet
        public DateTime BirthDate { get; set; }
        public string Coat { get; set; }     //Kürkü- renk        
        public int Explanation { get; set; }
    }
}
