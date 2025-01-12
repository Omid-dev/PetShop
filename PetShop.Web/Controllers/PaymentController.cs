using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PetShop.Application.Services.Interfaces;
using PetShop.Domain.ViewModels;
using PetShop.Domain.ViewModels.DTOs.NovinoPay;

namespace PetShop.Web.Controllers
{
    public class PaymentController(INovinoServises novinoServices,
        IOrderServises orderServices, IOrderDetailServises orderDetailServises) : Controller
    {
        [Authorize]
        public async Task<IActionResult> StrartPay(int orderId)
        {
            var order = await orderServices.GeById(orderId);
            int amount = await orderDetailServises.SumAmountByOrderId(orderId);

            NovinoPayGetUrlRequestDTOs novinoPayGetUrlRequest = new NovinoPayGetUrlRequestDTOs()
            {
                Amount = amount * 10,
                CallBackUrl = "http://petshop-home.ir/payment/EndPay",
                MerchantId = "test",
                Callback_Method = "POST",
                Card_Pan = "",
                Description = "پرداخت سبد خرید پت شاپ",
                Email = order.User.Email,
                Invoice_Id = order.Id.ToString(),
                Mobile = order.User.PhoneNumber,
                Name = order.User.Name,
            };
            var finalResultRespon = await novinoServices.CreateNovinoRequest(novinoPayGetUrlRequest);

            if (finalResultRespon != null && finalResultRespon.Status == "100")
            {
                return Redirect(finalResultRespon.Data.Payment_Url);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> EndPay(string paymentStatus, string invoiceID, string authority)
        {
            if (!string.IsNullOrEmpty(paymentStatus) && paymentStatus.ToLower() == "ok")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var order = await orderServices.GeById(int.Parse(invoiceID));

                    int sum = await orderDetailServises.SumAmountByOrderId(int.Parse(invoiceID));
                    NovinoPayVerifyRequestDTOs novinoPayVerify = new NovinoPayVerifyRequestDTOs()
                    {
                        Amout = sum * 10,
                        Authority = authority,
                        MerchantId = "test"
                    };
                    var finlallResult = await novinoServices.VerifyNonvino(novinoPayVerify);
                    if (finlallResult != null && finlallResult.Status == "100")
                    {
                        order.IsFinally = true;
                        await orderServices.Update(order);
                        await orderServices.SaveAsync();
                        return View("ResultPayment", new PaymentViewModel
                        {
                            Message = "پرداخت با موفقیت انجام شد ",
                            Status = Result.Success,
                            RefId = authority
                            
                        });
                       
                    }
                    else
                    {
                        return View("ResultPayment", new PaymentViewModel
                        {
                            Message = "پرداخت با شکست مواجه شد",
                            RefId = "15y64x",
                            Status = Result.Erorr
                        });
                    }
                }
            }
            else
            {
                return View("ResultPayment", new PaymentViewModel
                {
                    Message = "پاسخی از بانک دریافت نشد",
                    RefId = "null",
                    Status = Result.Erorr
                });
            }
        }
    }
}