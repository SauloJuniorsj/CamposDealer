using CamposDealer.Application.Services.Implementations;
using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class SaleJsonInputModel
    {
        public int idVenda { get; set; }
        public string dthVenda { get; set; }
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public int qtdVenda { get; set; }
        public int vlrUnitarioVenda { get; set; }
    }
}
