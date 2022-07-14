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
    internal class CLienteRepository<TEntity> : IClienteRepository<TEntity> where TEntity : IAggregateRoot
    {
        protected DbSilasContext _clienteContext;

        public CLienteRepository(DbSilasContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        public IUnitOfWork UnitOfWork => new UnitOfWork.UnitOfWork(_clienteContext);

        public async Task Add(TEntity entity, CancellationToken cancellationToken = default) => await _clienteContext.AddAsync(entity, cancellationToken);

        public async Task AddRange(TEntity entity, CancellationToken cancellationToken = default) => await _clienteContext.AddRangeAsync(entity, cancellationToken);


        public void Delete(TEntity entity) => _clienteContext.Remove(entity);


        public void Dispose()
        {
            GC.Collect();
        }

        public async Task<IQueryable<TData>> GetAll<TData>() where TData : Base
        {
            DbSet<TData> _clienteDb = _clienteContext.Set<TData>();
            return await Task.FromResult(_clienteDb.AsQueryable<TData>());
        }

        public async Task<TData> GetById<TData>(Guid Id) where TData : Base
        {
            DbSet<TData> _clienteDb = _clienteContext.Set<TData>();
            return await _clienteDb.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync() ?? throw (new Exception("Nenhuma informação encontrada"));
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(HashSet<TEntity> entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
