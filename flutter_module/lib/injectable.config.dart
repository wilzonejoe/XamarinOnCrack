// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;

import 'blocs/home_page/home_page_bloc.dart' as _i11;
import 'services/IntegratedImplementations/integrated_configuration_service.dart'
    as _i4;
import 'services/IntegratedImplementations/integrated_navigation_service.dart'
    as _i9;
import 'services/Interfaces/i_configuration_service.dart' as _i3;
import 'services/Interfaces/i_logger_service.dart' as _i6;
import 'services/Interfaces/i_navigation_service.dart' as _i8;
import 'services/VanillaImplementations/configuration_service.dart' as _i5;
import 'services/VanillaImplementations/logger_service.dart' as _i7;
import 'services/VanillaImplementations/navigation_service.dart' as _i10;

const String _integrated = 'integrated';
const String _standalone = 'standalone';
// ignore_for_file: unnecessary_lambdas
// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String? environment, _i2.EnvironmentFilter? environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  gh.factory<_i3.IConfigurationService>(
      () => _i4.IntegratedConfigurationService(),
      registerFor: {_integrated});
  gh.factory<_i3.IConfigurationService>(() => _i5.ConfigurationService(),
      registerFor: {_standalone});
  gh.factory<_i6.ILoggerService>(() => _i7.LoggerService());
  gh.factory<_i8.INavigationService>(
      () => _i9.IntegratedNavigationService(get<_i3.IConfigurationService>()),
      registerFor: {_integrated});
  gh.factory<_i8.INavigationService>(() => _i10.IntegratedNavigationService(),
      registerFor: {_standalone});
  gh.factory<_i11.HomePageBloc>(
      () => _i11.HomePageBloc(get<_i8.INavigationService>()));
  return get;
}
