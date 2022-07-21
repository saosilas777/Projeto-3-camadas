using Data.Context;
using Domain.Entity;
using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        protected DbSilasContext _users;
        public UsersRepository(DbSilasContext users) : base(users)
        { 
                _users = users;
        }

        //public void Delete(Users user)
        //{
        //    _users.Remove(user);
        //    _users.SaveChanges();
        //}

        public async Task<HashSet<Users>> GetAll()
        {
            var x = (from l in _db.Users select l).AsEnumerable().ToHashSet();
            return x;
        }

        public Task<TData> GetById<TData>(Guid Id) where TData : Base
        {
            throw new NotImplementedException();
        }
        
        public async Task<Users>? GetByUserName(string userName )
        {
            var user = _users.Users.FirstOrDefault(l => l.UserName == userName);
            return Task.FromResult(user).Result;
        }

        public async Task Insert(Users user)
        {
            _users.Add(user);
            _users.SaveChanges();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
