using XamarinOnCrack.Services.Interfaces;

namespace XamarinOnCrack.ViewModels.Common
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IViewModelResolver _viewModelResolver;
        private readonly INavigationService _navigationService;

        public MainViewModel(IViewModelResolver resolver, INavigationService navigationService) : base(navigationService)
        {
            _viewModelResolver = resolver;
            _navigationService = navigationService;
        }

        public void GoToFlutterMainPage()
        {
            var viewModel = _viewModelResolver.Resolve<FlutterMainViewModel>();
            _navigationService.Push(Workspace, viewModel);
        }
    }
}