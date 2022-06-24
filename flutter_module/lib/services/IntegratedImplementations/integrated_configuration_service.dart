import 'package:flutter_module/injectable.dart';
import 'package:injectable/injectable.dart';

import 'package:flutter_module/services/abstracts/common_configuration_service.dart';
import 'package:flutter_module/services/Interfaces/i_configuration_service.dart';

@integratedEnvironment
@Injectable(as: IConfigurationService)
class IntegratedConfigurationService extends CommonConfigurationService {
  @override
  String get channelName => "com.welpup.flutter_module";
  @override
  String get channelSuffixName => "comms";
}