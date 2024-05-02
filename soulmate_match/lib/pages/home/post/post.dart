import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class HomePost extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    // Lấy thời gian hiện tại
    DateTime now = DateTime.now();
    // Format ngày tháng năm
    String formattedDate = DateFormat('dd/MM/yyyy').format(now);

    return Scaffold(
      appBar: AppBar(
        //backgroundColor: Colors.lightBlue[100],
        title: Text(
          'SoulMate ngày $formattedDate',
          style: TextStyle(
            fontSize: 16, // Kích thước chữ
            fontWeight: FontWeight.bold, // Chữ in đậm
          ),
        ),
        automaticallyImplyLeading: false, // Tắt nút trở lại
      ),
      body: Row(
        mainAxisAlignment:
            MainAxisAlignment.spaceBetween, // Đảm bảo các ô nằm cách đều nhau
        children: [
          Expanded(
            child: Container(
              height: MediaQuery.of(context).size.height * 0.15,
              color: Colors.red,
              child: Center(child: Text('Kết nối')),
            ),
          ),
          SizedBox(width: 8), // Khoảng cách giữa các ô
          Expanded(
            child: Container(
              height: MediaQuery.of(context).size.height * 0.15,
              color: Colors.blue,
              child: Center(child: Text('Box 2')),
            ),
          ),
          SizedBox(width: 8), // Khoảng cách giữa các ô
          Expanded(
            child: Container(
              height: MediaQuery.of(context).size.height * 0.15,
              color: Colors.green,
              child: Center(child: Text('Box 3')),
            ),
          ),
        ],
      ),
    );
  }
}

void main() {
  runApp(MaterialApp(
    debugShowCheckedModeBanner: false,
    home: HomePost(),
  ));
}
