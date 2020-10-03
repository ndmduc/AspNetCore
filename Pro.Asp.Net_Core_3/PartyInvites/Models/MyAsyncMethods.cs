using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }

        //public static async Task<IEnumerable<long?>> GetPageLengths(List<string> output, params string[] urls)
        //{
        //    List<long?> results = new List<long?>();
        //    HttpClient client = new HttpClient();
        //    foreach (string url in urls)
        //    {
        //        output.Add($"Started request for {url}");
        //        var httpMessage = await client.GetAsync($"http://{url}");
        //        results.Add(httpMessage.Content.Headers.ContentLength);
        //        output.Add($"Completed request for {url}");
        //    }
        //    return results;
        //}

        public static async IAsyncEnumerable<long?> GetPageLengths(List<string> output, params string[] urls)
        {
            List<long?> results = new List<long?>();
            HttpClient client = new HttpClient();
            foreach (string url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync($"http://{url}");
                results.Add(httpMessage.Content.Headers.ContentLength);
                output.Add($"Completed request for {url}");
                yield return httpMessage.Content.Headers.ContentLength;
            }
        }
    }
}
