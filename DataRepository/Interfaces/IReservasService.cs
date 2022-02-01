using ApiAeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.DataRepository.Interfaces
{
    public interface IReservasService : IGenericCrud<Reservas>
    {
        //Obtener un conjunto de registros dentro de un rango de fechas basado en la fecha de la reserva
        Task<List<Reservas>> GetReservasFechas(DateTime inicio, DateTime fin);
    }
}
