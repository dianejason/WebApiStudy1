using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Pross();
            Console.Read();
        }

        static async void Pross()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = await httpClient.GetAsync("http://localhost:65399/api/user");
            var list = await httpResponse.Content.ReadAsAsync<List<User>>();
            Console.WriteLine("当前联系人：-----------");
            Print(list);
            for (int i = 0; i < 1_000; i++)
            {
                httpResponse = await httpClient.GetAsync("http://localhost:65399/api/user");
                 list = await httpResponse.Content.ReadAsAsync<List<User>>();
                Console.WriteLine("-------------------------"+i);
                Print(list);
            }
            //Console.WriteLine("修改01的Address：00000000000000000000000000000");
            //httpResponse = await httpClient.GetAsync("http://localhost:65399/api/user/01");
            //var put = (await httpResponse.Content.ReadAsAsync<IEnumerable<User>>()).First();
            //put.Address = "00000000000000000000000000000";
            //httpResponse = await httpClient.PutAsJsonAsync<User>("http://localhost:65399/api/user/01", put);

            //httpResponse = await httpClient.GetAsync("http://localhost:65399/api/user");
            //list = await httpResponse.Content.ReadAsAsync<List<User>>();
            //Print(list);
            //Console.WriteLine("删除01");
            //httpResponse = await httpClient.DeleteAsync("http://localhost:65399/api/user/01");
            //httpResponse = await httpClient.GetAsync("http://localhost:65399/api/user");
            //list = await httpResponse.Content.ReadAsAsync<List<User>>();
            //Print(list);

        }

        static void Print(IEnumerable<User> users)
        {
            foreach (var o in users)
            {
                Console.WriteLine($"ID: {o.Id} LoginId:{o.LogInId} Name:{o.Name} Address:{o.Address}");
            }
        }
    }
}
