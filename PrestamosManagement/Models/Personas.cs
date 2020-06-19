using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosApp.Models
{
    public class Personas
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo ID no puede ser menor que cero o mayor a 1000000.")]
        public int PersonaID { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener por lo menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre es muy largo.")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Telefono no puede estar vacío.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de Teléfono válido.")]
        [MaxLength(10, ErrorMessage = "El campo Telefono no tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Cedula no puede estar vacío.")]
        [RegularExpression("^\\d{3}\\D?\\d{7}\\D?\\d$", ErrorMessage = "Por favor ingrese un No. de Cedula válido.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo dirección no puede estar vacía.")]
        [MinLength(10, ErrorMessage = "La dirección es muy corta.")]
        [MaxLength(40, ErrorMessage = "La dirección debe contener menos de 40 caracteres.")]
        public string Direccion { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo Fecha de Nacimiento no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "")]
        [Range(0, 1000000, ErrorMessage = "El campo Balance no puede ser menor que cero o mayor a 1000000.")]
        public decimal Balance { get; set; }

        public Personas()
        {
            PersonaID = 0;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            FechaDeNacimiento = DateTime.Now;
            Balance = 0;
        }

        public Personas(int personaID, string nombres, string telefono, string cedula, string direccion, DateTime fechaDeNacimiento, decimal balance)
        {
            PersonaID = personaID;
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaDeNacimiento = fechaDeNacimiento;
            Balance = balance;
        }
    }
}
