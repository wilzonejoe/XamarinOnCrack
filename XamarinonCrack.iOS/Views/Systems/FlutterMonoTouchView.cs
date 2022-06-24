using System.Threading.Tasks;
using FlutterBindings.iOS;
using Foundation;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.iOS.Views.Systems
{
    public abstract class FlutterMonoTouchView<T> : MonoTouchView<T>
        where T : class, IViewModel, IFlutterViewModel
    {
        private static class FlutterMethods
        {
            public const string MethodClosePage = "navigateBack";
            public const string MethodNavigateToPage = "navigateTo";
        }

        private FlutterViewController? _flutterViewController;

        protected override IViewController CreateViewController()
        {
            var hostViewController = new ViewController();
            var view = hostViewController.View!;

            var flutterEngine = AppDelegate.FlutterEngine;
            _flutterViewController = new FlutterViewController(flutterEngine, null, null);
            SetListeners(_flutterViewController);

            if (ViewModel is IFlutterViewModel flutterViewModel)
                _flutterViewController.PushRoute(flutterViewModel.Route);

            var flutterView = _flutterViewController.View!;

            view.AddSubview(_flutterViewController.View!);
            flutterView.Frame = new CoreGraphics.CGRect(
                view.Frame.Location.X, view.Frame.Location.Y,
                view.Frame.Size.Width, view.Frame.Size.Height);

            hostViewController.AddChildViewController(_flutterViewController);
            _flutterViewController.DidMoveToParentViewController(hostViewController);
            
            return hostViewController;
        }

        private void SetListeners(FlutterViewController controller)
        {
            var pageChannel = FlutterMethodChannel.MethodChannelWithName(SpecificViewModel.MethodChannelKey, controller.BinaryMessenger);
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
                case FlutterMethods.MethodClosePage:
                    ViewModel?.PopView();
                    break;
            }

            return Task.FromResult<NSObject?>(null);
        }

        public override void OnShow()
        {
            base.OnShow();
            AppDelegate.FlutterEngine.ViewController ??= _flutterViewController;
        }

        public override void OnClose()
        {
            base.OnClose();
            AppDelegate.FlutterEngine.ViewController = null;
        }
    }
}