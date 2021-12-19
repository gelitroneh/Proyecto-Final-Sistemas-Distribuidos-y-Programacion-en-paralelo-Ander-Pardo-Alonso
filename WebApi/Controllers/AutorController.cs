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
    public class AutorController : ApiController
    {
        //Instanciamos la conexion con la base de datos
        BibliotecaConexion BD = new BibliotecaConexion();

        // GET: api/Autor
        public IEnumerable<Autores> Get()
        {
            //Devuelve la lista de los autores
            var listado = BD.Autores.ToList();
            return listado;
        }

        // GET: api/Autor/5
        public Autores Get(int id)
        {
            //Devuelve el autor cuyo id sea el que indicamos
            var Autor = BD.Autores.FirstOrDefault(x => x.IdAutor == id);
            return Autor;
        }

        // POST: api/Autor
        public bool Post(Autores autor)//Si se inserto o no el registro
        {
            //Agregamos el nuevo Autor
            BD.Autores.Add(autor);
            //Guardamos los cambios
            return BD.SaveChanges() > 0;//Si es mayor que 0 devuelve true
        }

        // PUT: api/Autor/5
        public bool Put(Autores autor)
        {
            //Buscamos el nuevo valor
            var NuevoAutor = BD.Autores.FirstOrDefault(x => x.IdAutor == autor.IdAutor);
            //Obtenido el Autor le actualizamos los valores
            NuevoAutor.Nombre = autor.Nombre;
            NuevoAutor.Nacimiento = autor.Nacimiento;
            NuevoAutor.Fallecimiento = autor.Fallecimiento;
            NuevoAutor.Origen = autor.Origen;
            NuevoAutor.Periodo = autor.Periodo;
            NuevoAutor.ImagenAutor = autor.ImagenAutor;
            //Guardamos los cambios
            return BD.SaveChanges() > 0;//Si es mayor que 0 devuelve true
        }

        // DELETE: api/Autor/5
        public bool Delete(int id)
        {
            //Buscamos el valor que se va a borrar
            var EliminarAutor = BD.Autores.FirstOrDefault(x => x.IdAutor == id);
            //Lo eliminamos
            BD.Autores.Remove(EliminarAutor);
            //Guardamos los cambios
            return BD.SaveChanges() > 0;//Si es mayor que 0 devuelve true
        }
    }
}
