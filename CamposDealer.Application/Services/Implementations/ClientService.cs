﻿using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using CamposDealer.Application.ViewModels;
using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Repositories;

namespace CamposDealer.Application.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> Create(CreateClientInputModel model)
        {
            ClientEntity client = new ClientEntity(
                model.City,
                model.Name
                );

            await _clientRepository.Create(client);

            return client.Id;
        }

        public async Task<int> Delete(int clientId)
        {
            return await _clientRepository.Delete(clientId);
        }

        public async Task<CollectionClientViewModel> GetAll()
        {
            var clients = await _clientRepository.GetAll();
            var clientsViewModels = new CollectionClientViewModel(clients);
            return clientsViewModels;
        }

        public async Task<ClientViewModel> GetById(int id)
        {
            var client = await _clientRepository.GetById(id);

            if (client == null)
            {
                return null;
            }

            return new ClientViewModel(client);
        }

        public async Task<int> Update(UpdateClientInputModel model)
        {
            var oldModel = await GetById(model.Id);

            ClientEntity client = new ClientEntity(
                model.City,
                model.Name
                );

            return await _clientRepository.Update(client);
        }
    }
}