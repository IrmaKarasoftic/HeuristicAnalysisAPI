﻿using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common.WebHost;

namespace HeuristicAnalysis.API
{
    public static class NinjectWeb
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
