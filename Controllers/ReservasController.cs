
using ApiAeropuerto.DataRepository.Interfaces;
using ApiAeropuerto.Models;
using ApiAeropuerto.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ReservasController : ControllerBase
    {
        private readonly IReservasService _rservice;

        public ReservasController(IReservasService rservice)
        {
            _rservice = rservice;
        }


        //GET api/Reservas/GetAll
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            Resultado<Reservas> resultado = new Resultado<Reservas>();

            try
            {
                List<Reservas> datos = await _rservice.GetAll();

                if (datos != null)
                {
                    if (datos.Count > 0)
                    {
                        resultado.resultado = true;
                        resultado.mensaje = "exito";
                        resultado.datos = datos;
                    }
                    else
                    {
                        resultado.resultado = false;
                        resultado.mensaje = "";
                        resultado.datos = null;
                    }
                }
                else
                {
                    resultado.resultado = false;
                    resultado.mensaje = "";
                    resultado.datos = null;
                }

            }
            catch (Exception e)
            {
                resultado.resultado = false;
                resultado.mensaje = e.InnerException != null ? e.InnerException.Message : e.Message;
            }

            if (resultado.resultado)
            {
                return Ok(JsonConvert.SerializeObject(resultado));
            }
            else
            {
                return BadRequest(JsonConvert.SerializeObject(resultado));
            }
        }

        //GET api/Reservas/GetByFechas
        [HttpGet]
        public async Task<ActionResult> GetByFechas(DateTime inicio, DateTime fin)
        {
            Resultado<Reservas> resultado = new Resultado<Reservas>();

            try
            {
                List<Reservas> datos = await _rservice.GetReservasFechas(inicio, fin);

                if (datos != null)
                {
                    if (datos.Count > 0)
                    {
                        resultado.resultado = true;
                        resultado.mensaje = "exito";
                        resultado.datos = datos;
                    }
                    else
                    {
                        resultado.resultado = false;
                        resultado.mensaje = "";
                        resultado.datos = null;
                    }
                }
                else
                {
                    resultado.resultado = false;
                    resultado.mensaje = "";
                    resultado.datos = null;
                }

            }
            catch (Exception e)
            {
                resultado.resultado = false;
                resultado.mensaje = e.InnerException != null ? e.InnerException.Message : e.Message;
            }

            if (resultado.resultado)
            {
                return Ok(JsonConvert.SerializeObject(resultado));
            }
            else
            {
                return BadRequest(JsonConvert.SerializeObject(resultado));
            }

        }

        //GET api/Reservas/GetByCod
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            Resultado<Reservas> resultado = new Resultado<Reservas>();

            try
            {
                Reservas dato = await _rservice.GetById(id);

                if (dato != null)
                {
                    List<Reservas> datos = new List<Reservas>();
                    datos.Add(dato);

                    resultado.resultado = true;
                    resultado.mensaje = "exito";
                    resultado.datos = datos;
                }
                else
                {
                    resultado.resultado = false;
                }

            }
            catch (Exception e)
            {
                resultado.resultado = false;
                resultado.mensaje = e.InnerException != null ? e.InnerException.Message : e.Message;
            }

            if (resultado.resultado)
            {
                return Ok(JsonConvert.SerializeObject(resultado));
            }
            else
            {
                return BadRequest(JsonConvert.SerializeObject(resultado));
            }
        }

        //POST api/Reservas/Add
        [HttpPost]

        public async Task<IActionResult> Add(Reservas obj)
        {
            Result resultado = new Result();
            try
            {
                if (obj != null)
                {
                    if (!String.IsNullOrEmpty(obj.IdReserva.ToString()))
                    {
                        if (obj.Precio <= 0) throw new Exception("El precio debe ser mayor a 0");

                        if (ModelState.IsValid)
                        {
                            Reservas  _obj = await _rservice.Add(obj);

                            if (_obj != null)
                            {
                                resultado.resultado = true;
                                resultado.mensaje = "Registros guardados correctamente";
                            }
                        }
                        else
                        {
                            resultado.resultado = false;
                            resultado.mensaje = "Error en el Modelo de Datos";
                        }
                    }
                    else
                    {
                        resultado.resultado = false;
                        resultado.mensaje = "El codigo no pueder ser nulo";
                    }
                }
                else
                {
                    resultado.resultado = false;
                    resultado.mensaje = "El objeto esperado no puede ser nulo";
                }
            }
            catch (Exception e)
            {
                resultado.resultado = false;
                resultado.mensaje = e.InnerException != null ? e.InnerException.Message : e.Message;
            }

            if (resultado.resultado)
            {
                return Ok(JsonConvert.SerializeObject(resultado));
            }
            else
            {
                return BadRequest(JsonConvert.SerializeObject(resultado));
            }
        }

        //PUT api/Reservas/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Reservas obj)
        {
            Result resultado = new Result();

            try
            {
                if (String.IsNullOrEmpty(id.ToString()) || id <= 0)
                {
                    return BadRequest(new { mensaje = "El id del objeto no es válido" });
                }

                if (obj != null)
                {
                   
                    Reservas _obj = await _rservice.GetById(id);

                    if (_obj != null)
                    {
                        _obj.AeropuertoOrigen = obj.AeropuertoOrigen;
                        _obj.HorarioSalida = obj.HorarioSalida;
                        _obj.AeropuertoLlegada = obj.AeropuertoLlegada;
                        _obj.HorarioLlegada = obj.HorarioLlegada;
                        _obj.Aerolinea = obj.Aerolinea;
                        _obj.NumeroVuelo = obj.NumeroVuelo;
                        _obj.TipoPasajero = obj.TipoPasajero;
                        _obj.Precio = obj.Precio;

                        if (ModelState.IsValid)
                        {
                            Reservas _objAct = await _rservice.Update(_obj);

                            if (_objAct != null)
                            {
                                resultado.resultado = true;
                                resultado.mensaje = "Registros actualizados correctamente";
                            }
                        }
                        else
                        {
                            resultado.resultado = false;
                            resultado.mensaje = "Error en el modelo de datos";
                        }
                    }
                    else
                    {
                        resultado.resultado = false;
                        resultado.mensaje = "Objeto no encontrado";
                    }
                }
                else
                {
                    resultado.resultado = false;
                    resultado.mensaje = "El objeto esperado no puede ser nulo";
                }
            }
            catch (Exception e)
            {
                resultado.resultado = false;
                resultado.mensaje = e.InnerException != null ? e.InnerException.Message : e.Message;
            }

            if (resultado.resultado)
            {
                return Ok(JsonConvert.SerializeObject(resultado));
            }
            else
            {
                return BadRequest(JsonConvert.SerializeObject(resultado));
            }
        }

        
    }
}
