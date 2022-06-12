using System;
using Autofac;
using XamarinOnCrack.Services;
using XamarinOnCrack.Services.Interfaces;
using XamarinOnCrack.ViewModels.Common;

namespace XamarinOnCrack
{
    public static class DependencyContainer
    {
        private static IContainer _container;
        private static readonly ContainerBuilder Builder = new ContainerBuilder();

        public static void AddTransient<TInterface>() 
            where TInterface : class
        {
            Builder.RegisterType<TInterface>();
        }

        public static void AddTransient<TInterface, TImplementation>() 
            where TInterface : class 
            where TImplementation : class, TInterface
        {
            Builder.RegisterType<TImplementation>().As<TInterface>();
        }
        
        public static void AddSingleton<TInterface, TImplementation>() 
            where TInterface : class 
            where TImplementation : class, TInterface
        {
            Builder.RegisterType<TImplementation>().As<TInterface>().SingleInstance();
        }

        public static void AddSingleton<TInterface, TImplementation>(TImplementation implementation)
            where TInterface : class 
            where TImplementation : class, TInterface
        {
            Builder.RegisterInstance(implementation).As<TInterface>().SingleInstance();
        }

        public static TInterface Resolve<TInterface>()
            where TInterface : class
        {
            return _container.Resolve<TInterface>();
        }

        public static TInterface Resolve<TInterface>(Type type)
            where TInterface : class
        {
            var result = _container.Resolve(type);
            return result as TInterface;
        }

        public static void RegisterCommonServices()
        {
            AddTransient<IViewModelResolver, ViewModelResolver>();
        }

        public static void RegisterViewModels()
        {
            AddTransient<MainViewModel>();
            AddTransient<FlutterMainViewModel>();
        }

        public static void Start()
        {
            _container = Builder.Build();
        }
    }
}