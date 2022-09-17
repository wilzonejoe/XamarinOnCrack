import 'dart:io';

import 'package:flutter/material.dart';

class PermissionPage extends StatelessWidget {
  const PermissionPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(title: const Text("Permission Page")),
        body: Column(
          children: [
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                onPrimary: Colors.black87,
                primary: Colors.grey[300],
              ),
              onPressed: () => {},
              child: Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: const [
                  Align(alignment: Alignment.center, child: Text("Ask for Location Permission"))
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
