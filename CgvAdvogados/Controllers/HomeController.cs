using Dominio.Advogado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio.Implementacao.Advogado;
using CgvAdvogados.ViewModels;

namespace CgvAdvogados.Controllers
{
    public class HomeController : Controller
    {
        

        private List<AdvogadoDTO> ListarAdvogados()
        {
            return new AdvogadoRepositorio().ListarAdvogados();
        }

        public ActionResult Index()
        {
            var model = new AdvogadoViewModel()
            {
                advogados = ListarAdvogados(),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult IncluirAdvogado(AdvogadoDTO advogado)
        {
            if (new AdvogadoRepositorio().IncluirAdvogado(advogado))
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}