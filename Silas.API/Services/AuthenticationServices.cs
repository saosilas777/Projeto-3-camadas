using Data.Context;
using Silas.API.Models;
using System;
using Repository;

namespace Silas.API.Services
{
    public class AuthenticationServices
    {
        DbSilasContext _users = new DbSilasContext();
        UsersRepository _usersRepository;

        public AuthenticationServices()
        {
            _usersRepository = new UsersRepository(_users);
        }
        public bool AuthenticationUser(UserModels user)
        {
            if (string.IsNullOrEmpty(user.Nome) || string.IsNullOrEmpty(user.Senha))
                throw new Exception("Usuario e senha não podem estar vazios");

            var _user = _usersRepository.GetByUserName(user.Nome).Result;
            if (_user == null)
                throw new Exception("Usuario não encontrado no banco de dados");
            if (user.Senha != _user.Password)
                throw new Exception("Senha inválida");
            return true;

        }
    }
}
