namespace MealPlanner.Scraper;

public class WebScraper : IWebScraper
{

    private static void Main(string[] args)
    {
    }

    public string Print(string url)
    {
        WebPage _page = new(url);
        var header = _page.GetHeader();
        return header;
    }
}