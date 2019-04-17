using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace MVC.Helper.Unity
{
 
    public class ServiceLocator : IServiceProvider
    {
        private readonly IUnityContainer _container;
        private static readonly ServiceLocator instance = new ServiceLocator();


        private ServiceLocator()
        {

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            _container = new UnityContainer();

            if (section != null) section.Configure(_container);
        }

        public static ServiceLocator Instance
        {

            get { return instance; }

        }

        public object GetService(Type serviceType)
        {

            return _container.Resolve(serviceType);

        }

        public T GetService<T>()
        {

            return _container.Resolve<T>();

        }
        public T GetService<T>(Type iLogicType, Type logicType)
        {
            _container.RegisterType(iLogicType, logicType);
            return _container.Resolve<T>();

        }
    }
}
