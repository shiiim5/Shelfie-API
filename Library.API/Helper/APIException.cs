namespace Library.API.Helper
{
    public class APIException : ResponseAPI
    {
        public string Details { get; set; }
        public APIException(int statusCode, string? message = null,string details = null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}
