using Silas.Service.Persons.DTO;
using Silas.Service.Persons.Helpers;
using Silas.Service.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silas.Service.Persons.Services
{
    public class PersonServices : IPerson
    {
        public Guid Create(PersonDTO person)
        {
            var persons = new PersonHelpers
            {
                Id = Guid.NewGuid(),
                Nome = person.Nome,
                Telefone = person.Telefone,
                Nascimento = person.Nascimento,

            };
            PersonList.list.Add(persons);
            return persons.Id;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PersonDTO Get(Guid id)
        {
            var p = PersonList.list.Where(x => x.Id == id).FirstOrDefault();
            var person = new PersonDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Telefone = p.Telefone,
                Nascimento = p.Nascimento

            };
            return person;
        }

        public bool Update(PersonDTO person)
        {
            throw new NotImplementedException();
        }
    }
}
