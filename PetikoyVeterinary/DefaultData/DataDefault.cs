using ClosedXML.Excel;
using Microsoft.AspNetCore.Identity;
using PetikoyVeterinaryBusinessLayer.InterfacesOfManagers;
using PetikoyVeterinaryEntityLayer.IdentityModels;

namespace PetikoyVeterinaryUI.DefaultData
{
    public class DataDefault
    {
        public void CheckAndCreate(RoleManager<AppRole> roleManager)
        {
			try
			{
				//admin || customer
				string[] roles = new string[] { "Admin", "Customer" };

                // rolleri tek tek dönüp sisteme olup olmadığına bakacağız. Yoksa ekleyeceğiz!
                foreach (var item in roles) 
                {
                    //Rolden yok mu?
                    if (!roleManager.RoleExistsAsync(item.ToLower()).Result)
                    {
                        //rolden yok ve ekleyelim
                        AppRole role = new AppRole()
                        {
                            Name = item
                        };
                        var result = roleManager.CreateAsync(role).Result;
                    }                    
                }
            }
            catch (Exception)
			{
				throw;
			}
        }

        public void CreateAllCities(ICityManager cityManager)
        {
            //1) Veritabanındaki illeri listeye ekleyelim
            //2) Exceli açıp satır satır okuyup olmayan ili veritabanına ekleyelim
            var cityList = cityManager.GetAll(x => !x.IsRemoved).Data;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Excels");
            string fileName = Path.GetFileName("Cities.xlsx");
            string filePath = Path.Combine(path, fileName);
            using (var excelBook = new XLWorkbook(filePath))
            {

            }
        }
    }
}
