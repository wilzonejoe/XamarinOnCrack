using System.Threading.Tasks;
using XamarinOnCrack.Models.UserInterface;

namespace XamarinOnCrack.ViewModels.Common
{
    public class FlutterMainViewModel : BaseViewModel, IFlutterViewModel
    {
        public string Route => "/";

        public async Task<string> GetDataAsync()
        {
            //Mock
            await Task.Delay(2000);
            return "Test From Xamarin";
        }
    }
}