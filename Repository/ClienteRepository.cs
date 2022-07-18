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
        protected DbSilasContext _clienteContext;

        public CLienteRepository(DbSilasContext clienteContext) : base(clienteContext)
        {
            _clienteContext = clienteContext;
        }
        public async Task Add(Cliente cliente)
        {
           _clienteContext.Add(cliente);
           _clienteContext.SaveChanges();
        }


        public Task AddRange()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
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

