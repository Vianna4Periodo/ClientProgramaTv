using ClienteProgramaTV.programacaotv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteProgramaTV.Controllers
{
    public class HomeController : Controller
    {
        GuiaProgramacaoTV server = new GuiaProgramacaoTV();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarCanal()
        {
            return View();
        }

        public ActionResult PersistirCanal(Canal canal)
        {
            server.CadastrarCanal(canal);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCanal(int id)
        {            
            server.RemoverCanal(id);
            return RedirectToAction("TodosCanais");
        }


        public ActionResult CadastrarPrograma(int id)
        {
            ViewBag.IdCanal = id;
            return View();
        }

        public ActionResult PersistirPrograma(Programa programa, int idCanal)
        {
            server.CadastrarPrograma(programa, idCanal);
            return RedirectToAction("Index");
        }

        public ActionResult DeletePrograma(int id)
        {
            server.RemoverPrograma(id);
            return RedirectToAction("Index");
        }


        public ActionResult TodaProgramacaoIdCanal(int id)
        {
            var programacao = server.TodaProgramacaoIdCanal(id);
            return View(programacao);
        }
        public ActionResult TodaProgramacaoIdCanalData()
        {
            return View();
        }
        public ActionResult TodaProgramacaoData()
        {
            return View();
        }

        public ActionResult ExibeProgramacaoData(DateTime data)
        {            
            return View(server.TodaProgramacaoPorData(data));
        }

        public ActionResult TodosCanais()
        {
            var canais = server.TodosCanais();
            return View("RemoverCanal", canais);
        }
    }
}