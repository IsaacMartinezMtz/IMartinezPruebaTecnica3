using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.IMartinezPruebaTecnica3Entities contex = new DL.IMartinezPruebaTecnica3Entities())
                {
                    var query = contex.GetAll().ToList();
                    if (query !=  null) 
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Disco discog = new ML.Disco();
                            discog.IdDisco = obj.IdDisco;
                            discog.Titulo = obj.Titulo;
                            discog.Artista = obj.Artista;
                            discog.GeneroMusical = obj.GeneroMusical;
                            discog.Duracion = obj.Duracion;
                            discog.Año = obj.Año;
                            discog.Distribuidora = obj.Distribuidora;
                            discog.Ventas = (int)obj.Ventas;
                            discog.Disponibilidad = (bool)obj.Disponibilidad;

                            result.Objects.Add(discog);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.IMartinezPruebaTecnica3Entities context = new DL.IMartinezPruebaTecnica3Entities())
                {
                    var query = context.DiscoAdd(disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if (query > 0) 
                    {
                        result.Correct = true;
                    }
                    else 
                    { 
                        result.Correct = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IMartinezPruebaTecnica3Entities context = new DL.IMartinezPruebaTecnica3Entities())
                {
                    var query = context.DiscoDelete(disco.IdDisco);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result =new ML.Result();
            try
            {
                using(DL.IMartinezPruebaTecnica3Entities context = new DL.IMartinezPruebaTecnica3Entities())
                {
                    var query = context.GetById(IdUsuario).FirstOrDefault();
                    result.Object = new List<object>();
                    if(query != null)
                    {
                        ML.Disco disco = new ML.Disco();
                        disco.IdDisco = query.IdDisco;
                        disco.Titulo = query.Titulo;
                        disco.Artista = query.Artista;
                        disco.GeneroMusical = query.GeneroMusical;
                        disco.Duracion = query.Duracion;
                        disco.Año = query.Año;
                        disco.Distribuidora = query.Distribuidora;
                        disco.Ventas = (int)query.Ventas;
                        disco.Disponibilidad = (bool)query.Disponibilidad;

                        result.Object=disco;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct=false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }
        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IMartinezPruebaTecnica3Entities context = new DL.IMartinezPruebaTecnica3Entities())
                {
                    var query = context.DiscoUpdate(disco.IdDisco, disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if(query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct=false;
                    }
                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
