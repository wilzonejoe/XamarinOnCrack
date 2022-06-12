using System;
using System.Threading.Tasks;

namespace XamarinOnCrack.Models.UserInterface
{
	public interface IWorkspace
	{
		void PushView(IView view);

		void PopView();
	}
}

