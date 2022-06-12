using System;
using UIKit;

namespace XamarinonCrack.iOS.Views
{
    public interface IViewController
    {
        UIView View { get; }

        event EventHandler OnViewDidAppear;
        event EventHandler OnViewDidDisappear;
    }
}