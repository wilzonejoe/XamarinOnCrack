import 'package:flutter_module/models/enumerations/screen_size.dart';

class ScreenHelper {
  static const int smallScreenWidth = 576;
  static const int mediumScreenWidth = 768;
  static const int largeScreenWidth = 992;
  static const int extraLargeScreenWidth = 1200;
  
  static ScreenSize getScreenSize(double screenWidth) {
    if (screenWidth > extraLargeScreenWidth) {
      return ScreenSize.extraLarge;
    } else if (screenWidth > largeScreenWidth) {
      return ScreenSize.large;
    } else if (screenWidth > mediumScreenWidth) {
      return ScreenSize.medium;
    } else if (screenWidth > smallScreenWidth) {
      return ScreenSize.small;
    }

    return ScreenSize.extraSmall;
  }
}