public class LogMiddelWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogMiddelWare> _logger;

    public LogMiddelWare(RequestDelegate next, ILogger<LogMiddelWare> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userName = context.User.Identity.IsAuthenticated ? context.User.Identity.Name : "Anonymous";

        var routeData = context.GetRouteData();
        var controllerName = routeData.Values["controller"];
        var actionName = routeData.Values["action"];

        _logger.LogInformation("User: {UserName}, Controller: {Controller}, Action: {Action}", userName, controllerName, actionName);

        await _next(context);
    }
}