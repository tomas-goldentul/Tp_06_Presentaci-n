using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tp_sinnumero.Models;

namespace tp_sinnumero.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string usuarioIngresado, string contraseñaIngresada){
        if(usuarioIngresado != null && contraseñaIngresada != null){
        Integrante integrante = BD.verificarCuenta(usuarioIngresado, contraseñaIngresada);
        HttpContext.Session.SetString("user", Objeto.ObjectToString(integrante));
        if(integrante != null){
            ViewBag.DatosUsuario = integrante;
            return RedirectToAction("Logeado");
        }
        } else return View();
    }
    public IActionResult Logeado(){
        return View();
    }
}
