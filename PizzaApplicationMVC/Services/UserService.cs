using PizzaApplicationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.Services
{
    public class UserService
    {
        public UserDTO Register(UserDTO userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8934/api/");
                var postTask = client.PostAsJsonAsync<UserDTO>("User", userDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO = data.Result;
                }
            }
            return userDTO;
        }
        public UserDTO Login(UserDTO userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8934/api/");
                var postTask = client.PostAsJsonAsync<UserDTO>("User/Login", userDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO = data.Result;
                }
            }
            return userDTO;
        }
    }
}
