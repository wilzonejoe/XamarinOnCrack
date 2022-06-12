using System;
using XamarinOnCrack.Models.UserInterface;
using XamarinOnCrack.Services.Interfaces;

namespace XamarinOnCrack.Services
{
	public class ViewModelResolver : IViewModelResolver
	{
        public TInterface Resolve<TInterface>()
            where TInterface : class, IViewModel
        {
            return DependencyContainer.Resolve<TInterface>();
        }

        public TInterface Resolve<TInterface>(Type type)
            where TInterface : class, IViewModel
        {
            return DependencyContainer.Resolve<TInterface>(type);
        }
    }
}

