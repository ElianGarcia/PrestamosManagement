using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrestamosApp.BLL;
using PrestamosApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.BLL.Tests
{
    [TestClass()]
    public class MorasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            MorasDetalle m = new MorasDetalle
            {
                ID = 0,
                MoraID = 0,
                PrestamoID = 1,
                Valor = 10
            };
            List<MorasDetalle> lista = new List<MorasDetalle>();
            lista.Add(m);
            Moras mora = new Moras(0, DateTime.Now,  10, lista);

            Assert.IsTrue(MorasBLL.Guardar(mora));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = MorasBLL.Eliminar(1);
            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Moras mora;
            mora = MorasBLL.Buscar(1);
            Assert.IsNotNull(mora);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Moras>();
            lista = MorasBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = MorasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }
    }
}