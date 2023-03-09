using System.Linq;
using aspnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.QtdUsuario = Usuario.Listagem.Count();
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
            if(ModelState.IsValid){
                Usuario.Salvar(usuario);
                return RedirectToAction("Usuarios");
            }
            else
            {
                return View(usuario);
            }
            
        }

         public IActionResult Usuarios()
        {
            var usuario =  Usuario.Listagem;
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Excluir(int? id){

            // Usuario.Excluir(id);
            // return RedirectToAction("Usuarios");

             if(id.HasValue && Usuario.Listagem.Any(u => u.Id == id))
            {
                var usuario =  Usuario.Listagem.Single(U => U.Id == id);
                return View(usuario);
            }

            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        public IActionResult Excluir(Usuario user)
        {
            TempData["Excluiu"] = Usuario.Excluir(user.Id);
            return RedirectToAction("Usuarios");
        }

    }
    
}