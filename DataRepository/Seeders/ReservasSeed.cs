using ApiAeropuerto.Models;
using ApiAeropuerto.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.DataRepository.Seeders
{
    public class ReservasSeed : IEntityTypeConfiguration<Reservas>
    {
        
        public void Configure(EntityTypeBuilder<Reservas> builder)
        {
            builder.HasData
             (
                 new Reservas
                 {
                     IdReserva = 1,
                     FechaReserva = new DateTime(2022, 1, 1, 10, 12, 45),
                     AeropuertoOrigen = "EL DORADO",
                     HorarioSalida = new DateTime(2022, 1, 1, 11, 15, 0),
                     AeropuertoLlegada = "ERNESTO CORTIZOS",
                     HorarioLlegada = new DateTime(2022, 1, 1, 12, 15, 0),
                     Aerolinea = "AVIANCA",
                     NumeroVuelo = 123,
                     DocumentoPasajero = "85442315",
                     NombresPasajero = "PEDRO PEREZ",
                     TipoPasajero = (byte)Global.TipoPasajero.Adul,
                     Precio = 300000
                 },
                 new Reservas
                 {
                     IdReserva = 2,
                     FechaReserva = new DateTime(2022, 1, 8, 10, 12, 45),
                     AeropuertoOrigen = "EL DORADO",
                     HorarioSalida = new DateTime(2022, 1, 1, 11, 15, 0),
                     AeropuertoLlegada = "ERNESTO CORTIZOS",
                     HorarioLlegada = new DateTime(2022, 1, 1, 12, 15, 0),
                     Aerolinea = "AVIANCA",
                     NumeroVuelo = 123,
                     DocumentoPasajero = "1052362478",
                     NombresPasajero = "CARLOS MARTINEZ",
                     TipoPasajero = (byte)Global.TipoPasajero.Nin,
                     Precio = 200000
                 },
                 new Reservas
                 {
                     IdReserva = 3,
                     FechaReserva = new DateTime(2022, 1, 11, 10, 12, 45),
                     AeropuertoOrigen = "EL DORADO",
                     HorarioSalida = new DateTime(2022, 1, 1, 11, 15, 0),
                     AeropuertoLlegada = "ERNESTO CORTIZOS",
                     HorarioLlegada = new DateTime(2022, 1, 1, 12, 15, 0),
                     Aerolinea = "AVIANCA",
                     NumeroVuelo = 123,
                     DocumentoPasajero = "23105478",
                     NombresPasajero = "CAROLINA SUAREZ",
                     TipoPasajero = (byte)Global.TipoPasajero.Adul,
                     Precio = 300000
                 }
             );
        }
    }
}
