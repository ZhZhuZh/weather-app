using System.Text;

namespace FirstApp.Cmd
{
    public class BasicMiddleWareAuthHandler
    {
        private RequestDelegate next;
        private string relm;

        public BasicMiddleWareAuthHandler(RequestDelegate next, string relm) { 
            this.next = next;
            this.relm = relm;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/graphql/"))
            {
                // Allow access without authentication for the GraphQL endpoint
                return next(context);
            }

            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                return context.Response.WriteAsync("Unauthorized");
            }

            string header = context.Request.Headers["Authorization"].ToString();
            string encodedCreds = header.Substring("Basic ".Length);
            string creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] uidpwd = creds.Split(':');
            string uid = uidpwd[0];
            string password = uidpwd[1];

            if (uid != "SuperAdmin" || password != "aA123123@")
            {
                context.Response.StatusCode = 401;
                return context.Response.WriteAsync("Unauthorized");
            }

            return next(context);
        }
    }
}
