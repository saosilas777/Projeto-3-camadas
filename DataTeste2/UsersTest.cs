using Data.Context;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;

namespace DataTeste2
{
    public class UsersTest
    {
        DbSilasContext _users = new DbSilasContext();
        UsersRepository _usersRepository;

        public UsersTest()
        {
            _usersRepository = new UsersRepository(_users);
        }

        [Fact]
        public void Add()
        {
            var result = _usersRepository.Insert(new Users
            {
                UserName = "Silas",
                Password = "102030",
                Scope = "master",
                Role = "Developer",
                CreateDate = new DateTime(2022, 07, 20),
                LastModifiedDate = new DateTime(2022, 07, 20),
                IsActive = true,


            });
            Assert.True(result.IsCompleted);
        }

        [Fact]

        public void GetAll()
        {
            var get = _usersRepository.GetAll();
            Assert.True(get.IsCompleted);

        }

        [Fact]
        public void Remove()
        {
            var user = _usersRepository.GetAll().Result.Where(x => x.UserName == "Silas").FirstOrDefault();
            _usersRepository.Delete(user);

        }


    }
}
