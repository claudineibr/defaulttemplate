using Microsoft.AspNetCore.Mvc;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Web.Models;
using System.Diagnostics;

namespace ProjetoPadraoNetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeuServicoApplicationService _meuServico;

        public HomeController(IMeuServicoApplicationService _meuServico)
        {
            this._meuServico = _meuServico;
        }
        public IActionResult Index()
        {
            _meuServico.GetMeuServico(1);
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
    }
}
