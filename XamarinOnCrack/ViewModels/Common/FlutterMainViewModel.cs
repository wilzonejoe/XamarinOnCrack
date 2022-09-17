using XamarinOnCrack.Models.UserInterface;
using XamarinOnCrack.Services.Interfaces;

namespace XamarinOnCrack.ViewModels.Common
{
    public class FlutterMainViewModel : BaseViewModel, IFlutterViewModel
    {
        public string Route => "/";
        public string MethodChannelKey => $"com.welpup.flutter_module{Route}"!;

        public FlutterMainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}