namespace CamposDealer.Application.Services.Interfaces
{
    public interface IApiService
    {
        Task<T> GetAsync<T>(string url);
        DateTime ParseDate(string jsonDate);
    }
}
