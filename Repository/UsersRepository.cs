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
        protected DbSilasContext _Users;
        public UsersRepository(DbSilasContext users) : base(users)
        { 
        }

        public void Delete(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TData>> GetAll<TData>() where TData : Base
        {
            throw new NotImplementedException();
        }

        public Task<TData> GetById<TData>(Guid Id) where TData : Base
        {
            throw new NotImplementedException();
        }

        public Task Insert(Users user)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
