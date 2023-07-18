namespace OnDijon
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {
                // Gérer la logique pour les routes non trouvées ici
                await context.Response.WriteAsync("Route not found");
            }
        }
    }

}
