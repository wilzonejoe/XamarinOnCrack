import 'package:flutter_module/injectable.config.dart';
import 'package:get_it/get_it.dart';
import 'package:injectable/injectable.dart';

const standaloneEnvironment = Environment('standalone');
const integratedEnvironment = Environment('integrated');

final GetIt getIt = GetIt.instance;

@injectableInit
void configureInjection(String env) {
  $initGetIt(getIt, environment: env);
}