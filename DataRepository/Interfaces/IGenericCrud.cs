using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.DataRepository.Interfaces
{
    public interface IGenericCrud<T> where T : class
    {
        //Obtener todos los registros
        Task<List<T>> GetAll();

        //Obtener un registro por su Id
        Task<T> GetById(long id);

        //Agregar un nuevo regsitro
        Task<T> Add(T entidad);

        //Editar un registro
        Task<T> Update(T entidad);

        //Eliminar un regsitro por si Id
        Task<bool> DeleteById(long id);
    }
}
