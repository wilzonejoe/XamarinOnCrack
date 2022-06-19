using System.Threading.Tasks;
using Foundation;
using XamarinOnCrack.iOS.Views.Systems;
using XamarinOnCrack.ViewModels.Common;

namespace XamarinOnCrack.iOS.Views.Common
{
    public class FlutterMainView : FlutterMonoTouchView<FlutterMainViewModel>
    {
        class FlutterMethods
        {
            public const string MethodGetData = "GetXamarinGetData";
        }
        
        protected override async Task<NSObject?> DoProcessMethodCallAsync(string method, NSObject? arguments)
        {
            object? result = null;
            
            switch (method)
            {
                case FlutterMethods.MethodGetData:
                    result = await _viewModel.GetDataAsync();
                    break;
                default:
                    return await base.DoProcessMethodCallAsync(method, arguments);
            }
            
            return result == null? null : NSObject.FromObject(result);
        }
    }
}