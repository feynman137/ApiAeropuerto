using ApiAeropuerto.DataRepository.Seeders;
using ApiAeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.DatabaseContext
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Reservas> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservas>().HasKey(c => c.IdReserva);


            //modelBuilder.ApplyConfiguration(new ReservasSeed());
        }
    }
}
