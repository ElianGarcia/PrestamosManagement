using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrestamosApp.BLL;
using PrestamosApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Prestamos Prestamo = new Prestamos(1, DateTime.Now, 1, "Adquisicion de Vehiculo", Convert.ToDecimal(234.23), Convert.ToDecimal(345.33));
            bool guardado = PrestamosBLL.Guardar(Prestamo);
            Assert.AreEqual(guardado, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Prestamos Prestamo = new Prestamos(1, DateTime.Now, 1, "Adquisicion de Mocicleta", Convert.ToDecimal(254.23), Convert.ToDecimal(345.33));
            bool modificado = PrestamosBLL.Modificar(Prestamo);
            Assert.AreEqual(modificado, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var encontrado = PrestamosBLL.Buscar(1);
            Assert.IsNotNull(encontrado);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var eliminado = PrestamosBLL.Eliminar(1);
            Assert.IsNotNull(eliminado);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Prestamos> lista = new List<Prestamos>();
            lista = PrestamosBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = PrestamosBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetPrestamosTest()
        {
            List<Prestamos> lista = new List<Prestamos>();
            lista = PrestamosBLL.GetPrestamo();
            Assert.IsNotNull(lista);
        }
    }
}