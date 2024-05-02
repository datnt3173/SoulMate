import 'package:flutter/material.dart';
import 'package:soulmate_match/pages/home/main_home.dart';

class LoginAccount extends StatefulWidget {
  static String tag = 'login-page';
  @override
  _LoginPageState createState() => new _LoginPageState();
}

class _LoginPageState extends State<LoginAccount> {
  TextEditingController emailController = TextEditingController();
  TextEditingController passwordController = TextEditingController();
  bool _obscureText = true;
  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;
    final double deviceWidth = screenSize.width;
    final warningMessage = Container(
      padding: EdgeInsets.all(16.0),
      decoration: BoxDecoration(
        color: Colors.yellow, // Màu nền
        borderRadius: BorderRadius.circular(10.0), // Bo góc
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            'Cảnh báo!',
            style: TextStyle(
              fontSize: 20.0,
              fontWeight: FontWeight.bold,
              color: Colors.red,
            ),
          ),
          SizedBox(height: 10.0),
          Text(
            'Hãy tuân thủ các quy định về bảo mật và tránh các hành vi vi phạm cộng đồng.',
            style: TextStyle(
              fontSize: 16.0,
              color: Colors.black,
            ),
          ),
        ],
      ),
    );

    final email = TextFormField(
      keyboardType: TextInputType.emailAddress,
      autofocus: false,
      controller: emailController,
      decoration: InputDecoration(
        hintText: 'Email',
        contentPadding: EdgeInsets.symmetric(horizontal: 20.0, vertical: 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
      ),
      style: TextStyle(fontSize: deviceWidth * 0.04),
    );

    final password = TextFormField(
      autofocus: false,
      controller: passwordController,
      obscureText: _obscureText,
      decoration: InputDecoration(
        hintText: 'Password',
        contentPadding: EdgeInsets.symmetric(horizontal: 20.0, vertical: 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        suffixIcon: IconButton(
          icon: Icon(
            _obscureText ? Icons.visibility_off : Icons.visibility,
            color: Colors.grey,
          ),
          onPressed: () {
            setState(() {
              _obscureText = !_obscureText;
            });
          },
        ),
      ),
      style: TextStyle(
        fontSize: deviceWidth * 0.04,
      ),
    );

    final forgotPasswordButton = Expanded(
      child: TextButton(
        onPressed: () {},
        child: Text('Quên mật khẩu?', style: TextStyle(color: Colors.blue)),
      ),
    );

    final registerButton = Expanded(
      child: TextButton(
        onPressed: () {},
        child: Text('Đăng ký tài khoản', style: TextStyle(color: Colors.blue)),
      ),
    );

    final loginButton = Padding(
      padding: EdgeInsets.symmetric(vertical: 16.0),
      child: ElevatedButton(
        style: ElevatedButton.styleFrom(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(24),
          ),
          backgroundColor: Colors.lightBlueAccent,
        ),
        onPressed: () {
          String email = emailController.text;
          String password = passwordController.text;
          print('Email: $email');
          print('Password: $password');
          // Điều hướng sang trang mới sau khi đăng nhập thành công
          Navigator.pushReplacement(
            context,
            MaterialPageRoute(
                builder: (context) =>
                    HomePage()), // Thay HomePage() bằng trang bạn muốn chuyển đến
          );
        },
        child: Text('Log In',
            style:
                TextStyle(fontSize: deviceWidth * 0.04, color: Colors.white)),
      ),
    );

    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: ListView(
          shrinkWrap: true,
          padding: EdgeInsets.symmetric(horizontal: 24.0),
          children: <Widget>[
            warningMessage,
            SizedBox(height: 48.0),
            email,
            SizedBox(height: 8.0),
            password,
            SizedBox(height: 24.0),
            loginButton,
            SizedBox(height: 16.0),
            Row(
              children: [
                forgotPasswordButton,
                SizedBox(width: 8.0),
                registerButton,
              ],
            ),
          ],
        ),
      ),
    );
  }
}
