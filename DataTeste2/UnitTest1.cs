using Domain.Entity;
using Domain.Entity.Util;
using NUnit.Framework;
using Assert = Xunit.Assert;

namespace DataTeste2
{
    public class UnitTest1
    {
        Data.Context.DbSilasContext _db;
        Data.Context.DbSilasContext _cliente;
        Repository.Util.LoggerRepository _loggerRepository;
        Repository.CLienteRepository _clienteRepository;

        public UnitTest1()
        {
            _db = new Data.Context.DbSilasContext();
            _loggerRepository = new Repository.Util.LoggerRepository(_db);
            _cliente = new Data.Context.DbSilasContext();
            _clienteRepository = new Repository.CLienteRepository(_cliente);

        }

        //[SetUp]
        //public void SetUp()
        //{

        //}

        #region TestesLogger

        
        [Fact]
        public void GetAll()
        {
            var get = _loggerRepository.GetAll();
            Assert.True(get.IsCompleted);
        }
        [Fact]
        public void GetById()
        {
            var get = _loggerRepository.GetAll().Result.Where(x => x.Id == Guid.Parse("E3C71376-73AA-44EA-174A-08DA647665CA")).FirstOrDefault();
            Assert.True(get.Id.ToString().ToUpper() == "E3C71376-73AA-44EA-174A-08DA647665CA");
        }

        [Fact]
        public void AddLog()
        {
            var result = _loggerRepository.SetLogger(new Logger
            {

                ApplicationOwner = "Silas",
                DateTime = DateTime.Now,
                Ambient = "dev",
                ApplicationName = "DataTeste2",
                ApplicationVersion = "1.0.0.0",
                CallerMemberName = "SetLogger",
                Description = "Teste",
                EventId = 0,
                Exception = null,
                InnerException = null,
                Line = 1,
                Server = "SilasPc",
                Stack = null,
                Type = 1
            });
            Assert.True(result.IsCompleted);
        }
        #endregion


        #region ClienteTeste
        [Fact]
        public void Add()
        {
            var result = _clienteRepository.Add(new Cliente
            {

                Codigo = 12760,
                RazaoSocial = "Casa de carnes boi gordo",
                UltimaCompra = "2019-07-19",
                Valor = 9000.00,
                Telefone = "12 97564-1235",
                Telefone2 = "12 3536-4010",
                Email = "boigordo@gmail.com",
                Cidade = "Cambui",
                Bairro = "tulipa"

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

        #endregion

        
    }
}