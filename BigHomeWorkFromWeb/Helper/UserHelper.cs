


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BigHomeWorkFromWeb.Models
{
    public static class  UserHelper
    {
        public async static Task<List<UserModel>> GetUsers()
        {
            var UserResult = await File.ReadAllTextAsync("JsonFiles/Users.json");
            var users = JsonSerializer.Deserialize<List<UserModel>>(UserResult);

            var fileResult = await File.ReadAllTextAsync("JsonFiles/Adress.json");
            var adress = JsonSerializer.Deserialize<List<AdressModel>>(fileResult);

            List<UserModel> Users = new List<UserModel>();
            foreach (var user in users)
            {
                user.Adress = adress.FirstOrDefault(a=>a.Id == user.AdressId);
            }

            return users;
        }


        public async static Task AddUser(UserModel user)
        {
            var users = await GetUsers();
            using (FileStream fs = new FileStream("JsonFiles/Users.json", FileMode.Truncate))
            {

                MaxUserId.maxUserId++;
                user.Id = MaxUserId.maxUserId;             
                users.Add(user);

                await JsonSerializer.SerializeAsync<List<UserModel>>(fs, users);
                Console.WriteLine("Data has been saved to file");

            }
        }
        public async static Task Remove(UserModel userModel)
        {
            var users = await GetUsers();
            using (FileStream fs = new FileStream("JsonFiles/Users.json", FileMode.Truncate))
            {


                users.Remove(users.FirstOrDefault(q => q.Id == userModel.Id));

                await JsonSerializer.SerializeAsync<List<UserModel>>(fs, users);

            }
        }
    }
}
