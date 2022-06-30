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
        
        public List<PersonDTO> PersonListAll()
        {
            var p = PersonList.list;
            var personList = new List<PersonDTO>(); 

            foreach (var person in p)
            {
                personList.Add(new PersonDTO { Id = person.Id, Nome = person.Nome, Nascimento = person.Nascimento, Telefone = person.Telefone });
            }
            return personList;
        }
        

        public bool Update(PersonDTO person)
        {
            throw new NotImplementedException();
        }


        //TODO
        //Tirar filtro da API e levar para camada de serviços
        //Criar novo metodo na camada serviço com base no metodo filterPerson por year, filtrando por nome e outro por fone
        //criar metodo(em servicos e chamar na api) de deletar um objeto da lista de pessoas.
    }
}
