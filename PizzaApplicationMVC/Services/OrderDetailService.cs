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
    public class OrderDetailService
    {
        public OrderDetailDTO AddOrder(OrderDetailDTO orderDto,string token)
        {
            OrderDetailDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var postTask = client.PostAsJsonAsync<OrderDetailDTO>("OrderDetail", orderDto);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDetailDTO>();
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
        public OrderDetailDTO EditOrder(int id, OrderDetailDTO orderDto,string token)
        {
            OrderDetailDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var putTask = client.PutAsJsonAsync<OrderDetailDTO>("OrderDetail/" + id, orderDto);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDetailDTO>();
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
        public List<OrderDetailDTO> AllOrder(string token)
        {
            List<OrderDetailDTO> orders = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("OrderDetail");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<OrderDetailDTO>>();
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
        public OrderDetailDTO GetOrder(int id,string token)
        {
            OrderDetailDTO order = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8934/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("OrderDetail/" + id);
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDetailDTO>();
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
