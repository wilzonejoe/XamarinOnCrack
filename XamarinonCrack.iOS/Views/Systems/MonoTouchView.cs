using System;
using UIKit;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.iOS.Views.Systems
{
    public abstract class MonoTouchView<T> : MonoTouchView
        where T : IViewModel
    {
        protected T _viewModel;

        public override IViewModel ViewModel
        {
            get => _viewModel;
            set => _viewModel = (T) value;
        }
    }

    public abstract class MonoTouchView : IView, IDisposable
    {
        private IViewController _viewController;
        public IViewController ViewController => _viewController ?? SetupViewController();

        public IWorkspace Workspace => ViewModel.Workspace;
        public virtual IViewModel ViewModel { get; set; }

        protected abstract IViewController CreateViewController();

        public virtual void OnClose()
        {
        }

        public virtual void OnShow()
        {
            var view = ViewController.View;
            view.Bounds = UIScreen.MainScreen.Bounds;
        }

        private void OnCloseEvent(object sender, EventArgs args) => OnShow();

        private void OnShowEvent(object sender, EventArgs args) => OnClose();

        public IViewController SetupViewController()
        {
            var viewController = CreateViewController();
            AttachControllerListeners(viewController);
            _viewController = viewController;
            return viewController;
        }

        private void AttachControllerListeners(IViewController viewController)
        {
            viewController.OnViewDidAppear += OnShowEvent;
            viewController.OnViewDidDisappear += OnCloseEvent;
        }

        private void DetachControllerListeners(IViewController viewController)
        {
            viewController.OnViewDidAppear -= OnShowEvent;
            viewController.OnViewDidDisappear -= OnCloseEvent;
        }

        public void Dispose()
        {
            DetachControllerListeners(ViewController);
        }
    }
}