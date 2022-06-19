
import 'package:auto_route/auto_route.dart';
import 'package:flutter/material.dart';

import 'package:flutter_module/pages/home_page.dart';
import 'package:flutter_module/pages/permission_page.dart';

part 'router.gr.dart';

@MaterialAutoRouter(
  replaceInRouteName: 'Page,Route',
  routes: <AutoRoute>[
    AutoRoute(page: HomePage, initial: true),
    AutoRoute(page: PermissionPage),
  ],
)
class AppRouter extends _$AppRouter{}