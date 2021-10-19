using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class OrderItemDetailService
    {
        public OrderItemDetailDTO AddOrder(OrderItemDetailDTO orderDto)
        {
            OrderItemDetailDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17787/api/");
                    var postTask = client.PostAsJsonAsync<OrderItemDetailDTO>("OrderItemDetail", orderDto);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderItemDetailDTO>();
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
        public OrderItemDetailDTO EditOrder(int id, OrderItemDetailDTO orderDto)
        {
            OrderItemDetailDTO orderDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17787/api/");
                    var putTask = client.PutAsJsonAsync<OrderItemDetailDTO>("OrderItemDetail/" + id, orderDto);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderItemDetailDTO>();
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
        public List<OrderItemDetailDTO> AllOrder()
        {
            List<OrderItemDetailDTO> orders = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17787/api/");
                    var getTask = client.GetAsync("OrderItemDetail");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<OrderItemDetailDTO>>();
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
        public OrderItemDetailDTO GetOrder(int id)
        {
            OrderItemDetailDTO order = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17787/api/");
                    var getTask = client.GetAsync("OrderItemDetail/" + id);
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderItemDetailDTO>();
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
