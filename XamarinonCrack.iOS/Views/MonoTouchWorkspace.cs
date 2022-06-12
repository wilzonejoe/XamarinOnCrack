using System;
using System.Threading.Tasks;
using UIKit;
using XamarinOnCrack;
using XamarinOnCrack.Models.UserInterface;
using XamarinOnCrack.Services.Interfaces;
using XamarinOnCrack.ViewModels.Common;

namespace XamarinonCrack.iOS.Views
{
	public class MonoTouchWorkspace : UINavigationController, IWorkspace
	{
        public event EventHandler ViewChanged;

        public void PopView()
        {
            PopViewController(true);
        }

        public void PushView(IView view)
        {
            if (view.ViewModel != null)
                view.ViewModel.Workspace = this;

            if (view is MonoTouchView monoTouchView)
            {
                var viewController = (UIViewController)monoTouchView.ViewController;
                PushViewController(viewController, true);
            }
            else
            {
                throw new Exception($"{view?.GetType()} is not implemented correctly");
            }
        }
    }
}

