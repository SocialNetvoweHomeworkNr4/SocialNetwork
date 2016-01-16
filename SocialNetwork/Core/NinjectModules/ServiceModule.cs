using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.Services;

namespace SocialNetwork.Core.NinjectModules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            BusinessLogic.Infrastructure.DependencyResolver.Initialize(Kernel);
            //Having single DbContext per request is the best option, that's why InRequestScope()
            //More details: http://stackoverflow.com/questions/10585478/one-dbcontext-per-web-request-why


        }
    }
}