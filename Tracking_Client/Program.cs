using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tracking_Client;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7171");

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appliocation/json"));

HttpResponseMessage response = await client.GetAsync("api/issue");
response.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    var readIssue = await response.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();
    foreach (var issue in readIssue)
    {
        Console.WriteLine($"Id: {issue.Id}");
        Console.WriteLine($"Title: {issue.Title}");
        Console.WriteLine($"Description: {issue.Description}");
        Console.Write(new string('-', 9));
    }
}
else
{
    Console.WriteLine("No Results");
}

Console.ReadLine();