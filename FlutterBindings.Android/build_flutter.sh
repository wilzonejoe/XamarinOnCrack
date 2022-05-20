#!/usr/bin/env bash

#DEBUG build commands
# - sh build_flutter.sh debug

#RELEASE build commands
# - sh build_flutter.sh release

# Define paths
FlutterModule_DIR=../flutter_module
BUILD_PROFILE=$1

# Build Flutter module
cd $FlutterModule_DIR
flutter pub get

case $BUILD_PROFILE in
    debug)
        flutter build aar --no-profile --no-release
    ;;
    release)
        flutter build aar --no-debug --no-profile
    ;;
    *)
        echo "build profile '$BUILD_PROFILE' not valid"
        exit 125
    ;;
esac

BUILD_PATH_FLUTTER=../flutter_module/build/host/outputs/repo/com/*/flutter_module/flutter_$BUILD_PROFILE/1.0/

DESTINATION_BUILD_PATH=../flutter_build/android/$BUILD_PROFILE/build
DESTINATION_DEPENDENCIES_PATH=../flutter_build/android/$BUILD_PROFILE/depedencies

if [ ! -d $DESTINATION_BUILD_PATH ]; then
    mkdir -p $DESTINATION_BUILD_PATH
fi

echo "Copy $BUILD_PATH_FLUTTER To $DESTINATION_BUILD_PATH"
cp -r $BUILD_PATH_FLUTTER $DESTINATION_BUILD_PATH

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