using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.Models
{
    public class Reservas
    {
        [Key]
        public long IdReserva { get; set; }

        [Required(ErrorMessage = "El campo Fecha es requerido.")]
        public DateTime FechaReserva { get; set; }

        [Required(ErrorMessage = "El campo Aeropuerto Orígen es requerido.")]
        [StringLength(60, ErrorMessage = "Máximo 60 caracteres.")]
        public string AeropuertoOrigen { get; set; }

        [Required(ErrorMessage = "El campo Horario de Salida es requerido.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime HorarioSalida { get; set; }

        [Required(ErrorMessage = "El campo Aeropuerto Destino es requerido.")]
        [StringLength(60, ErrorMessage = "Máximo 60 caracteres.")]
        public string AeropuertoLlegada { get; set; }

        [Required(ErrorMessage = "El campo Horario de Llegada es requerido.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime HorarioLlegada { get; set; }

        [Required(ErrorMessage = "El campo Aeropuerto Destino es requerido.")]
        [StringLength(30, ErrorMessage = "Máximo 60 caracteres.")]
        public string Aerolinea { get; set; }

        [Required(ErrorMessage = "El campo Número de Vuelo es requerido.")]
        public int NumeroVuelo { get; set; }

        [Required(ErrorMessage = "El campo Documento del pasajero es requerido.")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        public string DocumentoPasajero { get; set; }

        [Required(ErrorMessage = "El campo Nombres del Pasjero es requerido.")]
        [StringLength(60, ErrorMessage = "Máximo 60 caracteres.")]
        public string NombresPasajero{ get; set; }

        [Required(ErrorMessage = "El campo Tipo de Pasajero.")]
        public byte TipoPasajero { get; set; }

        [Required(ErrorMessage = "El campo Número de Vuelo es requerido.")]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Precio { get; set; }
    }
}
