using Laboratorio2.Data;
using Laboratorio2.Entidades;
using Laboratorio2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Repository
{
    public class PersonRepository : IPersona
    {
        private ApplicationDbContext appDb;

        public PersonRepository(ApplicationDbContext appDb)
        {
            this.appDb = appDb;
        }

        public ICollection<persona> listardatos()
        {
            return appDb.persona.ToList();
        }

        public void Save(persona p)
        {
            appDb.Add(p);
            appDb.SaveChanges();
        }
    }
}
