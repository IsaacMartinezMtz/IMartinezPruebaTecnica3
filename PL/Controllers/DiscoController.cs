using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();
            ML.Result result = BL.Disco.GetAll();
            if (result.Correct)
            {
                disco.Discos = result.Objects;
            }
            else
            {
                return View();
            }
            return View(disco);
        }
        [HttpGet]
        public ActionResult Form(int? IdDisco)
        {
            ML.Disco disco = new ML.Disco();
            if (IdDisco != null)
            {
                ML.Result result = BL.Disco.GetById(IdDisco.Value);
                if (result.Correct)
                {
                    disco = (ML.Disco)result.Object;
                }
                return View(disco);
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            if (disco.IdDisco == 0 || disco.IdDisco == null)
            {


                ML.Result result = BL.Disco.Add(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El disco se registro correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al intentar registrar";
                }
               
            }
            else
            {
                ML.Result result = BL.Disco.Update(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El disco se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar el disco";
                }

            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Disco disco)
        {
            ML.Result result = BL.Disco.Delete(disco);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente el disco";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar el disco";
            }
            return PartialView("Modal");
        }
    }
}