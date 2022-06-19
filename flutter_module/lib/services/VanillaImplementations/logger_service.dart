import 'package:injectable/injectable.dart';

import 'package:flutter_module/services/Interfaces/i_logger_service.dart';

@Injectable(as: ILoggerService)
class LoggerService extends ILoggerService {
  @override
  void logError(String page, String event) {
  }

  @override
  void logInfo(String page, String event) {
  }
}