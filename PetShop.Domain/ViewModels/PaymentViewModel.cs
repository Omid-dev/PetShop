namespace PetShop.Domain.ViewModels
{
    public enum Result
    {
        Success,
        Erorr
    }

    public class PaymentViewModel
    {
        public string Message { get; set; }
        public string RefId { get; set; }
        public Result Status { get; set; }
    }
}