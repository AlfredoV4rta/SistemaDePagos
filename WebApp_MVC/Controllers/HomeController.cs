using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaEmpresa.WebApp.Auxiliares;
using Newtonsoft.Json;

namespace LaEmpresa.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public string UriApiLogin { get; set; }

        public HomeController(IConfiguration configuration) 
        {
            UriApiLogin = configuration.GetValue<string>("UrlApiLogin");
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                try
                {
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Error inesperado." + ex;
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Login(string mensaje)
        {
            ViewBag.Error = mensaje;
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string contrasenia)
        {
            
            try
            {
                LoginRequestDTO logeuado = new LoginRequestDTO();
                logeuado.Email = email;
                logeuado.Contrasenia = contrasenia;

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(UriApiLogin, "POST", logeuado);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    UsuarioDTO usuario = JsonConvert.DeserializeObject<UsuarioDTO>(body);

                    HttpContext.Session.SetString("rol", usuario.Rol.ToString());
                    HttpContext.Session.SetInt32("usuarioId", usuario.Id);
                    HttpContext.Session.SetString("token", usuario.Token);

                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Error inesperado." + e;
                return View();
            }
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
           
        }

    }
}
