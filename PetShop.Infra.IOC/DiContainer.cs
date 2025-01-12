using Microsoft.Extensions.DependencyInjection;
using PetShop.Application.Services.Impelemntaions;
using PetShop.Application.Services.Interfaces;
using PetShop.Domain.Contracts;
using PetShop.Infra.Data.Repositories;

namespace PetShop.Infra.IOC
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repository

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserDetailRepository, UserDatailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogGroupRepository, BlogGroupRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            #endregion Repository

            #region Services

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IGroupsServices, GroupsServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IUserDetailServices, UserDetailServices>();
            services.AddScoped<INovinoServises, NovinoServices>();
            services.AddScoped<IOrderServises, OrderServices>();
            services.AddScoped<IOrderDetailServises, OrderDetailServices>();
            services.AddScoped<IBlogServises, BlogServices>();
            services.AddScoped<IBlogGroupServices, BlogGroupServices>();
            services.AddScoped<ICommentServices, CommentServices>();

            #endregion Services
        }
    }
}