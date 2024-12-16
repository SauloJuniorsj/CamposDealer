using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class UpdateClientInputModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
    }
}
