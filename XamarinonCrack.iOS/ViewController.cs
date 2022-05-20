using FlutterBindings.iOS;
using System;
using UIKit;

namespace XamarinonCrack.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var vc = new FlutterViewController(AppDelegate.FlutterEngine, null, null);
            View.AddSubview(vc.View);
            vc.View.Frame = new CoreGraphics.CGRect(
                View.Frame.Location.X, View.Frame.Location.Y,
                View.Frame.Size.Width, View.Frame.Size.Height);
            AddChildViewController(vc);
            vc.DidMoveToParentViewController(this);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
