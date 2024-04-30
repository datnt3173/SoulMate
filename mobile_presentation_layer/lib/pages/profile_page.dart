import 'package:flutter/material.dart';
import 'package:mobile_presentation_layer/widgets/profile_add.dart';
import 'package:mobile_presentation_layer/widgets/profile_card.dart';
import 'package:mobile_presentation_layer/widgets/profile_header.dart';
import 'package:mobile_presentation_layer/utils/theme.dart';

class ProfilePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      // appBar: AppBar(
      //   elevation: 0.0,
      //   leading: IconButton(
      //     onPressed: () {},
      //     icon: Icon(Icons.keyboard_backspace, color: Colors.white),
      //   ),
      //   actions: <Widget>[
      //     ProfileImageWidget(),
      //   ],
      // ),

      body: Container(
        padding: EdgeInsets.all(0.0),
        color: Colors.white,
        width: double.infinity,
        height: double.infinity,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            SizedBox(height: 0),
            ProfileHeaderWidget(
              name: 'Nhâm Tuấn Đạt',
              email: 'example@example.com',
              bio: 'This is my bio.',
            ),
            SizedBox(height: 35.0),
            Expanded(
              child: GridView.count(
                physics: BouncingScrollPhysics(),
                crossAxisCount: 2,
                mainAxisSpacing: 10.0,
                crossAxisSpacing: 10.0,
                children: <Widget>[
                  ProfileCardWidget(
                    title: 'Bài đăng',
                    desc: '4',
                    icon: Icons.list,
                    iconColor: AppTheme.iconColors[0],
                  ),
                  ProfileCardWidget(
                    title: 'Kết nối',
                    desc: '4',
                    icon: Icons.event_note,
                    iconColor: AppTheme.iconColors[1],
                  ),
                  ProfileCardWidget(
                    title: 'Sự kiện',
                    desc: '11',
                    icon: Icons.calendar_today,
                    iconColor: AppTheme.iconColors[2],
                  ),
                  ProfileCardWidget(
                    title: 'Báo cáo',
                    desc: '3',
                    icon: Icons.report,
                    iconColor: AppTheme.iconColors[3],
                  ),
                  ProfileCardWidget(
                    title: 'Hình ảnh',
                    desc: '428 photos',
                    icon: Icons.camera,
                    iconColor: AppTheme.iconColors[4],
                  ),
                  ProfileAddCardWidget(),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
