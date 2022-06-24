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
        }
        
        protected override async Task<NSObject?> DoProcessMethodCallAsync(string method, NSObject? arguments)
        {
            object? result = null;
            
            switch (method)
            {
                default:
                    return await base.DoProcessMethodCallAsync(method, arguments);
            }
            
            return result == null? null : NSObject.FromObject(result);
        }
    }
}