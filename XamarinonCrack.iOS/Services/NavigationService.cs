using System;
using System.Threading.Tasks;
using XamarinOnCrack;
using XamarinOnCrack.Models.UserInterface;
using XamarinOnCrack.Services.Interfaces;

namespace XamarinOnCrack.iOS.Services
{
    public class NavigationService : INavigationService
    {
        public void Pop(IWorkspace workspace)
        {
            workspace.PopView();
        }

        public void Push(IWorkspace workspace, IViewModel viewModel)
        {
            var view = LocateView(viewModel);
            view.ViewModel.Workspace = workspace;
            workspace.PushView(view);
        }

        private IView LocateView(IViewModel viewModel)
        {
            var viewModelType = viewModel.GetType();

            var viewName = viewModelType.FullName;

            // Replace project name
            viewName = viewName!.Replace("XamarinOnCrack.", "XamarinOnCrack.iOS.");

            // Replace view model to view
            viewName = viewName.Replace("ViewModel", "View");

            var viewType = Type.GetType(viewName);
            var view = DependencyContainer.Resolve<IView>(viewType);
            view.ViewModel = viewModel;
            return view;
        }
    }
}