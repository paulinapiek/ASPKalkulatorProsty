using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Name = "Anna";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry" : "Dobry wieczor";

            Dane[] osoby =
            {
                new Dane{ Name = "Anna", Surname = "Nowak"},
                new Dane { Name = "Jan", Surname = "Nowak" },
                new Dane { Name = "Mateusz", Surname = "Kowalski" },
            };
            return View();
        }
        public IActionResult UrodzinyForm()
        {
            return View();
        }
        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"witaj {urodziny.Imie}  {DateTime.Now.Year - urodziny.Rok}";
            return View();
        }
        public IActionResult Kalkulator(Kalkulator kalkulator)
        { try
            {
                double wynik = 0;
                switch (kalkulator.Dzialanie)
                {
                    case "+":
                        wynik = kalkulator.PierwszaLiczba + kalkulator.DrugaLiczba;
                        break;
                    case "-":
                        wynik = kalkulator.PierwszaLiczba - kalkulator.DrugaLiczba;
                        break;
                    case "*":
                        wynik = kalkulator.PierwszaLiczba * kalkulator.DrugaLiczba;
                        break;
                    case "/":
                        if (kalkulator.DrugaLiczba == 0)
                        {
                            throw new ArgumentException("Nie mozna dzielic przez zero");
                        }
                        wynik = kalkulator.PierwszaLiczba / kalkulator.DrugaLiczba;

                        break;
                    default: throw new ArgumentException("Wybierz dzialanie");
                }

                ViewBag.wynik = $"Wynik dzialania to: {wynik}";
            }catch (Exception e)
            {
                ViewBag.wynik = e.Message;
            }
            return View();

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}