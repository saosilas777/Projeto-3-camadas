using Data.Context;
using Domain.Entity;
using Domain.Interface.Configurations;
using Domain.Interface.Repository;
using Domain.Interface.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CLienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public DbContext _clienteContext;
        public CLienteRepository(DbSilasContext clienteContext) : base(clienteContext)
        {
            _clienteContext = clienteContext;
        }
        public async Task Add(Cliente cliente)
        {
            _clienteContext.Add(cliente);
            _clienteContext.SaveChanges();
        }

        public async Task<HashSet<Cliente>> GetAll()
        {
            var x = (from l in _db.Cliente select l).AsEnumerable().ToHashSet();
            return x;
        }

        public Task AddRange()
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente cliente)
        {
            _clienteContext.Remove(cliente);
            _clienteContext.SaveChanges();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void UpdateRange()
        {
            throw new NotImplementedException();
        }
    }




}

