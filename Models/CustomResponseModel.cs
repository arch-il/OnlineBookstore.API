namespace OnlineBookstore.API.Models
{
    public class CustomResponseModel <T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
