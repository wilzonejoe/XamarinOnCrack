import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_module/controls/page_grid.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(title: const Text("Home Page")),
        body: Center(
            child: PageGrid([
          Image.network('https://picsum.photos/250?image=1'),
          Image.network('https://picsum.photos/250?image=2'),
          Image.network('https://picsum.photos/250?image=3'),
          Image.network('https://picsum.photos/250?image=4'),
          _createMenuButton(Icons.lock, "permission", () => {

          })
        ])),
      ),
    );
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
          Align(
              alignment: Alignment.center,
              child: Text(label)
          )
        ],
      ),
    );
  }
}
