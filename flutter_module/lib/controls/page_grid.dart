import 'package:flutter/material.dart';
import 'package:flutter_module/helpers/screen_helper.dart';
import 'package:flutter_module/models/enumerations/screen_size.dart';

class PageGrid extends StatelessWidget {
  PageGrid(List<Widget> widgetList, {Key? key}) : super(key: key) {
    _widgetList = widgetList;
  }

  late List<Widget> _widgetList;

  @override
  Widget build(BuildContext context) {
    return GridView(
      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
        crossAxisCount: _getGridColumnAmount(context),
      ),
      children: _widgetList,
    );
  }

  int _getGridColumnAmount(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    switch(ScreenHelper.getScreenSize(screenSize.width)) {
      case ScreenSize.extraSmall:
        return 2;
      case ScreenSize.small:
        return 3;
      case ScreenSize.medium:
        return 4;
      case ScreenSize.large:
        return 5;
      case ScreenSize.extraLarge:
        return 7;
    }

    return 2;
  }
}
