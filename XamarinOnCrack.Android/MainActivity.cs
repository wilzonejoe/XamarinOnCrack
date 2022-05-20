using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using IO.Flutter.Embedding.Android;
using IO.Flutter.Embedding.Engine;
using IO.Flutter.Embedding.Engine.Dart;
using IO.Flutter.Plugins;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace XamarinOnCrack.Droid
{
    [Activity(Label = "XamarinOnCrack", Icon = "@mipmap/icon", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : AndroidX.AppCompat.App.AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            
            ShowFlutterFragment(Resource.Id.fragment_container1, "main_page");
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        private void EnsureFlutterEngineCreated(string engineId)
        {
            if (!FlutterEngineCache.Instance.Contains(engineId))
            {
                var flutterEngine = new FlutterEngine(this);
                GeneratedPluginRegistrant.RegisterWith(flutterEngine);

                flutterEngine.DartExecutor.ExecuteDartEntrypoint(
                    DartExecutor.DartEntrypoint.CreateDefault()
                );

                FlutterEngineCache.Instance.Put(engineId, flutterEngine);
            }
        }
        
        private Fragment ShowFlutterFragment(int containerViewId, string tag, string route = "/")
        {
            var fragment = SupportFragmentManager
                .FindFragmentByTag(tag);

            if  (fragment is FlutterFragment flutterFragment)
                return flutterFragment;
            
            const string engineId = "FlutterFragmentEngine";
            EnsureFlutterEngineCreated(engineId);

            fragment = FlutterFragment
                .WithNewEngine()
                .InitialRoute(route)
                .Build() as FlutterFragment;

            SupportFragmentManager
                .BeginTransaction()
                .Add(
                    containerViewId,
                    fragment,
                    tag
                )
                .Commit();

            return fragment;
        }
    }
}
