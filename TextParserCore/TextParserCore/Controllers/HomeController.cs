using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextParserCore.Models;
using CustomParser;
namespace TextParserCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult ConvertToXML(string txtInputText)
        {
            ViewBag.ParsedText=CustomXmlParser.ToXml(txtInputText);
            ViewBag.Mode = "xml";
            return View("Index");
        }

        public IActionResult ConvertToCSV(string txtInputText)
        {
            ViewBag.ParsedText = CustomCSVParser.ToCsv(txtInputText);
            ViewBag.Mode = "csv";
            return View("Index");
        }
    }
}
