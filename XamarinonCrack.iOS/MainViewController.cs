using System;
using UIKit;
using XamarinOnCrack.iOS.Views.Systems;
using XamarinOnCrack.Services.Interfaces;
using XamarinOnCrack.ViewModels.Common;

namespace XamarinOnCrack.iOS
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

            var parentViewFrame = View!.Frame;

            var workspace = new MonoTouchWorkspace();
            workspace.View!.Frame = new CoreGraphics.CGRect(
                parentViewFrame.Location.X, parentViewFrame.Location.Y,
                parentViewFrame.Size.Width, parentViewFrame.Size.Height);
            workspace.View.BackgroundColor = UIColor.Black;

            View.AddSubview(workspace.View);
            AddChildViewController(workspace);

            _navigationService.Push(workspace, _mainViewModel);
        }
    }
}