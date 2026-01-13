using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http.Headers;
using LaEmpresa.WebApp.Auxiliares;

namespace LaEmpresa.WebApp.Controllers
{
    public class PagoController : Controller
    {

        public string UriPago { get; set; }
        public string UriTipoDeGasto { get; set; }

        public PagoController(IConfiguration configuration)
        {
            UriPago = configuration.GetValue<string>("UriPago");
            UriTipoDeGasto = configuration.GetValue<string>("UriTipoDeGasto");
        }

        public ActionResult Index()
        {
            //if(HttpContext.Session.GetInt32("usuario") != null)
            {
                IEnumerable<PagoDTO> pagos = new List<PagoDTO>();
                try
                {
                    //Encabezado
                    HttpClient cliente = new HttpClient();
                    Uri uri = new Uri(UriPago);
                    cliente.DefaultRequestHeaders.Authorization = new
                        AuthenticationHeaderValue("Bearer", "Aca va el token");
                    HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                    //Generar solicitud
                    Task<HttpResponseMessage> tarea = cliente.SendAsync(solicitud);
                    tarea.Wait();

                    //Procesar respuesta
                    HttpResponseMessage respuesta = tarea.Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        HttpContent contenido = respuesta.Content;
                        Task<string> body = contenido.ReadAsStringAsync();
                        body.Wait();
                        string datos = body.Result;
                        pagos = JsonSerializer.Deserialize<IEnumerable<PagoDTO>>(datos);
                    }

                    return View(pagos);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado";
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        // GET: PagoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                try
                {
                    string token = HttpContext.Session.GetString("token");

                    HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(UriTipoDeGasto, "GET", null, token);

                    string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        IEnumerable<TipoDeGastoDTO> tiposDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoDTO>>(body);

                        ViewBag.TipoDeGasto = tiposDeGasto;
                        return View();
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
            return RedirectToAction("Login", "Home");
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, PagoDTO pagoDto)
        {
            try
            {

                string token = HttpContext.Session.GetString("token");

                string url = $"{UriPago}/pagos/alta/recurrente";

                pagoDto.IdUsuario = (int)HttpContext.Session.GetInt32("usuarioId");

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "POST", pagoDto, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                HttpResponseMessage respuestaTipos = AuxiliarHttpClient.EnviarSolicitud(UriTipoDeGasto, "GET", null, token);
                string bodyTipos = AuxiliarHttpClient.ObtenerBody(respuestaTipos);

                if (respuestaTipos.IsSuccessStatusCode)
                {
                    IEnumerable<TipoDeGastoDTO> tiposDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoDTO>>(bodyTipos);

                    ViewBag.TipoDeGasto = tiposDeGasto;
                }
                else
                {
                    ViewBag.TipoDeGasto = new List<TipoDeGastoDTO>(); 
                }


                if (respuesta.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.Error = body;
                    return View(pagoDto);
                }


            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }


        public ActionResult CreateUnico()
        {

            if (HttpContext.Session.GetString("rol") != null)
            {
                try
                {
                    string token = HttpContext.Session.GetString("token");

                    HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(UriTipoDeGasto, "GET", null, token);

                    string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        IEnumerable<TipoDeGastoDTO> tiposDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoDTO>>(body);

                        ViewBag.TipoDeGasto = tiposDeGasto;
                        return View();
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
            return RedirectToAction("Login", "Home");
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUnico(IFormCollection collection, PagoDTO pagoDto)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                string url = $"{UriPago}/pagos/alta/unico";

                pagoDto.IdUsuario = (int)HttpContext.Session.GetInt32("usuarioId");

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "POST", pagoDto, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                HttpResponseMessage respuestaTipos = AuxiliarHttpClient.EnviarSolicitud(UriTipoDeGasto, "GET", null, token);
                string bodyTipos = AuxiliarHttpClient.ObtenerBody(respuestaTipos);

                if (respuestaTipos.IsSuccessStatusCode)
                {
                    IEnumerable<TipoDeGastoDTO> tiposDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoDTO>>(bodyTipos);

                    ViewBag.TipoDeGasto = tiposDeGasto;
                }
                else
                {
                    ViewBag.TipoDeGasto = new List<TipoDeGastoDTO>();
                }


                if (respuesta.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.Error = body;
                    return View(pagoDto);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }



        // GET: PagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: PagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ListarPagosMensuales()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 2)
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
        public IActionResult ListarPagosMensuales(int mes, int anio)
        {
            try
            {

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex.Message;
                return View();
            }
        }

        public IActionResult ListarUsuariosPagoMonto()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 2)
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

        public IActionResult ListarUsuariosPagoMonto(int monto)
        {
            try
            {

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex.Message;
                return View();
            }
        }

        public IActionResult PagosDeUsuario()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Gerente" || HttpContext.Session.GetString("rol") == "Empleado")
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

        public IActionResult PagosDeUsuario(int idUsuario)
        {

            try
            {
                string token = HttpContext.Session.GetString("token");

                string url = $"{UriPago}/pagos/usuario/{idUsuario}";

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "GET", null, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    IEnumerable<PagoDTO> pagos = JsonConvert.DeserializeObject<IEnumerable<PagoDTO>>(body);

                    return View(pagos);
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

        public IActionResult ListarEquiposMayorMonto()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Gerente")
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

        public IActionResult ListarEquiposMayorMonto(int monto)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                string url = $"{UriPago}/pagos/equipo/{monto}";

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "GET", null, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    IEnumerable<EquipoDTO> equipos = JsonConvert.DeserializeObject<IEnumerable<EquipoDTO>>(body);

                    return View(equipos);
                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex.Message;
                return View();
            }
        }
    }
}
