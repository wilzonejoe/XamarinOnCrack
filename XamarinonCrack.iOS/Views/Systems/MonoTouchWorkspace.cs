using System;
using UIKit;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.iOS.Views.Systems
{
    public class MonoTouchWorkspace : UINavigationController, IWorkspace
    {
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
                var viewController = (UIViewController) monoTouchView.ViewController;
                PushViewController(viewController, true);
            }
            else
            {
                throw new Exception($"{view?.GetType()} is not implemented correctly");
            }
        }
    }
}