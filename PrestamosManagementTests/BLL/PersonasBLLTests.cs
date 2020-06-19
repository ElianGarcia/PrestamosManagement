using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrestamosApp.BLL;
using PrestamosApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Personas Persona = new Personas(1, "Loreily Calcaño", "8492345113", "01234567891", "Calle Juan Bosh, #17", DateTime.Now, Convert.ToDecimal(345.33));
            bool guardado = PersonasBLL.Guardar(Persona);
            Assert.AreEqual(guardado, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Personas Persona = new Personas(1, "Loreily Calcaño", "8492345113", "01259837891", "Calle Juan Bosh, #134", DateTime.Now, Convert.ToDecimal(345.33));
            bool modificado = PersonasBLL.Modificar(Persona);
            Assert.AreEqual(modificado, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var eliminado = PersonasBLL.Eliminar(1);
            Assert.IsNotNull(eliminado);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Personas> lista = new List<Personas>();
            lista = PersonasBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = PersonasBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetPersonasTest()
        {
            List<Personas> lista = new List<Personas>();
            lista = PersonasBLL.GetPersonas();
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var eliminado = PersonasBLL.Eliminar(1);
            Assert.IsNotNull(eliminado);
        }
    }
}