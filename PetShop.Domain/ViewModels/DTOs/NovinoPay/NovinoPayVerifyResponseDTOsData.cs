using Newtonsoft.Json;

namespace PetShop.Domain.ViewModels.DTOs.NovinoPay
{
    public class NovinoPayVerifyResponseDTOsData
    {
        [JsonProperty("trans_id")]
        public string Trans_Id { get; set; }

        [JsonProperty("ref_id")]
        public string RefId { get; set; }

        [JsonProperty("authority")]
        public string Authority { get; set; }

        [JsonProperty("card_pan")]
        public string Card_Pan { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("invoice_id")]
        public string Invoice_Id { get; set; }

        [JsonProperty("buyer_ip")]
        public string Buyer_IP { get; set; }

        [JsonProperty("payment_time")]
        public string Payment_Time { get; set; }
    }
}