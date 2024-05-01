import 'package:flutter/material.dart';
import 'package:mobile_presentation_layer/utils/theme.dart';

class ProfileCardWidget extends StatefulWidget {
  final String title;
  final String desc;
  final IconData icon;
  final Color iconColor;
  final Function()? onTap;

  const ProfileCardWidget({
    Key? key,
    required this.title,
    required this.desc,
    required this.icon,
    required this.iconColor,
    this.onTap,
  }) : super(key: key);

  @override
  _ProfileCardWidgetState createState() => _ProfileCardWidgetState();
}

class _ProfileCardWidgetState extends State<ProfileCardWidget> {
  bool _isHovered = false;

  @override
  Widget build(BuildContext context) {
    return MouseRegion(
      onEnter: (event) {
        setState(() {
          _isHovered = true;
        });
      },
      onExit: (event) {
        setState(() {
          _isHovered = false;
        });
      },
      child: GestureDetector(
        onTap: widget.onTap,
        child: Card(
          color: AppTheme.cardColor,
          elevation: 0.0,
          child: AnimatedContainer(
            duration: Duration(milliseconds: 200),
            decoration: BoxDecoration(
              gradient: _isHovered
                  ? LinearGradient(
                      colors: [Colors.grey[200]!, AppTheme.cardColor],
                      begin: Alignment.topCenter,
                      end: Alignment.bottomCenter,
                    )
                  : null,
            ),
            padding: const EdgeInsets.all(25.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: <Widget>[
                Icon(widget.icon, color: widget.iconColor),
                SizedBox(height: 25.0),
                Text(
                  '${widget.title}',
                  style: AppTheme.cardTitleStyle(context),
                ),
                Text(
                  '${widget.desc}',
                  style: AppTheme.cardDescStyle(context),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
