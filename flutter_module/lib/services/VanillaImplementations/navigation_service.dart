import 'package:auto_route/auto_route.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_module/injectable.dart';
import 'package:injectable/injectable.dart';

import 'package:flutter_module/services/Interfaces/i_navigation_service.dart';

@standaloneEnvironment
@Injectable(as: INavigationService)
class IntegratedNavigationService implements INavigationService {
  @override
  void navigateBack(BuildContext context, [params]) {
    Navigator.pop(context);
  }

  @override
  void navigateTo(BuildContext context, String route, [params]) {
    Navigator.pushNamed(
      context,
      route
    );
  }
}
