using NUnit.Framework;
using System;

namespace Silas.Service.Person.Teste
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var persons = new Persons.Services.PersonServices();
            var result = persons.Create(new Persons.DTO.PersonDTO
            {
                Nome = "Silas",
                Telefone = "982199667",
                Nascimento = DateTime.Parse("1987-01-22")

            });
            var result3 = persons.Create(new Persons.DTO.PersonDTO
            {
                Nome = "Stan",
                Telefone = "999999999",
                Nascimento = DateTime.Parse("1981-08-03")

            });

            var result2 = persons.Get(result3);


            Assert.IsTrue(result2.Nome == "Silas");
        }
    }
}