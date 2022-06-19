#!/usr/bin/env bash

#DEBUG build commands
# - sh build_flutter.sh debug

#RELEASE build commands
# - sh build_flutter.sh release

# Define paths
FlutterModule_DIR=flutter_module
BUILD_PROFILE=$1

# Build Flutter module
cd $FlutterModule_DIR
flutter pub get

case $BUILD_PROFILE in
    debug)
        flutter build aar --t lib/main.integrated.dart -no-profile --no-release
    ;;
    release)
        flutter build aar -t lib/main.integrated.dart --no-debug --no-profile
    ;;
    *)
        echo "build profile '$BUILD_PROFILE' not valid"
        exit 125
    ;;
esac

# Copy build 
FLUTTER_ARR_PATH=../flutter_module/build/host/outputs/repo/com/*/flutter_module/flutter_$BUILD_PROFILE/1.0/
DESTINATION_BUILD_PATH=../flutter_build/android/$BUILD_PROFILE/build

if [ ! -d $DESTINATION_BUILD_PATH ]; then
    mkdir -p $DESTINATION_BUILD_PATH
fi

echo "Copy $FLUTTER_ARR_PATH To $DESTINATION_BUILD_PATH"
cp -r $FLUTTER_ARR_PATH $DESTINATION_BUILD_PATH

# Copy plugin 
PERMISSION_LIBRARY_ARR_PATH=../flutter_module/build/host/outputs/repo/com/baseflow/permissionhandler/permission_handler_android_$BUILD_PROFILE/1.0/
DESTINATION_PLUGIN_PATH=flutter_../build/android/$BUILD_PROFILE/plugin
AAR_LOCATION_PATHS=($PERMISSION_LIBRARY_ARR_PATH)

if [ ! -d $DESTINATION_PLUGIN_PATH ]; then
    mkdir -p $DESTINATION_PLUGIN_PATH
fi

for i in ${!AAR_LOCATION_PATHS[@]}
do
    aar_pathname=${AAR_LOCATION_PATHS[$i]}
    echo "Copy $aar_pathname To $DESTINATION_PLUGIN_PATH"
    cp -r $aar_pathname $DESTINATION_PLUGIN_PATH
done


# Copy dependencies 
DESTINATION_DEPENDENCIES_PATH=../flutter_build/android/$BUILD_PROFILE/depedencies
FLUTTER_DEPENDENCIES_PATH=~/.gradle/caches/modules-2/files-2.1/io.flutter/*$BUILD_PROFILE/*/*/*

if [ ! -d $DESTINATION_DEPENDENCIES_PATH ]; then
    mkdir -p $DESTINATION_DEPENDENCIES_PATH

    for pathname in $FLUTTER_DEPENDENCIES_PATH
    do
        echo "Copy $pathname To $DESTINATION_DEPENDENCIES_PATH"
        cp $pathname $DESTINATION_DEPENDENCIES_PATH
    done
fi

chmod -R 755 $DESTINATION_BUILD_PATH
chmod -R 755 $DESTINATION_DEPENDENCIES_PATH
