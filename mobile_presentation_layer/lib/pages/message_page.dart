import 'package:flutter/material.dart';

class CustomSearchBar extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.blue, // Màu nền của thanh navigation bar
      padding: EdgeInsets.symmetric(
          horizontal: 20, vertical: 10), // Khoảng cách lề ngang và dọc
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(
                hintText: 'Tìm kiếm', // Gợi ý cho ô tìm kiếm
                hintStyle: TextStyle(color: Colors.white), // Màu chữ của gợi ý
                border: InputBorder.none, // Không có đường viền
              ),
              style: TextStyle(
                  color: Colors.white), // Màu chữ của nội dung nhập vào
            ),
          ),
          SizedBox(width: 10), // Khoảng cách giữa ô tìm kiếm và nút tìm kiếm
          IconButton(
            onPressed: () {
              // Xử lý khi nút tìm kiếm được nhấn
            },
            icon: Icon(Icons.search), // Biểu tượng của nút tìm kiếm
            color: Colors.white, // Màu của biểu tượng
          ),
        ],
      ),
    );
  }
}

class MessageNotificationBar extends StatelessWidget {
  final String name;
  final String message;

  const MessageNotificationBar(
      {Key? key, required this.name, required this.message})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity, // Chiều rộng bằng toàn bộ màn hình
      height: 100, // Chiều cao của thanh thông báo
      padding: EdgeInsets.symmetric(horizontal: 20), // Khoảng cách lề ngang
      color: Colors.blue, // Màu nền của thanh thông báo
      child: Row(
        children: [
          Container(
            width: MediaQuery.of(context).size.width *
                0.1, // Chiều rộng của hình tròn là 10% chiều rộng màn hình
            height: 100, // Chiều cao của hình tròn
            decoration: BoxDecoration(
              shape: BoxShape.circle, // Hình dạng hình tròn
              color: Colors.white, // Màu nền của hình tròn
            ),
            child: Center(
              child: Icon(
                Icons
                    .person, // Biểu tượng người dùng (có thể thay đổi thành biểu tượng mong muốn)
                size: 30, // Kích thước của biểu tượng người dùng
                color: Colors.blue, // Màu của biểu tượng người dùng
              ),
            ),
          ),
          SizedBox(width: 20), // Khoảng cách giữa hình tròn và nội dung
          Expanded(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  name, // Tên người dùng
                  style: TextStyle(
                    color: Colors.white, // Màu chữ
                    fontSize: 18, // Cỡ chữ
                    fontWeight: FontWeight.bold, // Độ đậm của chữ
                  ),
                ),
                SizedBox(height: 5), // Khoảng cách giữa tên và tin nhắn
                Text(
                  message, // Tin nhắn
                  style: TextStyle(
                    color: Colors.white, // Màu chữ
                    fontSize: 14, // Cỡ chữ
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
