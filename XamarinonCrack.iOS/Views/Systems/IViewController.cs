using System;
using UIKit;

namespace XamarinOnCrack.iOS.Views.Systems
{
    public interface IViewController
    {
        UIView View { get; }

        event EventHandler OnViewDidAppear;
        event EventHandler OnViewDidDisappear;
    }
}