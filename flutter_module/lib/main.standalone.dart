import 'package:flutter/material.dart';

import 'package:flutter_module/app.dart';
import 'package:flutter_module/injectable.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  configureInjection(standaloneEnvironment.name);
  runApp(App());
}