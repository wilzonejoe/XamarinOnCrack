using FlutterBindings.iOS;
using XamarinOnCrack.ViewModels.Common;

namespace XamarinonCrack.iOS.Views.Common
{
    public class FlutterMainView : MonoTouchView<FlutterMainViewModel>
    {
        protected override IViewController CreateViewController()
        {
            var hostViewController = new ViewController();
            var view = hostViewController.View;

            var vc = new FlutterViewController(AppDelegate.FlutterEngine, null, null);
            hostViewController.View.AddSubview(vc.View);
            vc.View.Frame = new CoreGraphics.CGRect(
                view.Frame.Location.X, view.Frame.Location.Y,
                view.Frame.Size.Width, view.Frame.Size.Height);
            hostViewController.AddChildViewController(vc);
            vc.DidMoveToParentViewController(hostViewController);

            return hostViewController;
        }
    }
}

