import 'package:flutter/material.dart';
import 'package:mobile_presentation_layer/pages/login_page.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.pink[100],
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            CircleAvatar(
              radius: 80,
              backgroundImage: AssetImage(
                'assets/web/icons/dating.png',
              ),
            ),
            SizedBox(height: 10),
            Text(
              'Kết nối với SoulMate!',
              style: TextStyle(
                fontSize: 18.0,
                fontFamily: 'Roboto',
                fontWeight: FontWeight.bold,
                fontStyle: FontStyle.italic,
                color: Colors.grey[800],
              ),
            ),

            SizedBox(height: 10), // Khoảng cách giữa các nút
            Container(
              width: double
                  .infinity, // Kích thước rộng bằng chiều rộng của màn hình
              padding: EdgeInsets.symmetric(
                  horizontal: 100), // Khoảng cách với hai bên lề
              child: ElevatedButton.icon(
                onPressed: () {
                  // Xử lý khi nút được nhấn
                },
                icon: Icon(Icons.facebook, size: 24),
                label: Text(
                  'Đăng nhập bằng FaceBook',
                  style: TextStyle(
                    color: Colors.black, // Màu chữ là trắng
                  ),
                ),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.white,
                  padding: EdgeInsets.symmetric(
                    vertical: 15,
                  ),
                ),
              ),
            ),

            SizedBox(height: 10), // Khoảng cách giữa các nút
            Container(
              width: double
                  .infinity, // Kích thước rộng bằng chiều rộng của màn hình
              padding: EdgeInsets.symmetric(
                  horizontal: 100), // Khoảng cách với hai bên lề
              child: ElevatedButton.icon(
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => LoginPage()),
                  );
                },
                icon: Icon(Icons.face, size: 24),
                label: Text(
                  'Đăng nhập bằng Tài khoản',
                  style: TextStyle(
                    color: Colors.black, // Màu chữ là trắng
                  ),
                ),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.white,
                  padding: EdgeInsets.symmetric(
                    vertical: 15,
                  ),
                ),
              ),
            ),

            SizedBox(height: 10),
            Container(
              width: MediaQuery.of(context).size.width *
                  0.5, // Đặt chiều rộng của Container thành 70% của màn hình
              child: Divider(
                height: 20, // Chiều cao của Divider
                thickness: 2, // Độ dày của Divider
                color: Colors.white, // Màu sắc của Divider
              ),
            ),

            SizedBox(height: 10),

            Container(
              width: double
                  .infinity, // Kích thước rộng bằng chiều rộng của màn hình
              padding: EdgeInsets.symmetric(
                  horizontal: 220), // Khoảng cách với hai bên lề
              child: ElevatedButton(
                onPressed: () {
                  // Xử lý khi nút được nhấn
                },
                style: ElevatedButton.styleFrom(
                  // primary: Colors.white, // Màu nền của nút
                  padding: EdgeInsets.symmetric(vertical: 20),
                ),
                // Sử dụng Row để căn giữa icon và label
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Icon(
                      Icons.g_mobiledata_outlined,
                      size: 24,
                      color: Colors.black, // Màu của icon
                    ),
                    SizedBox(width: 0), // Khoảng cách giữa icon và label
                    // Text(
                    //   'Đăng nhập bằng Google',
                    //   style: TextStyle(
                    //     color: Colors.black, // Màu của chữ
                    //   ),
                    // ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
