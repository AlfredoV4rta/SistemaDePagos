using LaEmpresa.WebApp.Auxiliares;
using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace LaEmpresa.WebApp.Controllers
{
    public class TipoDeGastoController : Controller
    {

        public string UriTipoDeGasto { get; set; }

        public TipoDeGastoController(IConfiguration configuration)
        {
            UriTipoDeGasto = configuration.GetValue<string>("UriTipoDeGasto");
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    try
                    {
                        string token = HttpContext.Session.GetString("token");

                        HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(UriTipoDeGasto, "GET", null, token);

                        string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            IEnumerable<TipoDeGastoDTO> tiposDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoDTO>>(body);

                            return View(tiposDeGasto);
                        }
                        else
                        {
                            ViewBag.Error = body;
                            return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

 
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    try
                    {
                        string token = HttpContext.Session.GetString("token");

                        string url = $"{UriTipoDeGasto}/{id}"; 

                        HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "GET", null, token);

                        string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            TipoDeGastoDTO tipoDeGasto = JsonConvert.DeserializeObject<TipoDeGastoDTO>(body);

                            return View(tipoDeGasto);
                        }
                        else
                        {
                            ViewBag.Error = body;
                            return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeGastoCreateDTO tipoDeGastoDTO)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(UriTipoDeGasto, "POST", tipoDeGastoDTO, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    TipoDeGastoDTO tdg = JsonConvert.DeserializeObject<TipoDeGastoDTO>(body);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }
               
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    try
                    {
                        string token = HttpContext.Session.GetString("token");

                        string url = $"{UriTipoDeGasto}/{id}";

                        HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "GET", null, token);

                        string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            TipoDeGastoDTO tipoDeGasto = JsonConvert.DeserializeObject<TipoDeGastoDTO>(body);

                            return View(tipoDeGasto);
                        }
                        else
                        {
                            ViewBag.Error = body;
                            return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeGastoDTO aEditar, IFormCollection collection)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                string url = $"{UriTipoDeGasto}/{aEditar.Id}";

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "PUT", aEditar, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    TipoDeGastoDTO tipoDeGasto = JsonConvert.DeserializeObject<TipoDeGastoDTO>(body);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    try
                    {
                        string token = HttpContext.Session.GetString("token");

                        string url = $"{UriTipoDeGasto}/{id}";

                        HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "GET", null, token);

                        string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            TipoDeGastoDTO tipoDeGasto = JsonConvert.DeserializeObject<TipoDeGastoDTO>(body);

                            return View(tipoDeGasto);
                        }
                        else
                        {
                            ViewBag.Error = body;
                            return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int idTipoDeGasto, IFormCollection collection)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                string url = $"{UriTipoDeGasto}/delete/{idTipoDeGasto}";

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "DELETE", null, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    TipoDeGastoDTO tipoDeGasto = JsonConvert.DeserializeObject<TipoDeGastoDTO>(body);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }
             
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }
    }
}
