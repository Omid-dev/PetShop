namespace PetShop.Web.Middleware

{
    public class AdminMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/admin"))
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    var isAdmin = context.User.Claims.FirstOrDefault(u => u.Type == "IsAdmin");
                    if (isAdmin != null && isAdmin.Value == "True")
                    {
                        await _next(context);
                        return;
                    }
                    else
                    {
                        context.Response.Redirect("/Denied");
                    }
                }
                else
                {
                    //context.Response.Clear();
                    context.Response.Redirect("/Denied");
                }
            }
            await _next(context);
        }
    }
}