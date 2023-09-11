using System.Net;

namespace LexAPI
{
    public class IPFilterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HashSet<string> _allowedIPs;

        public IPFilterMiddleware(RequestDelegate next, IEnumerable<string> allowedIPs)
        {
            _next = next;
            _allowedIPs = new HashSet<string>(allowedIPs);
        }

        public async Task Invoke(HttpContext context)
        {
            var remoteIp = context.Connection.RemoteIpAddress;
            if (context.Request.Method == HttpMethods.Post && !_allowedIPs.Contains(remoteIp?.ToString()))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            await _next.Invoke(context);
        }
    }

}
