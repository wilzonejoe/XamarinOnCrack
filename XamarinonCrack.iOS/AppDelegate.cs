﻿using FlutterBindings.iOS;
using Foundation;
using UIKit;
using XamarinOnCrack.iOS.Services;
using XamarinOnCrack.iOS.Views.Common;
using XamarinOnCrack.Services.Interfaces;

namespace XamarinOnCrack.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FlutterAppDelegate
    {
        public static FlutterEngine FlutterEngine { get; private set; }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession,
            UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            FlutterEngine = new FlutterEngine("My Flutter Engine");
            FlutterEngine.Run();

            // Services
            DependencyContainer.AddTransient<INavigationService, NavigationService>();

            // Views
            DependencyContainer.AddTransient<MainView>();
            DependencyContainer.AddTransient<FlutterMainView>();

            DependencyContainer.RegisterCommonServices();
            DependencyContainer.RegisterViewModels();

            DependencyContainer.Start();

            return true;
        }
    }
}