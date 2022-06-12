using System.Threading.Tasks;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.Services.Interfaces
{
    public interface INavigationService
	{
		void Push(IWorkspace workspace, IViewModel viewModel);

		void Pop(IWorkspace workspace);
	}
}

