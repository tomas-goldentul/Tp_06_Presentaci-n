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

    public IActionResult Index()
    {
          List<Integrante> integrantes = BD.ObtenerIntegrantes();
        return View();
    }



   [HttpPost]
public IActionResult VerificarUsuario(string usuarioIngresado, string contraseñaIngresada)
    {
        Integrante integrante = BD.verificarCuenta(usuarioIngresado, contraseñaIngresada);
        if (integrante != null)
        {
            HttpContext.Session.SetString("integrante", Objeto.ObjectToString(integrante));
            return RedirectToAction("Logeado");
           
        }
        else
        {
            ViewBag.Error = "Usuario o contraseña incorrectos";
        }
    return RedirectToAction("Index");
    }
    public IActionResult Logeado()
    {
        if (HttpContext.Session.GetString("integrante") != null)
        {
            Integrante integrante = Objeto.StringToObject<Integrante>(HttpContext.Session.GetString("integrante"));
            ViewBag.username = integrante.Username;
            ViewBag.nombre = integrante.Nombre;
            ViewBag.apellido = integrante.Apellido;
            ViewBag.edad = integrante.Edad;
            ViewBag.escuela = integrante.Escuela;
            ViewBag.email = integrante.Email;
        }
        return View();
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}