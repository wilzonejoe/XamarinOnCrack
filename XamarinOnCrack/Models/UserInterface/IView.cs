using System;
namespace XamarinOnCrack.Models.UserInterface
{
	public interface IView
	{
		IViewModel ViewModel { get; set; }

		void OnShow();

		void OnClose();
	}
}

