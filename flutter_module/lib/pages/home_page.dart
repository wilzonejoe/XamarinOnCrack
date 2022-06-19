import 'package:auto_route/auto_route.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_hooks/flutter_hooks.dart';
import 'package:flutter_module/blocs/home_page/home_page_bloc.dart';
import 'package:flutter_module/controls/page_grid.dart';
import 'package:flutter_module/injectable.dart';
import 'package:flutter_module/services/Interfaces/i_navigation_service.dart';

class HomePage extends HookWidget implements AutoRouteWrapper {
  late INavigationService _navigationService;

  HomePage({Key? key}) : super(key: key) {
    _navigationService = getIt<INavigationService>();
  }

  @override
  Widget wrappedRoute(BuildContext context) => MultiBlocProvider(
        providers: [BlocProvider(create: (context) => getIt<HomePageBloc>())],
        child: this,
      );

  @override
  Widget build(BuildContext context) {
    return MultiBlocListener(
        listeners: [
          BlocListener<HomePageBloc, HomePageState>(
            listener: (context, state) {},
          ),
        ],
        child: Scaffold(
            appBar: AppBar(title: const Text("Home Page")),
            body: Center(
                child: PageGrid([
              _createMenuButton(
                  Icons.lock,
                  "to",
                  () => _navigationService.navigateTo(
                      context, "/permission-page")),
              _createMenuButton(
                  Icons.lock,
                  "back",
                  () => _navigationService.navigateBack(context))
            ]))));
  }

  Widget _createMenuButton(
      IconData? icon, String label, void Function()? onPressed) {
    return ElevatedButton(
      style: ElevatedButton.styleFrom(
        onPrimary: Colors.black87,
        primary: Colors.grey[300],
      ),
      onPressed: onPressed,
      child: Column(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Align(
            alignment: Alignment.center,
            child: Icon(
              icon,
              size: 36.0,
            ),
          ),
          Align(alignment: Alignment.center, child: Text(label))
        ],
      ),
    );
  }
}
