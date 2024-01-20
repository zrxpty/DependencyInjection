using System.Reflection;

namespace DependencyInjection.App.DIContainer
{
    public class DIContainer
    {
        private readonly Dictionary<Type, Type> _services;
        private readonly List<object> _singletons;
        public DIContainer() 
        {
            _services = new Dictionary<Type, Type>();
            _singletons = new List<object>();
        }

        public void AddServiceSingleton<TInterface, TImplementation>()
        {
            var service = Activator.CreateInstance(typeof(TImplementation));
            _singletons.Add(service);
            _services.Add(typeof(TInterface), typeof(TImplementation));
        }

        public void AddServiceSingleton<TImplementation>()
        {
            var interfaces = typeof(TImplementation).GetInterfaces();

            if (interfaces.Length == 0)
            {
                throw new InvalidOperationException($"{typeof(TImplementation).Name} no interfaces");
            }

            var service = Activator.CreateInstance(typeof(TImplementation));
            _singletons.Add(service);
            _services.Add(interfaces[0], typeof(TImplementation));
        }

        public TService GetService<TService>()
        {
            var serviceType = _services.GetValueOrDefault(typeof(TService));

            if (serviceType == null)
                throw new Exception($"{typeof(TService).Name}");

            var singleton = _singletons.SingleOrDefault(s => s.GetType() == serviceType);

            if (singleton == null)
                throw new Exception($"{typeof(TService).Name} not found");

            return (TService)singleton;
        }
    }
}
