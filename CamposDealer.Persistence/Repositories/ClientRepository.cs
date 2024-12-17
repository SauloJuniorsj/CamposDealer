using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Exceptions;
using CamposDealer.Domain.Repositories;
using CamposDealer.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CamposDealer.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CamposDealerContext _db;
        public ClientRepository(CamposDealerContext context)
        {
            _db = context;
        }

        public async Task<int> Create(ClientEntity model)
        {
            try
            {
                _db.Clients.Add(model);

                await _db.SaveChangesAsync();

                return model.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar Cliente", ex);
            }
        }

        public async Task<int> Delete(int clientId)
        {
            try
            {
                var client = await GetById(clientId);

                if (client == null)
                {
                    throw new DomainLogicException(ErrorConstants.CannotGetClient);

                }

                _db.Clients.Remove(client);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public async Task<List<ClientEntity>> GetAll(string query)
        {

            var queryClient = _db.Clients
                .AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                queryClient = queryClient.Where(x => x.Name.Contains(query));
            }

            return await queryClient.ToListAsync();
        }

        public async Task<ClientEntity> GetById(int id)
        {
            try
            {
                var client = await _db.Clients
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (client is null)
                {
                    throw new DomainLogicException(ErrorConstants.CannotGetClient + id);
                }

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> Update(ClientEntity model)
        {
            try
            {
                var trackedEntity = _db.Clients.Local.FirstOrDefault(x => x.Id == model.Id);

                _db.Clients.Update(model);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
