using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MealPlanner.Scraper;

public class WebPage
{
    private IWebDriver _webDriver = new ChromeDriver();
    private readonly string _url = string.Empty;
    private readonly By _header = By.CssSelector("h1[class='entry-title']");

    public WebPage(string url)
    {
        _url = url;
    }

    public string GetHeader()
    {
        _webDriver.Navigate().GoToUrl(_url);
        return _webDriver.FindElement(_header).Text;
    }
}
