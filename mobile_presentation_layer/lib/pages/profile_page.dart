import 'package:flutter/material.dart';
import 'package:mobile_presentation_layer/widgets/profile_card.dart';
import 'package:mobile_presentation_layer/widgets/profile_header.dart';
import 'package:mobile_presentation_layer/utils/theme.dart';

class ProfilePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.all(0.0),
        color: Color.fromARGB(255, 186, 228, 238),
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
            SizedBox(height: 0.0),
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
                    onTap: () {
                      // Xử lý khi người dùng chọn "Bài đăng"
                    },
                  ),
                  ProfileCardWidget(
                    title: 'Kết nối',
                    desc: '4',
                    icon: Icons.event_note,
                    iconColor: AppTheme.iconColors[1],
                    onTap: () {
                      // Xử lý khi người dùng chọn "Kết nối"
                    },
                  ),
                  ProfileCardWidget(
                    title: 'Sự kiện',
                    desc: '11',
                    icon: Icons.calendar_today,
                    iconColor: AppTheme.iconColors[2],
                    onTap: () {
                      // Xử lý khi người dùng chọn "Sự kiện"
                    },
                  ),
                  ProfileCardWidget(
                    title: 'Báo cáo',
                    desc: '3',
                    icon: Icons.report,
                    iconColor: AppTheme.iconColors[3],
                    onTap: () {
                      // Xử lý khi người dùng chọn "Báo cáo"
                    },
                  ),
                  ProfileCardWidget(
                    title: 'Hình ảnh',
                    desc: '428 photos',
                    icon: Icons.camera,
                    iconColor: AppTheme.iconColors[4],
                    onTap: () {
                      // Xử lý khi người dùng chọn "Hình ảnh"
                    },
                  ),
                  ProfileCardWidget(
                    title: 'Cài đặt',
                    desc: '',
                    icon: Icons.settings,
                    iconColor: AppTheme.iconColors[4],
                    onTap: () {
                      showModalBottomSheet(
                        context: context,
                        isScrollControlled: true,
                        builder: (BuildContext context) {
                          return SingleChildScrollView(
                            child: Container(
                              padding: EdgeInsets.only(
                                bottom:
                                    MediaQuery.of(context).viewInsets.bottom,
                              ),
                              color: Colors.white,
                              child: Padding(
                                padding: const EdgeInsets.all(16.0),
                                child: Column(
                                  mainAxisSize: MainAxisSize.min,
                                  children: <Widget>[
                                    ListTile(
                                      leading: Icon(Icons.settings),
                                      title: Text('Lựa chọn 1'),
                                      onTap: () {
                                        // Xử lý khi người dùng chọn lựa chọn 1
                                        Navigator.pop(context);
                                      },
                                    ),
                                    ListTile(
                                      leading: Icon(Icons.logout),
                                      title: Text('Đăng xuất'),
                                      onTap: () {
                                        // Xử lý khi người dùng chọn lựa chọn 2
                                        Navigator.pop(context);
                                      },
                                    ),
                                  ],
                                ),
                              ),
                            ),
                          );
                        },
                      );
                    },
                  ),
                  //ProfileAddCardWidget(),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
