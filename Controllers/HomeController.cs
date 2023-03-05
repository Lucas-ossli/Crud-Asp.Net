using System.Linq;
using aspnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }   
        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            

            if(id.HasValue && Usuario.Listagem.Any(u => u.Id == id))
            {
                var usuario =  Usuario.Listagem.Single(U => U.Id == id);
                return View(usuario);
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            
            return View();
        }


         public IActionResult Usuarios()
        {
            var usuario =  Usuario.Listagem;
            return View(usuario);
        }
    }
    
}