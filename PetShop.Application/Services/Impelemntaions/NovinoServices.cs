using Newtonsoft.Json;
using PetShop.Application.Services.Interfaces;
using PetShop.Domain.ViewModels.DTOs.NovinoPay;
using System.Text;

namespace PetShop.Application.Services.Impelemntaions
{
    public class NovinoServices : INovinoServises
    {
        public async Task<NovinoPayGetUrlResponseDTOs> CreateNovinoRequest(NovinoPayGetUrlRequestDTOs model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string body = JsonConvert.SerializeObject(model);
                HttpContent Content = new StringContent(body, Encoding.UTF8, "application/json");
                var respone = await httpClient.PostAsync(
                    "https://api.novinopay.com/payment/ipg/v2/request", Content);

                string responContent = await respone.Content.ReadAsStringAsync();

                var finalResultRespon = JsonConvert.DeserializeObject<NovinoPayGetUrlResponseDTOs>(responContent);
                return finalResultRespon;
            }
        }

        public async Task<NovinoPayVerifyResponseDTOs> VerifyNonvino(NovinoPayVerifyRequestDTOs model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string body = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

                var respone = await httpClient.PostAsync("https://api.novinopay.com/payment/ipg/v2/verification"
                    , content);
                string contentResponse = await respone.Content.ReadAsStringAsync();
                var finlallResult = JsonConvert.DeserializeObject<NovinoPayVerifyResponseDTOs>(contentResponse);
                return finlallResult;
            }
        }
    }
}