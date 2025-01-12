using Newtonsoft.Json;

namespace PetShop.Domain.ViewModels.DTOs.NovinoPay
{
    public class NovinoPayVerifyResponseDTOs
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public object Errors { get; set; }

        [JsonProperty("data")]
        public NovinoPayVerifyResponseDTOsData Data { get; set; }
    }
}