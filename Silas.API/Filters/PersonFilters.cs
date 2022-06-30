using Silas.Service.Persons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silas.API.Filters
{
    public static class PersonFilters
    {
      
        public static List<PersonDTO> personFilter(List<PersonDTO> personDTOs, string year)
        {
           return personDTOs.Where(x => x.Nascimento.Year.ToString() == year).ToList();

        }
    }
}
