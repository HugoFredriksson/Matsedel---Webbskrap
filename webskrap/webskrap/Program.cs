using HtmlAgilityPack;
using System.Net;
using System.Text.Encodings.Web;

public class WebScraper
{

    public static async Task Main(string[] args)
    {
        var url = "https://mpi.mashie.com/public/app/V%C3%A4xj%C3%B6%20kommun%20ny/6f5fa240";
        var httpClient = new HttpClient();
        var html = await httpClient.GetStringAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("app-daymenu-name")).ToList();
        foreach ( var div in divs )
        {
            Console.WriteLine(div.InnerText);
            Console.WriteLine();
        }

    }
}