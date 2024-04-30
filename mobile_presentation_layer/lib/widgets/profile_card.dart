import 'package:flutter/material.dart';
import 'package:mobile_presentation_layer/utils/theme.dart';

class ProfileCardWidget extends StatelessWidget {
  final String title;
  final String desc;
  final IconData icon;
  final Color iconColor;

  const ProfileCardWidget(
      {Key? key,
      required this.title,
      required this.desc,
      required this.icon,
      required this.iconColor})
      : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Card(
      color: AppTheme.cardColor,
      elevation: 0.0,
      child: Padding(
        padding: const EdgeInsets.all(7.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: <Widget>[
            Icon(icon, color: iconColor),
            SizedBox(height: 25.0),
            Text(
              '$title',
              style: AppTheme.cardTitleStyle(context),
            ),
            Text(
              '$desc',
              style: AppTheme.cardDescStyle(context),
            ),
          ],
        ),
      ),
    );
  }
}
