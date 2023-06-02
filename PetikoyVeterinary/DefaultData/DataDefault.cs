using ClosedXML.Excel;
using Microsoft.AspNetCore.Identity;
using PetikoyVeterinaryBusinessLayer.InterfacesOfManagers;
using PetikoyVeterinaryEntityLayer.IdentityModels;
using PetikoyVeterinaryEntityLayer.ViewModels;

namespace PetikoyVeterinaryUI.DefaultData
{
    public class DataDefault
    {
        public void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                //admin || customer
                string[] roles = new string[] { "Customer", "Veterinary" };

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



        


    }
}
