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
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.ID))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        private static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Prestamos.Add(prestamo) != null)
                {
                    contexto.Personas.Find(prestamo.PersonaID).Balance += prestamo.Monto;
                }
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

        public static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(prestamo).State = EntityState.Modified;
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
                var prestamo = contexto.Prestamos.Find(id);

                if (prestamo != null)
                {
                    contexto.Prestamos.Remove(prestamo);
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

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;

            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.Where(criterio).ToList();
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
                encontrado = contexto.Prestamos.Any(e => e.ID == id);
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

        public static List<Prestamos> GetPrestamo()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.ToList();
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
