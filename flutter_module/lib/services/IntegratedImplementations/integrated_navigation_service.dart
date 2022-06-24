import 'package:flutter/widgets.dart';
import 'package:flutter_module/injectable.dart';
import 'package:injectable/injectable.dart';

import 'package:flutter_module/services/Interfaces/i_configuration_service.dart';
import 'package:flutter_module/services/Interfaces/i_navigation_service.dart';
import 'package:flutter_module/services/abstracts/Integrated_service.dart';

@integratedEnvironment
@Injectable(as: INavigationService)
class IntegratedNavigationService extends IntegrationService
    implements INavigationService {
  final String navigateBackActionMethod = "navigateBack";
  final String navigateToActionMethod = "navigateTo";

  IntegratedNavigationService(IConfigurationService configurationService)
      : super(configurationService);

  @override
  Future onMethodCalled(String method, [params]) async {
    throw UnimplementedError();
  }

  @override
  void navigateBack(BuildContext context, [params]) {
    dynamic arguments = {"params": params};
    invokeMethod(navigateBackActionMethod, arguments);
  }

  @override
  void navigateTo(BuildContext context, String route, [params]) {
    dynamic arguments = {"route": route, "params": params};
    invokeMethod(navigateToActionMethod, arguments);
  }
}
