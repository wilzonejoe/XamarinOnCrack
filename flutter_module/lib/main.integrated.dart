import 'package:flutter/material.dart';

import 'package:flutter_module/app.dart';
import 'package:flutter_module/injectable.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  configureInjection(integratedEnvironment.name);
  runApp(App());
}