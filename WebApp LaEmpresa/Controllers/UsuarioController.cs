using LaEmpresa.WebApp.Auxiliares;
using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaEmpresa.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        public string UriUsuario { get; set; }

        public UsuarioController(IConfiguration configuration)
        {
            UriUsuario = configuration.GetValue<string>("UriUsuario");
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0 || HttpContext.Session.GetInt32("usuario") == 2)
                {
                    try
                    {
                        return View();
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


        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, UsuarioDTO userDto)
        {
            try
            {

                ViewBag.Mensaje = "Usuario creado con exito";
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ActualizarContrasenia()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    try
                    {
                        string token = HttpContext.Session.GetString("token");

                        HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(UriUsuario, "GET", null, token);

                        string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            IEnumerable<UsuarioDTO> usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(body);

                            ViewBag.Usuarios = usuarios;
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
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]

        public IActionResult ActualizarContrasenia(int Id)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                UsuarioDTO usuarioDto= new UsuarioDTO { Id = Id };

                string url = $"{UriUsuario}/{Id}";

                HttpResponseMessage respuesta = AuxiliarHttpClient.EnviarSolicitud(url, "PUT", usuarioDto, token);

                string body = AuxiliarHttpClient.ObtenerBody(respuesta);

                HttpResponseMessage respuestaUsaurios = AuxiliarHttpClient.EnviarSolicitud(UriUsuario, "GET", null, token);
                string bodyUsuarios = AuxiliarHttpClient.ObtenerBody(respuestaUsaurios);

                if (respuestaUsaurios.IsSuccessStatusCode)
                {
                    IEnumerable<UsuarioDTO> usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(bodyUsuarios);
                    ViewBag.Usuarios = usuarios;
                }
                else
                {
                    ViewBag.Usuarios = new List<UsuarioDTO>();
                }

                if(respuesta.IsSuccessStatusCode)
                {
                    string nuevaPass = body;
                    ViewBag.Mensaje = nuevaPass;
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
    }
}
