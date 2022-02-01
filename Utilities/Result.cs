using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAeropuerto.Utilities
{
    public class Resultado<T> : Result
    {
        public List<T> datos { get; set; }
    }

    public class Result
    {
        public bool resultado { get; set; }
        public string mensaje { get; set; }
    }
}
