using Microsoft.AspNetCore.Mvc;
using Silas.Service.Persons.Services;
using Silas.Service.Persons.DTO;
using Silas.Service.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Silas.API.Controllers.Persons
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPerson _person;
        public PersonsController(IPerson person)
        {
            _person = person;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}




        [HttpPost("Create")]
        public async Task<object> Create([FromBody] PersonDTO person)
        {
            var result = _person.Create(person);
            return await Task.FromResult(result);
        }

        
        [HttpGet("GetPerson")]
        public async Task<object> GetPerson(string id)
        {
            var get = _person.Get(Guid.Parse(id));
            return await Task.FromResult(get);
        }

        [HttpGet("DeletePerson")]
        public async Task<object> DeletePerson(string id)
        {
            var delete = _person.Delete(Guid.Parse(id));
            return await Task.FromResult(delete);
        }


        [HttpGet("All")]
        public async Task<object> All()
        {
            var all = _person.PersonListAll();
            return await Task.FromResult(all);
        }

        [HttpGet("GetByYear")]
        public async Task<object> GetByYear(string year)
        {
            var persons = PersonFilters.GetByYear(_person.PersonListAll(), year);
            return await Task.FromResult(persons);
        }

        [HttpGet("GetByName")]
        public async Task<object> GetByName(string nome)
        {
            var persons = PersonFilters.GetByName(_person.PersonListAll(), nome);
            return await Task.FromResult(persons);
        }

        [HttpGet("GetByPhone")]
        public async Task<object> GetByPhone(string phone)
        {
            var persons = PersonFilters.GetByPhone(_person.PersonListAll(), phone);
            return await Task.FromResult(persons);
        }

    }
}
