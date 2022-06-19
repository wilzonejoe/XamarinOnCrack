using UIKit;
using XamarinOnCrack.iOS.Views.Systems;
using XamarinOnCrack.ViewModels.Common;

namespace XamarinOnCrack.iOS.Views.Common
{
    public class MainView : MonoTouchView<MainViewModel>
    {
        protected override IViewController CreateViewController()
        {
            var controller = new ViewController();
            var rootView = controller.View!;
            rootView.BackgroundColor = UIColor.SystemBackground;

            var verticalStack = new UIStackView();
            rootView.AddSubview(verticalStack);
            verticalStack.Axis = UILayoutConstraintAxis.Vertical;
            verticalStack.TranslatesAutoresizingMaskIntoConstraints = false;

            verticalStack.CenterXAnchor.ConstraintEqualTo(rootView.CenterXAnchor).Active = true;
            verticalStack.BottomAnchor.ConstraintEqualTo(rootView.CenterYAnchor).Active = true;

            var label = new UILabel();
            label.Text = "This is Xamarin here";
            verticalStack.AddArrangedSubview(label);

            var button = new UIButton();
            button.SetTitle("Go to Flutter Page", UIControlState.Normal);
            button.SetTitleColor(UIColor.SystemBlue, UIControlState.Normal);
            button.TouchDown += (_, __) => _viewModel.GoToFlutterPage();
            verticalStack.AddArrangedSubview(button);

            return controller;
        }
    }
}