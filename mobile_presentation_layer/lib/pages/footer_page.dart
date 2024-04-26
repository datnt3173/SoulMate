import 'package:flutter/material.dart';

class Footer extends StatelessWidget {
  const Footer({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        color: Colors.grey[200],
        padding: EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            Text(
              'Tiếp tục đăng ký có nghĩa là bạn đã đọc và đồng ý với',
              style: TextStyle(
                fontSize: 12.0, // Điều chỉnh cỡ chữ
                color: Colors.black,
              ),
            ),
            SizedBox(height: 8.0),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                TextButton(
                  onPressed: () {},
                  child: Text(
                    'Điều khoản sử dụng',
                    style: TextStyle(
                      fontSize: 12.0, // Điều chỉnh cỡ chữ
                      color: Colors.blue,
                    ),
                  ),
                ),
                Text(
                  ', ',
                  style: TextStyle(
                    fontSize: 12.0, // Điều chỉnh cỡ chữ
                    color: Colors.black,
                  ),
                ),
                TextButton(
                  onPressed: () {},
                  child: Text(
                    'Chính sách bảo mật',
                    style: TextStyle(
                      fontSize: 12.0, // Điều chỉnh cỡ chữ
                      color: Colors.blue,
                    ),
                  ),
                ),
                Text(
                  ', và ',
                  style: TextStyle(
                    fontSize: 12.0, // Điều chỉnh cỡ chữ
                    color: Colors.black,
                  ),
                ),
                TextButton(
                  onPressed: () {},
                  child: Text(
                    'Chính sách cookies',
                    style: TextStyle(
                      fontSize: 12.0, // Điều chỉnh cỡ chữ
                      color: Colors.blue,
                    ),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
