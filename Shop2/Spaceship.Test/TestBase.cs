using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Shop2.ApplicationServices.Services;

//namespace Spaceship.Test
//{
//    public abstract class TestBase :IDisposable
//    {
//        protected IServiceProvider serviceProvider;

//        protected TestBase()
//        {
//            var services = new ServiceCollection();
//            SetupServices(services);
//            _serviceProvider = services.BuildSeviceProvider();
//        }

//        public virtual void SetupServices(IServiceCollection services)
//        {
//            services.AddScoped<ISpaceshipService, SpaceshipServices>();
//        }

//        public void Dispose()
//        {

//        }

//        //protected T Svc<T>()
//        //{
//        //    return ServiceProvider.GetService<T>();
//        //}
//    }
//}
