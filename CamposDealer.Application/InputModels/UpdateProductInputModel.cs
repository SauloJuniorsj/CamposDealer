using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class UpdateProductInputModel
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required float ProductValue { get; set; }
    }
}
