using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BigHomeWorkFromWeb.Models
{
    public static class AdressHelper
    {
        public async static Task<List<AdressModel>> GetAdress()
        {
            var fileResult = await File.ReadAllTextAsync("JsonFiles/Adress.json");
            var adress = JsonSerializer.Deserialize<List<AdressModel>>(fileResult);

            return adress;
        }
        public async static Task AddAdress(AdressModel adressModel)
        {
            var adress =  await GetAdress();
            using(FileStream fs = new FileStream("JsonFiles/Adress.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                MaxAdressId.maxAdressId++;
                adressModel.Id = MaxAdressId.maxAdressId++;
                adress.Add(adressModel);

                await JsonSerializer.SerializeAsync<List<AdressModel>>(fs, adress);
        
            }
        }  
    }
}
