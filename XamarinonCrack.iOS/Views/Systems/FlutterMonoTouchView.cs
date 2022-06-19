using System.Threading.Tasks;
using FlutterBindings.iOS;
using Foundation;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.iOS.Views.Systems
{
    public abstract class FlutterMonoTouchView<T> : MonoTouchView<T>
        where T : IViewModel, IFlutterViewModel
    {
        public const string MethodClosePage= "navigateBack";
        
        protected override IViewController CreateViewController()
        {
            var hostViewController = new ViewController();
            var view = hostViewController.View!;
            
            var viewController = new FlutterViewController(AppDelegate.FlutterEngine, null, null);
            SetListeners(viewController);
            
            if (ViewModel is IFlutterViewModel flutterViewModel)
                viewController.PushRoute(flutterViewModel.Route);

            var flutterView = viewController.View!;
            
            view.AddSubview(viewController.View!);
            flutterView.Frame = new CoreGraphics.CGRect(
                view.Frame.Location.X, view.Frame.Location.Y,
                view.Frame.Size.Width, view.Frame.Size.Height);
            
            hostViewController.AddChildViewController(viewController);
            viewController.DidMoveToParentViewController(hostViewController);

            return hostViewController;
        }

        private void SetListeners(FlutterViewController controller)
        {
            var pageTypeFullName = "com.welpup.flutter_module/navigationService"!;
            var pageChannel = FlutterMethodChannel.MethodChannelWithName(pageTypeFullName, controller.BinaryMessenger);
            pageChannel.SetMethodCallHandler(ProcessMethodCall);
        }

        private async void ProcessMethodCall(FlutterMethodCall call, FlutterResult result)
        {
            var method = call.Method;
            var arguments = call.Arguments;

            var methodCallResult = await DoProcessMethodCallAsync(method, arguments);
            result(methodCallResult);
        }

        protected virtual Task<NSObject?> DoProcessMethodCallAsync(string method, NSObject? arguments)
        {
            switch (method)
            {
                case MethodClosePage:
                    Workspace.PopView();
                    break;
            }
            
            return Task.FromResult<NSObject?>(null);
        }
    }
}