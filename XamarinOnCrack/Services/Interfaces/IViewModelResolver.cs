using System;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.Services.Interfaces
{
	public interface IViewModelResolver
	{
        TInterface Resolve<TInterface>() where TInterface : class, IViewModel;

        TInterface Resolve<TInterface>(Type type) where TInterface : class, IViewModel;
    }
}

