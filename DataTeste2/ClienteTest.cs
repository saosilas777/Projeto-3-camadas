using Data.Context;
using Domain.Entity;
using Assert = Xunit.Assert;

namespace DataTeste2
{
    public class ClienteTest
    {
        DbSilasContext _cliente =  new DbSilasContext();
        Repository.CLienteRepository _clienteRepository;

        public ClienteTest()
        {
           
            _clienteRepository = new Repository.CLienteRepository(_cliente);
        }

        [Fact]
        public void Add()
        {
            var result = _clienteRepository.Add(new Cliente
            {

                Codigo = 12590,
                RazaoSocial = "TacoBell 2 ",
                UltimaCompra = "2020-09-01",
                Valor = 10000.00,
                Telefone = "11 2279-1235",
                Telefone2 = "11 96058-4010",
                Email = "tacobell@gmail.com",
                Cidade = "São Paulo",
                Bairro = "Moema"

            });
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void GetAllCliente()
        {
            var get = _clienteRepository.GetAll();
            Assert.True(get.IsCompleted) ;
        }

        [Fact]
        public void DeleteCliente()
        {
            var cliente = _clienteRepository.GetAll().Result.Where(x => x.Codigo == 12760 ).FirstOrDefault();
            _clienteRepository.Delete(cliente);
        }

        
    }
}