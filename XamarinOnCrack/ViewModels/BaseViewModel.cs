using XamarinOnCrack.Models.Abstracts;
using XamarinOnCrack.Models.UserInterface;
using XamarinOnCrack.Services.Interfaces;

namespace XamarinOnCrack.ViewModels
{
    public abstract class BaseViewModel : ObservableObject, IViewModel
    {
        private readonly INavigationService _navigationService;
        
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public IWorkspace Workspace { get; set; }

        protected BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void PopView()
        {
            _navigationService.Pop(Workspace);
        }

        public void PushView(IViewModel viewModel)
        {
            _navigationService.Push(Workspace, viewModel);
        }
    }
}