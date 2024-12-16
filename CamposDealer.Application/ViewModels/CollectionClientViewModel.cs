using CamposDealer.Domain.Entities;

namespace CamposDealer.Application.ViewModels
{
    public class CollectionClientViewModel
    {
        public List<ClientViewModel> CollectionClient { get; set; }

        public CollectionClientViewModel(List<ClientEntity> collection)
        {
            CollectionClient = new List<ClientViewModel>();

            CollectionClient = collection.Select(x => new ClientViewModel(x)).ToList();
        }
    }
}