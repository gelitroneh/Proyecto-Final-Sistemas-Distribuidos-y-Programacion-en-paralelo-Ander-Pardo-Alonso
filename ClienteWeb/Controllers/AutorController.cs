//Se accede al modelo
using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace ClienteWeb.Controllers
{
    public class AutorController : Controller
    {


        // GET: Autor
        public ActionResult Artistas()
        {
            //Invocar servicio REST

            //Cliente http
            HttpClient cliente = new HttpClient();
            //Url base de nuestros servicios
            cliente.BaseAddress = new Uri("https://localhost:44338/");

            //Llamada asincrona del Get                      Capturamos el resultado
            var peticionGet = cliente.GetAsync("api/Autor").Result;//Solo especificamos eso ya que le hemos colocado el baseaddres arriba

            //Validamos si la peticion es exitosa
            if (peticionGet.IsSuccessStatusCode)
            {
                //Lo capturamos en una cadena de texto                 Capturamos el resultado
                var resultado = peticionGet.Content.ReadAsStringAsync().Result;
                //Convertir el resultado a una lista de autores  //Referencia a dominio
                var lista = JsonConvert.DeserializeObject<List<Autores>>(resultado);

                //Enviamos la informacion a la vista
                return View(lista);
            }
            //Si llego aqui hay un error Devuelve un listado de autores vacio
            return View(new List<Autores>());
        }

        
        [HttpGet]
        public ActionResult NuevoA()
        {
            return View();//vista vacia
        }

        //Informacion Capturada en el formulario
        [HttpPost]
        public ActionResult NuevoA(Autores autor)
        {
            // Cliente http
            HttpClient cliente = new HttpClient();
            //Url base de nuestros servicios
            cliente.BaseAddress = new Uri("https://localhost:44338/");

            //Llamada asincrona del Post                     Capturamos el resultado
            var peticionPost = cliente.PostAsync("api/Autor", autor, new JsonMediaTypeFormatter()).Result;//Solo especificamos eso ya que le hemos colocado el baseaddres arriba

            //Validamos si la peticion es exitosa
            if (peticionPost.IsSuccessStatusCode)
            {
                //Lo capturamos en una cadena de texto                 Capturamos el resultado
                var resultado = peticionPost.Content.ReadAsStringAsync().Result;
                //Convertir el resultado a un boleano como indica el webapi  
                var Validacion = JsonConvert.DeserializeObject<bool>(resultado);

                if (Validacion)
                {
                    //Redireccionamos al index para ver el nuevo autor que se inserto
                    return RedirectToAction("Artistas");
                }
                //Si hay algun error retornamos el modelo actual
                return View(autor);
            }
            //Si hay algun error retornamos el modelo actual
            return View(autor);
        }


        [HttpGet]//Primero obtiene los datos
        public ActionResult ActualizarA(int id)//Consultar el id
        {
            // Cliente http
            HttpClient cliente = new HttpClient();
            //Url base de nuestros servicios
            cliente.BaseAddress = new Uri("https://localhost:44338/");

            //Llamada asincrona del Get                     Capturamos el resultado
            var peticionGet = cliente.GetAsync("api/Autor?id=" + id).Result;//Solo especificamos eso ya que le hemos colocado el baseaddres arriba

            //Validamos si la peticion es exitosa
            if (peticionGet.IsSuccessStatusCode)
            {
                //Lo capturamos en una cadena de texto                 Capturamos el resultado
                var resultado = peticionGet.Content.ReadAsStringAsync().Result;
                //Convertir el resultado al objeto 
                var informacion = JsonConvert.DeserializeObject<Autores>(resultado);

                return View(informacion);//Informacion para la vista
            }

            return View();//vista vacia
        }

        //Y luego pone la informacion Capturada en el formulario
        [HttpPost]
        public ActionResult ActualizarA(Autores autor)
        {
            // Cliente http
            HttpClient cliente = new HttpClient();
            //Url base de nuestros servicios
            cliente.BaseAddress = new Uri("https://localhost:44338/");

            //Llamada asincrona del Put                    Capturamos el resultado
            var peticionPut = cliente.PutAsync("api/Autor", autor, new JsonMediaTypeFormatter()).Result;//Solo especificamos eso ya que le hemos colocado el baseaddres arriba

            //Validamos si la peticion es exitosa
            if (peticionPut.IsSuccessStatusCode)
            {
                //Lo capturamos en una cadena de texto                 Capturamos el resultado
                var resultado = peticionPut.Content.ReadAsStringAsync().Result;
                //Convertir el resultado a un boleano como indica el webapi  
                var Validacion = JsonConvert.DeserializeObject<bool>(resultado);

                if (Validacion)
                {
                    //Redireccionamos al index para ver el nuevo autor que se inserto
                    return RedirectToAction("Artistas");
                }
                //Si hay algun error retornamos el modelo actual
                return View(autor);
            }
            //Si hay algun error retornamos el modelo actual
            return View(autor);
        }

        [HttpGet]
        public ActionResult EliminarA(int id)
        {
            // Cliente http
            HttpClient cliente = new HttpClient();
            //Url base de nuestros servicios
            cliente.BaseAddress = new Uri("https://localhost:44338/");

            //Llamada asincrona del Get                     Capturamos el resultado
            var peticionDelete = cliente.DeleteAsync("api/Autor?id=" + id).Result;//Solo especificamos eso ya que le hemos colocado el baseaddres arriba

            //Validamos si la peticion es exitosa
            if (peticionDelete.IsSuccessStatusCode)
            {
                //Lo capturamos en una cadena de texto                 Capturamos el resultado
                var resultado = peticionDelete.Content.ReadAsStringAsync().Result;
                //Convertir el resultado al objeto 
                var informacion = JsonConvert.DeserializeObject<bool>(resultado);


                if (informacion)
                {
                    //Redireccionamos al index para ver el nuevo autor que se borro
                    return RedirectToAction("Artistas");
                }

            }

            return View();//vista vacia
        }

        [HttpGet]
        public ActionResult DetalleA(int id)//Consultar el id
        {
            // Cliente http
            HttpClient cliente = new HttpClient();
            //Url base de nuestros servicios
            cliente.BaseAddress = new Uri("https://localhost:44338/");

            //Llamada asincrona del Get                     Capturamos el resultado
            var peticionGet = cliente.GetAsync("api/Autor?id=" + id).Result;//Solo especificamos eso ya que le hemos colocado el baseaddres arriba

            //Validamos si la peticion es exitosa
            if (peticionGet.IsSuccessStatusCode)
            {
                //Lo capturamos en una cadena de texto                 Capturamos el resultado
                var resultado = peticionGet.Content.ReadAsStringAsync().Result;
                //Convertir el resultado al objeto 
                var informacion = JsonConvert.DeserializeObject<Autores>(resultado);

                return View(informacion);//Informacion para la vista
            }

            return View();//vista vacia
        }


        public ActionResult ConsultasA()
        {
            //Invocar servicio REST

            //Cliente http
            HttpClient cliente = new HttpClient();
            //Url base de nuestros servicios
            cliente.BaseAddress = new Uri("https://localhost:44338/");

            //Llamada asincrona del Get                      Capturamos el resultado
            var peticionGet = cliente.GetAsync("api/Autor").Result;//Solo especificamos eso ya que le hemos colocado el baseaddres arriba

            //Validamos si la peticion es exitosa
            if (peticionGet.IsSuccessStatusCode)
            {
                //Lo capturamos en una cadena de texto                 Capturamos el resultado
                var resultado = peticionGet.Content.ReadAsStringAsync().Result;
                //Convertir el resultado a una lista de cuadros  //Referncia a dominio
                var lista = JsonConvert.DeserializeObject<List<Autores>>(resultado);

                //Enviamos la informacion a la vista
                return View(lista);
            }
            //Si llego aqui hay un error Devuelve un listado de cuadros vacio
            return View(new List<Autores>());
        }
    }
}