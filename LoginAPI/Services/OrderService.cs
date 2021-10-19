using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class OrderService
    {
        public OrderDTO AddOrder(OrderDTO orderDto)
        {
            OrderDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:19184/api/");
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
        public OrderDTO EditOrder(int id,OrderDTO orderDto)
        {
            OrderDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:19184/api/");
                    var putTask = client.PutAsJsonAsync<OrderDTO>("Order/"+id, orderDto);
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
        public List<OrderDTO> AllOrder()
        {
            List<OrderDTO> orders = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:19184/api/");
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
        public OrderDTO GetOrder(int id)
        {
            OrderDTO order = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:19184/api/");
                    var getTask = client.GetAsync("Order/"+id);
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
