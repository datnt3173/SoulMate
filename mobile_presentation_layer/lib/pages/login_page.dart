import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:mobile_presentation_layer/pages/main_page.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:mobile_presentation_layer/config/api_constants.dart';
import 'package:flutter_easyloading/flutter_easyloading.dart';

class LoginPage extends StatelessWidget {
  LoginPage({Key? key}) : super(key: key);

  final GlobalKey<ScaffoldMessengerState> _scaffoldMessengerKey =
      GlobalKey<ScaffoldMessengerState>();

  Future<void> login(
      String email, String password, BuildContext context) async {
    EasyLoading.show(status: 'Đang đăng nhập...');

    final Uri apiUrl = Uri.parse('${ApiConstants.baseUrl}/api/User/Login');
    final Map<String, dynamic> data = {
      'username': email,
      'password': password,
    };

    try {
      final http.Response response = await http.post(
        apiUrl,
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(data),
      );

      if (response.statusCode == 200) {
        print('Đăng nhập thành công!');

        SharedPreferences prefs = await SharedPreferences.getInstance();
        prefs.setString('username', email);
        prefs.setString('password', password);

        _scaffoldMessengerKey.currentState?.showSnackBar(
          SnackBar(content: Text('Đăng nhập thành công!')),
        );

        Navigator.pushReplacement(
          context,
          MaterialPageRoute(builder: (context) => MainPage()),
        );
      } else {
        print('Đăng nhập thất bại. Mã lỗi: ${response.statusCode}');
        EasyLoading.dismiss();
        showErrorMessage(context, 'Đăng nhập thất bại. Vui lòng thử lại!');
      }
    } catch (e) {
      EasyLoading.dismiss();
      showErrorMessage(context, 'Đăng nhập thất bại. Vui lòng thử lại!');
    }
  }

  void showErrorMessage(BuildContext context, String message) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Đăng nhập thất bại'),
          content: Text(message),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.pop(context);
              },
              child: Text('OK'),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    String email = '';
    String password = '';

    return Scaffold(
      key: _scaffoldMessengerKey,
      backgroundColor: Colors.white,
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 24.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              Text(
                'Đăng nhập',
                textAlign: TextAlign.center,
                style: TextStyle(
                  fontSize: 32,
                  fontWeight: FontWeight.bold,
                  color: Colors.black,
                ),
              ),
              SizedBox(height: 48),
              TextField(
                onChanged: (value) {
                  email = value;
                },
                keyboardType: TextInputType.emailAddress,
                decoration: InputDecoration(
                  hintText: 'Email',
                  border: OutlineInputBorder(),
                ),
              ),
              SizedBox(height: 16),
              TextField(
                onChanged: (value) {
                  password = value;
                },
                obscureText: true,
                decoration: InputDecoration(
                  hintText: 'Mật khẩu',
                  border: OutlineInputBorder(),
                ),
              ),
              SizedBox(height: 24),
              ElevatedButton(
                onPressed: () {
                  login(email, password, context);
                },
                child: Text(
                  'Đăng nhập',
                  style: TextStyle(fontSize: 18),
                ),
                style: ElevatedButton.styleFrom(
                  padding: EdgeInsets.symmetric(vertical: 16),
                ),
              ),
              SizedBox(height: 24),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text('Bạn chưa có tài khoản?'),
                  SizedBox(width: 4),
                  TextButton(
                    onPressed: () {
                      // Chuyển đến trang đăng ký
                    },
                    child: Text(
                      'Đăng ký ngay',
                      style: TextStyle(
                        color: Colors.blue,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
