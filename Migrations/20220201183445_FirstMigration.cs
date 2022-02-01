using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAeropuerto.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AeropuertoOrigen = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HorarioSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AeropuertoLlegada = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HorarioLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aerolinea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumeroVuelo = table.Column<int>(type: "int", nullable: false),
                    DocumentoPasajero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NombresPasajero = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TipoPasajero = table.Column<byte>(type: "tinyint", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "IdReserva", "Aerolinea", "AeropuertoLlegada", "AeropuertoOrigen", "DocumentoPasajero", "FechaReserva", "HorarioLlegada", "HorarioSalida", "NombresPasajero", "NumeroVuelo", "Precio", "TipoPasajero" },
                values: new object[] { 1L, "AVIANCA", "ERNESTO CORTIZOS", "EL DORADO", "85442315", new DateTime(2022, 1, 1, 10, 12, 45, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 11, 15, 0, 0, DateTimeKind.Unspecified), "PEDRO PEREZ", 123, 300000m, (byte)1 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "IdReserva", "Aerolinea", "AeropuertoLlegada", "AeropuertoOrigen", "DocumentoPasajero", "FechaReserva", "HorarioLlegada", "HorarioSalida", "NombresPasajero", "NumeroVuelo", "Precio", "TipoPasajero" },
                values: new object[] { 2L, "AVIANCA", "ERNESTO CORTIZOS", "EL DORADO", "1052362478", new DateTime(2022, 1, 8, 10, 12, 45, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 11, 15, 0, 0, DateTimeKind.Unspecified), "CARLOS MARTINEZ", 123, 200000m, (byte)2 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "IdReserva", "Aerolinea", "AeropuertoLlegada", "AeropuertoOrigen", "DocumentoPasajero", "FechaReserva", "HorarioLlegada", "HorarioSalida", "NombresPasajero", "NumeroVuelo", "Precio", "TipoPasajero" },
                values: new object[] { 3L, "AVIANCA", "ERNESTO CORTIZOS", "EL DORADO", "23105478", new DateTime(2022, 1, 11, 10, 12, 45, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 11, 15, 0, 0, DateTimeKind.Unspecified), "CAROLINA SUAREZ", 123, 300000m, (byte)1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
