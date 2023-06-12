using System.ComponentModel.DataAnnotations;

namespace PetikoyVeterinaryUI.Models
{
	public class ContactViewModel
	{
		[Required]
		
		public string PetInfo { get; set; }
		[Required]
	
		public string Name { get; set; }
		[Required]
	
		public string SurName { get; set; }
		[Required]
	
		public string Phone { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Question { get; set; }
	}
}
