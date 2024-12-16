namespace CamposDealer.Application.ViewModels
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public ErrorResponseModel()
        {

        }
        public ErrorResponseModel(string message)
        {
            Message = message;
        }
    }
}
