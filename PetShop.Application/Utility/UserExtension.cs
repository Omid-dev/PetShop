using System.Security.Claims;

namespace PetShop.Application.Utility
{
    public static class UserExtension
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "id")?.Value);
        }

        public static string Tomony(this int price)
        {
            return price.ToString("N0");
        }
    }
}