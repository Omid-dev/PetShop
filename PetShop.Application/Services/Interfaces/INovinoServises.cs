using PetShop.Domain.ViewModels.DTOs.NovinoPay;

namespace PetShop.Application.Services.Interfaces
{
    public interface INovinoServises
    {
        Task<NovinoPayGetUrlResponseDTOs> CreateNovinoRequest(NovinoPayGetUrlRequestDTOs model);

        Task<NovinoPayVerifyResponseDTOs> VerifyNonvino(NovinoPayVerifyRequestDTOs model);
    }
}