using Laboratorio2.Entidades;
using Laboratorio2.Models;
using Laboratorio2.Models.ViewModels;
using Laboratorio2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPersona iperson;

        public HomeController(ILogger<HomeController> logger, IPersona iperson)
        {
            _logger = logger;

            this.iperson = iperson;
        }

/***************************************************************************************************************************************************/

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(PersonaViewModels personaVM /*, string NombrePersona, int EdadPersona, string DescripcionPersona*/)
        {
            persona person = new persona();

            if (ModelState.IsValid)
            {
                if (personaVM.EdadPersona >= 18)
                {
                    
                    person.NombrePersona = personaVM.NombrePersona;
                    person.EdadPersona = personaVM.EdadPersona;
                    person.DescripcionPersona = personaVM.DescripcionPersona;

                    iperson.Save(person);

                    return View("Deploy");
                }
                else
                {
                    ViewBag.Mensaje = "Lo siento pero el alumno es menor de edad";

                    return View("Save");
                }

            }
            else
            {
                return View("Save");
            }

        }

/***************************************************************************************************************************************************/

        public IActionResult Deploy()
        {
            return View();
        }


        public IActionResult ViewPersons()
        {
            var fileJson = iperson.listardatos();

            return Json(new { data = fileJson });    
        }

/***************************************************************************************************************************************************/


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
