using PizzaApplicationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.Services
{
    public class PizzaService
    {
        public List<PizzaDTO> AllPizzas(string token)
        {
            List<PizzaDTO> pizzas = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("Pizza");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<PizzaDTO>>();
                        data.Wait();
                        pizzas = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return pizzas;
        }
        public PizzaDTO GetPizza(int id, string token)
        {
            PizzaDTO pizzDTO = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var postTask = client.GetAsync("Pizza/" + id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<PizzaDTO>();
                        data.Wait();
                        pizzDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return pizzDTO;
        }
    }
}
