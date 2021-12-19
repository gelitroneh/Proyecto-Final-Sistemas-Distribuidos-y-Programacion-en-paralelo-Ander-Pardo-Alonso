using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//Agregar la referencia al modelo de datos
using Datos.Modelo;

namespace WebApi.Controllers
{
    public class CuadroController : ApiController
    {
        //Instanciamos la base de datos
        BibliotecaConexion BD = new BibliotecaConexion();

        // GET: api/Cuadro
        public IEnumerable<Cuadros> Get()
        {
            //Devuelve la lista de los cuadros
            var listado = BD.Cuadros.ToList();
            return listado;
        }

        // GET: api/Cuadro/5
        public Cuadros Get(int id)
        {
            //Devuelve el cuadro cuyo id sea el que indicamos
            var Cuadro = BD.Cuadros.FirstOrDefault(x=>x.IdCuadro == id);
            return Cuadro;
        }


        // POST: api/Cuadro
        public bool Post(Cuadros cuadro)//Si se inserto o no el registro
        {
            //Agregamos el nuevo cuadro
            BD.Cuadros.Add(cuadro);
            //Guardamos los cambios
            return BD.SaveChanges() > 0;//Si es mayor que 0 devuelve true
        }

        // PUT: api/Cuadro/5
        public bool Put(Cuadros cuadro)
        {
            //Buscamos el nuevo valor
            var NuevoCuadro = BD.Cuadros.FirstOrDefault(x => x.IdCuadro == cuadro.IdCuadro);
            //Obtenido el Cuadro le actualizmoslos valores
            NuevoCuadro.Titulo = cuadro.Titulo;
            NuevoCuadro.Autor = cuadro.Autor;
            NuevoCuadro.TamañoAlto = cuadro.TamañoAlto;
            NuevoCuadro.TamañoAncho = cuadro.TamañoAncho;
            NuevoCuadro.Fecha_Creacion = cuadro.Fecha_Creacion;
            NuevoCuadro.Estilo = cuadro.Estilo;
            NuevoCuadro.ImagenCuadro = cuadro.ImagenCuadro;
           //Guardamos los cambios
            return BD.SaveChanges() > 0;//Si es mayor que 0 devuelve true
        }

        // DELETE: api/Cuadro/5
        public bool Delete(int id)
        {
            //Buscamos el valor que se va a borrar
            var EliminarCuadro = BD.Cuadros.FirstOrDefault(x => x.IdCuadro ==id);
            //Lo eliminamos
            BD.Cuadros.Remove(EliminarCuadro);
            //Guardamos los cambios
            return BD.SaveChanges() > 0;//Si es mayor que 0 devuelve true
        }
    }
}
