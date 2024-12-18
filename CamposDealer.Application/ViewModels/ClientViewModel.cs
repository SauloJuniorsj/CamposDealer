using CamposDealer.Domain.Entities;
using System.ComponentModel;

namespace CamposDealer.Application.ViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel(ClientEntity model)
        {
            if (model == null)
            {
                return;
            }

            Id = model.Id;
            Name = model.Name;
            City = model.City;
        }

        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Cidade")]
        public string City { get; set; }
    }
}
