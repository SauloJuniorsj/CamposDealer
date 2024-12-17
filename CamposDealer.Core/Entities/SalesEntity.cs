namespace CamposDealer.Domain.Entities
{
    public class SalesEntity
    {
        public SalesEntity()
        {
            
        }
        public SalesEntity(int id, int idClient, int idProduct, int salesQtd, float valueUnitValue, float totalSaleValue)
        {
            Id = id;
            IdClient = idClient;
            IdProduct = idProduct;
            SalesQtd = salesQtd;
            ValueUnitValue = valueUnitValue;
            TotalSaleValue = totalSaleValue;
        }

        public SalesEntity(int idClient, int idProduct, int salesQtd, float valueUnitValue, DateTime saleDatetime, float totalSaleValue)
        {
            IdClient = idClient;
            IdProduct = idProduct;
            SalesQtd = salesQtd;
            ValueUnitValue = valueUnitValue;
            SaleDatetime = saleDatetime;
            TotalSaleValue = totalSaleValue;
        }

        public SalesEntity(int idClient, int idProduct, int salesQtd, float valueUnitValue, DateTime saleDatetime)
        {
            IdClient = idClient;
            IdProduct = idProduct;
            SalesQtd = salesQtd;
            ValueUnitValue = valueUnitValue;
            SaleDatetime = saleDatetime;
            TotalSaleValue = salesQtd * valueUnitValue;
        }

        public int Id { get; set; }
        public int IdClient { get; set; }  
        public int IdProduct { get; set; }  
        public int SalesQtd { get; set; }
        public float ValueUnitValue { get; set; }
        public DateTime SaleDatetime { get; set; }
        public float TotalSaleValue { get; set; }

        public virtual ClientEntity Client { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
