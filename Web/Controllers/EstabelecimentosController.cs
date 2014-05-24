using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileTickets.Web.Repositorios;
using AgileTickets.Web.Models;
using AgileTickets.Web.Infra.Database;

namespace AgileTickets.Web.Controllers
{
    public class EstabelecimentosController : Controller
    {
        private DiretorioDeEstabelecimentos estabelecimentos;

        public EstabelecimentosController(DiretorioDeEstabelecimentos estabelecimentos)
        {
            // guarda estabelecimento
            this.estabelecimentos = estabelecimentos;
        }

        public ActionResult Index()
        {
            return View(estabelecimentos.Todos());
        }

        [RequiresTransaction]
        public ActionResult Novo(Estabelecimento estabelecimento)
        {
            ViewBag.Message = string.Empty;
            bool success = estabelecimentos.Salva(estabelecimento);
            if (!success)
                ViewBag.Message = "Nao inserido, verifque os dados e tente novamente.";
            // redireciona
            return View("Index", estabelecimentos.Todos());
        }

        private Estabelecimento PopulaEstabelecimento() 
        {
            Estabelecimento e = new Estabelecimento();
            return e;
        }
    }
}
