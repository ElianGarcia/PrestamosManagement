using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosApp.Models
{
    public class MorasDetalle
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo ID no puede ser menor que cero o mayor a 1000000.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Mora no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo no puede ser menor que cero o mayor a 1000000.")]
        public int MoraID { get; set; }

        [Required(ErrorMessage = "El campo Mora no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo no puede ser menor que cero o mayor a 1000000.")]
        public int PrestamoID { get; set; }

        [Required(ErrorMessage = "El campo Valor no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Valor no puede ser menor que cero o mayor a 1000000.")]
        public decimal Valor { get; set; }

        public MorasDetalle()
        {
            ID = 0;
            MoraID = 0;
            PrestamoID = 0;
            Valor = 0;
        }
    }
}
