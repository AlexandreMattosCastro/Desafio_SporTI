using DesafioSporTI.Models;
using DesafioSporTI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;

namespace DesafioSporTI.Controllers
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
            var dataService = new DataService();

            var result = dataService.GetInfoData().Result;
            var json = JsonConvert.DeserializeObject<ListInfoData>(result);

            return View(json.ObterPorEstadoFazendaResult);
        }

        public IActionResult Details(int? id)
        {
            var infoDataService = new DataService();

            var result = infoDataService.GetInfoData().Result;
            var json = JsonConvert.DeserializeObject<ListInfoData>(result);

            var itemSelecionado = json.ObterPorEstadoFazendaResult.First(s => s.ID == id);
            return View(itemSelecionado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
