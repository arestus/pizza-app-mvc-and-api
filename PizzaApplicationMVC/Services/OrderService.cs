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
    public class OrderService
    {
        public OrderDTO AddOrder(OrderDTO orderDto,string token)
        {
            OrderDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var postTask = client.PostAsJsonAsync<OrderDTO>("Order", orderDto);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDTO>();
                        data.Wait();
                        orderDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return orderDTO;
        }
        public OrderDTO EditOrder(int id, OrderDTO orderDto,string token)
        {
            OrderDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var putTask = client.PutAsJsonAsync<OrderDTO>("Order/" + id, orderDto);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDTO>();
                        data.Wait();
                        orderDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return orderDTO;
        }
        public List<OrderDTO> AllOrder(string token)
        {
            List<OrderDTO> orders = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("Order");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<OrderDTO>>();
                        data.Wait();
                        orders = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return orders;
        }
        public OrderDTO GetOrder(int id,string token)
        {
            OrderDTO order = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("Order/" + id);
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDTO>();
                        data.Wait();
                        order = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return order;
        }
    }
}
