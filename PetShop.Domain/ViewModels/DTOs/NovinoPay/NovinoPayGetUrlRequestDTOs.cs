using Newtonsoft.Json;

namespace PetShop.Domain.ViewModels.DTOs.NovinoPay
{
    public class NovinoPayGetUrlRequestDTOs
    {
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("callback_url")]
        public string CallBackUrl { get; set; }

        [JsonProperty("callback_method")]
        public string Callback_Method { get; set; }

        [JsonProperty("invoice_id")]
        public string Invoice_Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("card_pan")]
        public string Card_Pan { get; set; }
    }
}