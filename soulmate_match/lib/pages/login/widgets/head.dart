import 'package:flutter/material.dart';
import 'package:soulmate_match/pages/login/account.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return Scaffold(
      body: Stack(
        // Sử dụng Stack để chồng phần footer lên dưới cùng
        children: [
          Center(
            child: Container(
              padding: const EdgeInsets.all(20.0),
              width: screenSize.width * 0.8,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  CircleAvatar(
                    radius: 90, // Bán kính của hình tròn
                    backgroundColor: Colors.transparent, // Màu nền trong suốt
                    backgroundImage: NetworkImage(
                      'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRUGToQSf8bKe54wxdxwW2X3v-MzhhRjXJ-Mn85GQ7OUw&s', // Thay đổi URL ảnh tại đây
                    ),
                  ),
                  SizedBox(height: 50.0),
                  ElevatedButton(
                    onPressed: () {
                      // Xử lý đăng nhập bằng Facebook
                    },
                    style: ButtonStyle(
                      backgroundColor: MaterialStateProperty.all<Color>(
                          Colors.blue), // Màu nền xanh
                    ),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(
                          Icons.facebook,
                          color: Colors.white, // Màu icon trắng
                        ),
                        const SizedBox(
                            width: 8), // Khoảng cách giữa icon và chữ
                        Text(
                          'Login with Facebook',
                          style:
                              TextStyle(color: Colors.white), // Màu chữ trắng
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 2.0),
                  ElevatedButton(
                    onPressed: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => LoginAccount()),
                      );
                    },
                    style: ButtonStyle(
                      backgroundColor:
                          MaterialStateProperty.all<Color>(Colors.white),
                    ),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(
                          Icons.face,
                          color: Colors.black,
                        ),
                        const SizedBox(width: 8),
                        Text(
                          'Login with Account',
                          style: TextStyle(color: Colors.black),
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 2.0),
                  ElevatedButton(
                    onPressed: () {},
                    style: ButtonStyle(
                      backgroundColor:
                          MaterialStateProperty.all<Color>(Colors.yellow),
                    ),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(
                          Icons.g_mobiledata, // hoặc Icons.g_mobiledata
                          color: Colors.black, // Màu icon trắng
                          size: 24, // Kích thước icon
                        ),
                        const SizedBox(
                            width: 8), // Khoảng cách giữa icon và chữ
                        Text(
                          'Login with Google',
                          style: TextStyle(color: Colors.black),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
          Align(
            // Footer ở dưới cùng
            alignment: Alignment.bottomCenter,
            child: Container(
              padding: const EdgeInsets.all(20.0),
              color: Colors.grey[300], // Màu nền của footer
              width: screenSize.width, // Chiều rộng bằng chiều rộng màn hình
              child: Text(
                'Tuân thủ các quy định về bảo mật và chính sách cộng đồng.',
                textAlign: TextAlign.center, // Nội dung thông báo
                style: TextStyle(
                  fontSize: 8.0, // Cỡ chữ
                  fontWeight: FontWeight.bold, // Đậm
                  color: Colors.black, // Màu chữ
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
