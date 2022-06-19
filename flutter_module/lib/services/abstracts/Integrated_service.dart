import 'package:flutter/services.dart';
import 'package:flutter_module/services/Interfaces/i_configuration_service.dart';

abstract class IntegrationService {
  final IConfigurationService configurationService;

  late String _channelNamePrefix;
  late String _channelNameSuffix;
  late MethodChannel _navigationServiceChannel;

  String get channelName {
    return "$_channelNamePrefix/$_channelNameSuffix";
  }

  IntegrationService(this.configurationService, String channelNameSuffix) {
    _channelNamePrefix = configurationService.channelName;
    _channelNameSuffix = channelNameSuffix;

    _initializeMethodChannel();
    _initializeMethodCallHandler();
  }

  void _initializeMethodChannel() {

    _navigationServiceChannel = MethodChannel(channelName);
  }

  void _initializeMethodCallHandler() {
    _navigationServiceChannel.setMethodCallHandler(
        (call) async => await onMethodCalled(call.method, call.arguments));
  }

  void invokeMethod(String method, [params]) {
    _navigationServiceChannel.invokeMethod(method, params);
  }

  Future onMethodCalled(String method, [params]);
}
