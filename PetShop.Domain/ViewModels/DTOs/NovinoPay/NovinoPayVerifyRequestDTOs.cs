using Newtonsoft.Json;

namespace PetShop.Domain.ViewModels.DTOs.NovinoPay
{
    public class NovinoPayVerifyRequestDTOs
    {
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("amount")]
        public int Amout { get; set; }

        [JsonProperty("authority")]
        public string Authority { get; set; }
    }
}