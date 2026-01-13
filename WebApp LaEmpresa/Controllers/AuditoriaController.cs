using LaEmpresa.WebApp.Auxiliares;
using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaEmpresa.WebApp.Controllers
{
    public class AuditoriaController : Controller
    {
        public string UriAuditoria { get; set; }

        public AuditoriaController(IConfiguration configuration)
        {
            UriAuditoria = configuration.GetValue<string>("UriAuditoria");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuditoriasPorIdTipoDeGasto()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    try
                    {
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Error inesperado" + ex;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]

        public IActionResult AuditoriasPorIdTipoDeGasto(int idTipoDeGasto)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                string url = $"{UriAuditoria}/tipoDeGasto/{idTipoDeGasto}";

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "GET", null, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    IEnumerable<AuditoriaDTO> auditorias = JsonConvert.DeserializeObject<IEnumerable<AuditoriaDTO>>(body);

                    return View(auditorias);
                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }
    }
}
