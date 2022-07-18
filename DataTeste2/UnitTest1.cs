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
            Assert.True(get.Result.Count == 2);
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


        [Fact]
        public void Add()
        {
            var result = _clienteRepository.Add(new Cliente
            {
                
                Codigo = 30820,
                RazaoSocial = "HELLWIG MATERIAIS DE CONSTRUCAO LTDA",
                UltimaCompra = "2022-02-23",
                Valor = 821.00,
                Telefone = "53 3221-5615",
                Telefone2 = "",
                Email = "megafixadores@gmail.com",
                Cidade = "Pelotas",
                Bairro = "Centro"

            });
            Assert.True(result.IsCompleted);
        }

        //TODO
        // criar entidade na domain
        // criar novo Dbset no dbsilascontext
        // criar MAP do dbset
        // criar respositorio da nova entidade (#repositorio/util/)
        //nova migration
        //update
        //criar novos testes
    }
}