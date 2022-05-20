#!/usr/bin/env bash

#DEBUG build commands
# - sh build_flutter.sh debug
# - sh build_flutter.sh debug simulator

#RELEASE build commands
# - sh build_flutter.sh release
# - sh build_flutter.sh release simulator

# Define paths
FLUTTER_MODULE_DIR=../flutter_module
BUILD_PROFILE=$1
MACHINE_PROFILE=$2

# Build Flutter module
cd $FLUTTER_MODULE_DIR
flutter pub get

case $BUILD_PROFILE in
    debug)
        flutter build ios-framework --no-profile --no-release
    ;;
    release)
        flutter build ios-framework --no-debug --no-profile
    ;;
    *)
        echo "build profile '$BUILD_PROFILE' not valid"
        exit 125
    ;;
esac

#copy project to destination folder
case $MACHINE_PROFILE in
    simulator)
        MACHINE_PROFILE_NAME="simulator"
        MACHINE_PROFILE_PATH="ios-arm64_x86_64-simulator"
    ;;
    *)
        MACHINE_PROFILE_NAME="iphone"
        MACHINE_PROFILE_PATH="ios-arm64_armv7"
    ;;
esac

FRAMEWORK_PATH_APP=build/ios/framework/Debug/App.xcframework/$MACHINE_PROFILE_PATH/
FRAMEWORK_PATH_FLUTTER=build/ios/framework/Debug/Flutter.xcframework/$MACHINE_PROFILE_PATH/

DESTINATION_PATH=../flutter_build/iOS/$BUILD_PROFILE/$MACHINE_PROFILE_NAME/

if [ ! -d $DESTINATION_PATH ]; then
    mkdir -p $DESTINATION_PATH
fi

echo "Copy $FRAMEWORK_PATH_APP To $DESTINATION_PATH"
cp -r $FRAMEWORK_PATH_APP $DESTINATION_PATH

echo "Copy $FRAMEWORK_PATH_FLUTTER To $DESTINATION_PATH"
cp -r $FRAMEWORK_PATH_FLUTTER $DESTINATION_PATH

echo "Setup permission $DESTINATION_PATH"
chmod -R 777 $DESTINATION_PATH