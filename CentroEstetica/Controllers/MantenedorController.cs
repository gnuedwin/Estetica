using Microsoft.AspNetCore.Mvc; 

using CentroEstetica.Datos;
using CentroEstetica.Models;

namespace CentroEstetica.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        { 
            //La vista mostrara una lista  de contactos
            var oLista = _ContactoDatos.Listar(); 
            
            return View(oLista);
        }
        public IActionResult Guardar()
        { 
            //Metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente)
        {
            //Metodo Recibe el objeto para guardar en BD 
            
           var respuesta = _ContactoDatos.Guardar(oCliente);
           if(respuesta) 
                return RedirectToAction("Listar"); //devuelve a vista que uno quiere 
           else 
            return View();
        }
    }
}
