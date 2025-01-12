using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Services.Impelemntaions;
using PetShop.Application.Services.Interfaces;
using PetShop.Application.Utility;
using PetShop.Domain.Models.Orders;
using PetShop.Domain.Models.Users;
using PetShop.Domain.ViewModels;

namespace PetShop.Web.Controllers
{
    [Authorize]
    public class OrderController(
        IUserServices userServices,
        IProductServices productServices,
        IOrderServises orderServises,
        IOrderDetailServises orderDetailServises,
        IUserDetailServices userDetailServices) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddOrder(int id)
        {
            if (id == 0)
            {
                return View("_Error");
            }
            else
            {
                var userLogin = await userServices.GetByIdAsync(User.GetUserId());

                var product =  productServices.GetById(id);
                var OrderUser = await orderServises.GetByUserId(User.GetUserId());
                //var orderr = _context.Order.Where(o => o.User.Id == User.GetUserId()).FirstOrDefault();

                if (OrderUser == null)
                {
                    Order order = new Order()
                    {
                        CreateDate = DateTime.Now,
                        IsDeleted = false,
                        UserId = User.GetUserId(),
                    };
                    await orderServises.Add(order);
                    await orderServises.SaveAsync();

                    var orderDetail = new OrderDetail()
                    {
                        CreateDate = DateTime.Now,
                        IsDeleted = false,
                        OrderId = order.Id,
                        Price = product.Price,
                        ProdcutId = id,
                        Count = 1
                    };
                    await orderDetailServises.Add(orderDetail);

                    await orderDetailServises.SaveAsync();
                }
                else
                {
                    var orderDetailUser = await orderDetailServises.GetByOrderId(OrderUser.Id);
                    {
                        var again = orderDetailUser.Any(od => od.ProdcutId == id);

                        if (again)
                        {
                            foreach (var item in orderDetailUser)
                            {
                                if (item.ProdcutId == id)
                                {
                                    item.Count++;
                                    await orderDetailServises.SaveAsync();
                                }
                            }
                        }
                        else
                        {
                            var orderDetail = new OrderDetail()
                            {
                                CreateDate = DateTime.Now,
                                IsDeleted = false,
                                OrderId = OrderUser.Id,
                                Price = product.Price,
                                ProdcutId = id,
                                Count = 1
                            };
                            await orderDetailServises.Add(orderDetail);
                            await orderDetailServises.SaveAsync();
                        }
                    }

                    await orderDetailServises.SaveAsync();
                }
                return RedirectToAction("ShowOrderDetails");
            }
        }

        public async Task<IActionResult> ShowOrderDetails()
        {
            var Order = await orderServises.GetByUserId(User.GetUserId());
            if (Order == null)
            {
                Order = new Order();
            }
            return View(Order);
        }

        public async Task AddCount(int id)
        {
            var orderid = await orderServises.GetByUserId(User.GetUserId());
            var prodcut = await orderDetailServises.GetByProdcutIdANDOrderId(id, orderid.Id);
            prodcut.Count++;
            await orderDetailServises.SaveAsync();
        }

        public async Task ReduceCount(int id)
        {
            var orderid = await orderServises.GetByUserId(User.GetUserId());
            var prodcut = await orderDetailServises.GetByProdcutIdANDOrderId(id, orderid.Id);
            if (prodcut?.Count > 1)
            {
                prodcut.Count--;
            }
            await orderDetailServises.SaveAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var orderid = await orderServises.GetByUserId(User.GetUserId());
            var prodcut = await orderDetailServises.GetByProdcutIdANDOrderId(id, orderid.Id);
            if (prodcut?.Count <= 1)
            {
                await orderDetailServises.Delete(prodcut);
            }
            await orderDetailServises.SaveAsync();
        }

        public async Task<IActionResult> DetailOrder()
        {
            var orderid = await orderServises.GetByUserId(User.GetUserId());
            var orderDetails = await orderDetailServises.GetByOrderId(orderid.Id);
            var orderDetailMap = orderDetails.Select(od => new ShowOrderViewModel()
            {
                Price = od.Price * od.Count,
                ProductName = od.Product.Name
            }).ToList();
            TempData["ShowOrder"] = orderDetailMap;
            var user = await userServices.GetByIdAsync(User.GetUserId());
            var userDetail = await userDetailServices.GetUserDetailByUserId(User.GetUserId());
            DetailUserViewModel detailUserViewModel = new DetailUserViewModel()
            {
                ApartmentName = userDetail?.ApartmentName,
                City = userDetail?.City,
                Email = user.Email,
                Family = user.Family,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                State = userDetail?.State,
                Street = userDetail?.Street,
                UserId = user.Id,
                Zip_Code = userDetail?.Zip_Code
            };
            return View(detailUserViewModel);
        }

        public async Task<IActionResult> OrderFinally(DetailUserViewModel detailUser)
        {
            TempData["ShowOrder"] = TempData["ShowOrder"];
            if (!ModelState.IsValid)
                return View("DetailOrder", detailUser);
            var orderid = await orderServises.GetByUserId(User.GetUserId());
            var user = await userServices.GetByIdAsync(User.GetUserId());
            var userDetail = await userDetailServices.GetUserDetailByUserId(User.GetUserId());
            user.CreateDate = user.CreateDate;
            user.IsAdmin = user.IsAdmin;
            user.Name = detailUser.Name;
            user.PhoneNumber = detailUser.PhoneNumber;
            user.Family = detailUser.Family;
            user.Email = detailUser.Email;
            user.ModifiedDate = DateTime.Now;
            if (userDetail != null)
            {
                userDetail.Street = detailUser.Street;
                userDetail.State = detailUser.State;
                userDetail.City = detailUser.City;
                userDetail.ApartmentName = detailUser.ApartmentName;
                userDetail.ModifiedDate = DateTime.Now;
                await userDetailServices.Update(userDetail);
            }
            else
            {
                userDetail = new User_Detail();
                userDetail.Street = detailUser.Street;
                userDetail.State = detailUser.State;
                userDetail.City = detailUser.City;
                userDetail.ApartmentName = detailUser.ApartmentName;
                userDetail.ModifiedDate = DateTime.Now;
                userDetail.UserId = User.GetUserId();
                await userDetailServices.Add(userDetail);
            }
            await userServices.Update(user);

            await userServices.Save();
            return Redirect("/Payment/StrartPay?orderId=" + orderid?.Id);
        }
    }
}