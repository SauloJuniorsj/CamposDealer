using CamposDealer.Domain.Entities;

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
        public string Name { get; set; }
        public string City { get; set; }
    }
}
