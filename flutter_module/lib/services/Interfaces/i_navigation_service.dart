import 'package:flutter/widgets.dart';

abstract class INavigationService {
  void navigateTo(BuildContext context, String route, [dynamic params]);
  void navigateBack(BuildContext context, [dynamic params]);
}