using XamarinOnCrack.Models.Abstracts;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.ViewModels
{
    public abstract class BaseViewModel : ObservableObject, IViewModel
	{
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
    }
}

