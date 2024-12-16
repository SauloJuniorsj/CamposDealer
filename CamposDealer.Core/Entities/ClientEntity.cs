namespace CamposDealer.Domain.Entities
{
    public class ClientEntity
    {
        public ClientEntity(string name, string city)
        {
            Name = name;
            City = city;
        }

        public ClientEntity(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
