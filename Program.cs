using System;
using System.Net.Http;
using HtmlAgilityPack;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        string url = "https://fortyau.com/culture/"; // Replace with your target website
        Console.WriteLine($"Fetching data from {url}...");

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Fetch HTML content
                string html = await client.GetStringAsync(url);

                // Parse with HtmlAgilityPack
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                // Find and print links
                var careerLinks = htmlDoc.DocumentNode.SelectNodes("//a[contains(translate(text(), 'CAREERS', 'careers'), 'careers')]");
                if (careerLinks != null)
                {
                    Console.WriteLine("Links found:");
                    foreach (var link in careerLinks)
                    {
                        Console.WriteLine(link.Attributes["href"].Value);
                    }
                }
                else
                {
                    Console.WriteLine("No links found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
