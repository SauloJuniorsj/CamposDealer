namespace CamposDealer.Application.Services.Interfaces
{
    public interface IApiService
    {
        Task<List<T>> GetAsync<T>(string url);
    }
}
