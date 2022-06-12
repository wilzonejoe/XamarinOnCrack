using FlutterBindings.iOS;
using System;
using UIKit;
using XamarinonCrack.iOS.Views;
using XamarinOnCrack;
using XamarinOnCrack.Services.Interfaces;
using XamarinOnCrack.ViewModels.Common;

namespace XamarinonCrack.iOS
{
    public partial class MainViewController : UIViewController
    {
        private readonly INavigationService _navigationService;
        private readonly MainViewModel _mainViewModel;

        public MainViewController(IntPtr handle) : base(handle)
        {
            _navigationService = DependencyContainer.Resolve<INavigationService>();
            _mainViewModel = DependencyContainer.Resolve<MainViewModel>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.SystemPink;

            var workspace = new MonoTouchWorkspace();
            workspace.View.Frame = new CoreGraphics.CGRect(
                View.Frame.Location.X, View.Frame.Location.Y,
                View.Frame.Size.Width, View.Frame.Size.Height);
            workspace.View.BackgroundColor = UIColor.Black;

            View.AddSubview(workspace.View);
            AddChildViewController(workspace);

            var navigationService = DependencyContainer.Resolve<INavigationService>();
            var mainViewModel = DependencyContainer.Resolve<MainViewModel>();
            navigationService.Push(workspace, mainViewModel);
        }
    }
}