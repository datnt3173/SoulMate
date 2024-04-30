import 'package:flutter/material.dart';
import 'package:mobile_presentation_layer/pages/home_page.dart';

class MyApp extends StatelessWidget {
  final Widget initialPage;

  const MyApp({Key? key, required this.initialPage}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'SoulMate',
      home: initialPage,
    );
  }
}

void main() {
  runApp(
    MyApp(initialPage: MainPage()),
  );
}
