import 'package:flutter/material.dart';

class AppTheme {
  static final Color primary = Color(0xFF242133);
  static final Color cardColor = Color(0xFF37334d);
  static final Color addCardColor = Color(0xFF03DAC5);
  static final List<Color> iconColors = [
    Colors.blue,
    Color(0xFF27cf53),
    Color(0xFFf3a643),
    Color(0xFFbb49dc),
    Color(0xFF03DAC5),
  ];

  static TextStyle profileHeaderStyle(BuildContext context) => TextStyle(
        color: Colors.black,
        fontWeight: FontWeight.bold,
        fontSize: Theme.of(context).textTheme.titleLarge!.fontSize,
      );

  static TextStyle cardTitleStyle(BuildContext context) => TextStyle(
        color: Colors.white,
        fontWeight: FontWeight.bold,
        fontSize: Theme.of(context).textTheme.titleLarge!.fontSize,
      );

  static TextStyle cardDescStyle(BuildContext context) => TextStyle(
        color: Colors.white,
        fontSize: Theme.of(context).textTheme.titleLarge!.fontSize,
      );
}
