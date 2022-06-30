using Microsoft.AspNetCore.Mvc;
using Silas.API.Filters;
using Silas.Service.Persons.DTO;
using Silas.Service.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Silas.API.Controllers.Persons
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPerson _person;
        public PersonsController(IPerson person)
        {
            _person = person;

        }
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Metodo para criar novo usuario
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("Create")]

        public async Task<object> Create([FromBody] PersonDTO person)
        {
            var result = _person.Create(person);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Metodo para recuperar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPerson")]
        public async Task<object> GetPerson(string id)
        {
            var get = _person.Get(Guid.Parse(id));
            return await Task.FromResult(get);
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
            var persons = PersonFilters.personFilter( _person.PersonListAll(), year);
            return await Task.FromResult(persons);
        }

    }
}
