using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModernMilkman.CustomerManagement.API.Model;
using ModernMilkman.CustomerManagement.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace ModernMilkman.CustomerManagement.API.Attributes
{
    namespace BasicAuthenticationWEBAPI.Models
    {
        public class CustomAuthAttribute : TypeFilterAttribute
        {
            public CustomAuthAttribute() : base(typeof(AuthorizeActionFilter))
            {
            }

            public class AuthorizeActionFilter : IAuthorizationFilter
            {
                public void OnAuthorization(AuthorizationFilterContext context)
                {
                    string userId = context.HttpContext.Request?.Headers["UserId"].ToString();
                    string password = context.HttpContext.Request?.Headers["Password"].ToString();

                    var userList = UserList();

                    bool isUserPermission = userList.Where(w => w.Username == userId && w.Password == password).Any();
                    if (!isUserPermission)
                    {
                        var _res = new { status = 401, Message = "Unauthorized Access", Data = "Unauthorized Access" };
                        context.Result = new JsonResult(_res);
                        return;
                    }

                }

                public List<APICredentials> UserList()
                {
                    List<APICredentials> users = new List<APICredentials>
                {
                    new APICredentials { Username = "user", Password ="pass"}
                };
                    return users;
                }
            }
        }
    }
}
