# XamarinOnCrack

Flutter Integrated Xamarin Project Proof of Concept

## Project Structure

```
    . XamarinOnCrack(Root Folder)
    │
    ├── flutter_module                        # Flutter app module (Dart Code)
    │
    ├── FlutterBindings.iOS                   # iOS native binding project on flutter build archive App.framework & Flutter.framework
    │   └── Native References                 # Framework files -> Containing .framework files from Flutter build
    │
    ├── FlutterBindings.Android               # Android native binding project on flutter build archive .aar
    │   └── JARS                              # Android archive files -> Containing .aar file from Flutter build and .jar file from flutter gradle/maven dependencies
    │
    ├── FlutterBindings.Plugin.Android        # Android native binding project on flutter plugin archive .aar
    │   └── JARS                              # Jar files -> Containing .aar file from Flutter plugins
    │
    ├── XamarinOnCrack.iOS                    # Xamarin Entry point for iOS
    │
    └── XamarinOnCrack.Android                # Xamarin Entry point for Android

```

## Setup

Run on **XamarinOnCrack(root folder)** before build or after flutter_module file(s) modified.

### iOS

This script will build flutter iOS framework. It will generate `.xcframework` files, which contains both iPhone and Simulator `.framework` files that we can use to do native binding to the **FlutterBindings.iOS**

After the build is done, the `.framworks` files will be copied to `flutter_build/iOS/{build_profile}/`

##### Debug
```
sh Scripts/build_flutter_ios.sh debug
```

##### Release
```
sh Scripts/build_flutter_ios.sh release
```

#### Native Binding iOS 
(Use iOS version available in your computer e.g. iphoneos15.5)
```
sharpie bind -o FlutterBindings.iOS -sdk iphoneos15.5 -framework flutter_module/build/ios/framework/Debug/Flutter.xcframework/ios-arm64_armv7/Flutter.framework
```

### Android

This script will build flutter Android framework. It will generate `.aar` and `.pom` files, which we can use to do native binding to the **FlutterBindings.Android** & **FlutterBindings.Plugin.Android**

After the build is done, the `.aar` & `.pom` files will be copied to `flutter_build/android/{build_profile}/`

- **build** - `.aar` and `.pom` files from Flutter_Module
- **plugins** - `.aar` and `.pom` files from plugin used by Flutter_Module
- **depedencies** - `.jar` files from `~/.gradle/caches/modules-2/files-2.1/io.flutter` directory

##### Debug
```
sh Scripts/build_flutter_android.sh debug
```

##### Release
```
sh Scripts/build_flutter_android.sh release
```

#### Native Binding Android 
After linking JARs/AARs files into native binding project, build the binding project and you should find a file in obj/debug/api.xml.
This file will show all of the API references to be translated to C#

### Flutter project
The beauty of this POC is that the Flutter module could run independently as its own project.
Just keep in mind, navigation for Xamarin integration and Flutter standalone project could be different. 
It is recommended to use injectable interfaces in flutter project so that there is different handler for Flutter standalone and Xamarin integration

## Known Limitation(s)

### Android build

- After rebuilding flutter `.aar` build, the build will sometimes failed or changes will not be shown in Android app installed in simulator or an actual device.

### Auto build

- Auto build is still the end goal to make this POC viable to be developed day by day but cause Visual Studio would not run `flutter` command. Therefore, the script should be run manually run before integrated newly build flutter_module
