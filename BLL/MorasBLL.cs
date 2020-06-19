using Microsoft.EntityFrameworkCore;
using PrestamosApp.Data;
using PrestamosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrestamosApp.BLL
{
    public class MorasBLL
    {
        public static bool Guardar(Moras mora)
        {
            if (!Existe(mora.ID))
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        private static bool Insertar(Moras mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in mora.MorasDetalle)
                {
                    var prestamo = contexto.Prestamos.Find(item.PrestamoID);
                    if(prestamo != null)
                    {
                        prestamo.Balance += item.Valor;
                        contexto.Personas.Find(prestamo.PersonaID).Balance += item.Valor;
                    }
                }

                contexto.Moras.Add(mora);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Moras mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var Anterior = Buscar(mora.ID);

            try
            {
                foreach (var item in Anterior.MorasDetalle)
                {
                    var auxPrestamo = contexto.Prestamos.Find(item.PrestamoID);
                    if (!mora.MorasDetalle.Exists(d => d.ID == item.ID))
                    {
                        if (auxPrestamo != null)
                        {
                            auxPrestamo.Balance -= item.Valor;
                            contexto.Personas.Find(auxPrestamo.PersonaID).Balance -= item.Valor;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                //aqui agrego lo nuevo al detalle
                foreach (var item in mora.MorasDetalle)
                {
                    var auxPrestamo = contexto.Prestamos.Find(item.PrestamoID);
                    if (item.ID == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (auxPrestamo != null)
                        {
                            auxPrestamo.Balance += item.Valor;
                            contexto.Personas.Find(auxPrestamo.PersonaID).Balance += item.Valor;
                        }

                    }
                    else
                        contexto.Entry(item).State = EntityState.Modified;
                }

                contexto.Entry(mora).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var mora = contexto.Moras.Find(id);

                if (mora != null)
                {
                    contexto.Moras.Remove(mora);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Moras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Moras mora;

            try
            {
                mora = contexto.Moras
                    .Where(e => e.ID == id)
                    .Include(e => e.MorasDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return mora;
        }

        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> lista = new List<Moras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Moras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Moras.Any(e => e.ID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Moras> GetMora()
        {
            List<Moras> lista = new List<Moras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Moras.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
