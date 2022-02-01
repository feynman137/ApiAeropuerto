using ApiAeropuerto.DatabaseContext;
using ApiAeropuerto.DataRepository.Interfaces;
using ApiAeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.DataRepository.Servicios
{
    public class ReservasService : IReservasService
    {
        private readonly ApiContext _contexto;

        public ReservasService(ApiContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Reservas> Add(Reservas obj)
        {
            try
            {
                using (_contexto)
                {
                    await _contexto.Reservas.AddAsync(obj);

                    await _contexto.SaveChangesAsync();

                    return obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteById(long id)
        {
            try
            {
                using (_contexto)
                {
                    var obj = await _contexto.Reservas.FirstOrDefaultAsync(x =>x.IdReserva == id);

                    _contexto.Reservas.Remove(obj);

                    await _contexto.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<Reservas>> GetAll()
        {
            try
            {
                using (_contexto)
                {
                    return await _contexto.Reservas.OrderBy(x => x.FechaReserva).ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Reservas>> GetReservasFechas(DateTime inicio, DateTime fin)
        {
            try
            {
                using (_contexto)
                {
                    int inicioyear = inicio.Year;
                    int iniciomonth = inicio.Month;
                    int inicioday = inicio.Day;

                    int finyear = fin.Year;
                    int finmonth = fin.Month;
                    int finday = fin.Day;

                    return await _contexto.Reservas.Where(x =>x.FechaReserva.Year >= inicioyear && x.FechaReserva.Month >= iniciomonth && x.FechaReserva.Day >= inicioday)
                                                   .Where(x => x.FechaReserva.Year <= finyear && x.FechaReserva.Month <= finmonth && x.FechaReserva.Day <= finday)
                                                   .OrderBy(x => x.FechaReserva)
                                                   .ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Reservas> GetById(long id)
        {
            try
            {
                using (_contexto)
                {
                    return await _contexto.Reservas.FirstOrDefaultAsync(x => x.IdReserva == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Reservas> Update(Reservas obj)
        {
            try
            {
                using (_contexto)
                {
                    var result = _contexto.Reservas.Update(obj);

                    await _contexto.SaveChangesAsync();

                    return result.Entity;
                }

            }
            catch (Exception )
            {
                throw;
            }
        }

    }
}
