using Domain.Entity.Util;
using NUnit.Framework;
using Assert = Xunit.Assert;

namespace DataTeste2
{
    public class UnitTest1
    {
        Data.Context.DbSilasContext _db;
        Repository.Util.LoggerRepository _loggerRepository;

        public UnitTest1()
        {
            _db = new Data.Context.DbSilasContext();
            _loggerRepository = new Repository.Util.LoggerRepository(_db);
        }

        //[SetUp]
        //public void SetUp()
        //{
            
        //}


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