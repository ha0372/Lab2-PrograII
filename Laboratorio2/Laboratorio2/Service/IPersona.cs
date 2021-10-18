using Laboratorio2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Service
{
    public interface IPersona
    {
        ICollection<persona> listardatos();

        void Save(persona p);


    }
}
