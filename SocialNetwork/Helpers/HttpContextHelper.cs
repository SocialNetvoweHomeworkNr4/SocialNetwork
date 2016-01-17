using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SocialNetwork.App_Start.NinjectWebCommon;

namespace SocialNetwork.Helpers
{
    public static class HttpContextHelper
    {
        private const string CURRENT_USER = "CurrentUser";

        public static User CurrentUser
        {
            get
            {
                var context = HttpContext.Current;

                if (context.Items[CURRENT_USER] == null)
                {
                    IUserService service = DependencyResolver.Get<IUserService>();

                    if (context.User != null)
                    {
                        var identity = context.User.Identity;

                        if (identity == null || !identity.IsAuthenticated)
                        {
                            identity = System.Threading.Thread.CurrentPrincipal.Identity;
                        }

                        if (identity != null && identity.IsAuthenticated)
                        {
                            HttpContext.Current.Items[CURRENT_USER] = service.Get(s => s.Email == identity.Name);
                        }
                    }
                }

                return HttpContext.Current.Items[CURRENT_USER] as User;
            }
        }
    }
}