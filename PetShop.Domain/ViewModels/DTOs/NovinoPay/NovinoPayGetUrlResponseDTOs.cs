using Newtonsoft.Json;

namespace PetShop.Domain.ViewModels.DTOs.NovinoPay
{
    public class NovinoPayGetUrlResponseDTOs
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public NovinoPayGetUrlDataResponseDTOs Data { get; set; }

        [JsonProperty("errors")]
        public object Error { get; set; }
    }

    public class NovinoPayGetUrlDataResponseDTOs
    {
        [JsonProperty("wage")]
        public int Wage { get; set; }

        [JsonProperty("wage_payer")]
        public string Wage_Payer { get; set; }

        [JsonProperty("authority")]
        public string Authority { get; set; }

        [JsonProperty("trans_id")]
        public int Trans_Id { get; set; }

        [JsonProperty("payment_url")]
        public string Payment_Url { get; set; }
    }
}