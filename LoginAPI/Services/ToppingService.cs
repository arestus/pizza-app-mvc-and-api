using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class ToppingService
    {
        public List<ToppingDTO> AllToppings()
        {
            List<ToppingDTO> toppings = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:3048/api/");
                    var getTask = client.GetAsync("Topping");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<ToppingDTO>>();
                        data.Wait();
                        toppings = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return toppings;
        }
        public ToppingDTO GetTopping(int id)
        {
            ToppingDTO topping = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:3048/api/");
                    var postTask = client.GetAsync("Topping/" + id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<ToppingDTO>();
                        data.Wait();
                        topping = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return topping;
        }
    }
}
