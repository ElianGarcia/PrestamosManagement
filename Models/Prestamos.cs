using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosApp.Models
{
    public class Prestamos
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo ID no puede ser menor que cero o mayor a 1000000.")]
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo Fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Persona.")]
        public int PersonaID { get; set; }

        [Required(ErrorMessage = "El campo Concepto no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El Concepto debe tener por lo menos 8 caracteres.")]
        [MaxLength(50, ErrorMessage = "El Concepto es muy largo.")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "El campo Monto no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Monto no puede ser menor que cero o mayor a 1000000.")]
        public decimal Monto { get; set; }

        public decimal Balance { get; set; }

        public Prestamos()
        {
            ID = 0;
            Fecha = DateTime.Now;
            PersonaID = 0;
            Concepto = string.Empty;
            Monto = 0;
            Balance = 0;
        }

        public Prestamos(int clienteId, DateTime fecha, int personaID, string concepto, decimal monto, decimal balance)
        {
            ID = clienteId;
            Fecha = DateTime.Now;
            PersonaID = personaID;
            Concepto = concepto ?? throw new ArgumentNullException(nameof(concepto));
            Monto = monto;
            Balance = balance;
        }
    }
}
