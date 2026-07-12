using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();

        // GET
        Console.WriteLine("GET REQUEST");
        HttpResponseMessage getResponse =
            await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");

        string getData = await getResponse.Content.ReadAsStringAsync();
        Console.WriteLine(getData);

        // POST
        Console.WriteLine("\nPOST REQUEST");

        string postJson = @"{
            ""title"": ""Console App"",
            ""body"": ""Learning API"",
            ""userId"": 1
        }";

        StringContent postContent =
            new StringContent(postJson, Encoding.UTF8, "application/json");

        HttpResponseMessage postResponse =
            await client.PostAsync("https://jsonplaceholder.typicode.com/posts", postContent);

        Console.WriteLine(await postResponse.Content.ReadAsStringAsync());

        // PUT
        Console.WriteLine("\nPUT REQUEST");

        string putJson = @"{
            ""id"":1,
            ""title"":""Updated Title"",
            ""body"":""Updated Body"",
            ""userId"":1
        }";

        StringContent putContent =
            new StringContent(putJson, Encoding.UTF8, "application/json");

        HttpResponseMessage putResponse =
            await client.PutAsync("https://jsonplaceholder.typicode.com/posts/1", putContent);

        Console.WriteLine(await putResponse.Content.ReadAsStringAsync());

        // DELETE
        Console.WriteLine("\nDELETE REQUEST");

        HttpResponseMessage deleteResponse =
            await client.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");

        Console.WriteLine($"Status Code: {deleteResponse.StatusCode}");

        Console.WriteLine("\nDone!");
    }
}