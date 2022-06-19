namespace WebAPIDemo.Models
{
    public class MainResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}
