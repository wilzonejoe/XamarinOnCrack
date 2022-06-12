using System;
using UIKit;

namespace XamarinonCrack.iOS.Views
{
	public class ViewController : UIViewController, IViewController
    {
        public event EventHandler OnViewDidAppear;
        public event EventHandler OnViewDidDisappear;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            OnViewDidAppear?.Invoke(this, EventArgs.Empty);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            OnViewDidDisappear?.Invoke(this, EventArgs.Empty);
        }
    }
}

