import 'package:flutter/material.dart';

class CustomSearchBar extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(40), // Bo góc container
        border: Border.all(
          color: Colors.black, // Màu viền
          width: 1, // Độ rộng viền
        ),
      ),
      padding: EdgeInsets.symmetric(horizontal: 10, vertical: 1),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(
                hintText: 'Tìm kiếm',
                hintStyle: TextStyle(color: Colors.black),
                border: InputBorder.none,
              ),
              style: TextStyle(color: Colors.black),
            ),
          ),
          SizedBox(width: 10),
          IconButton(
            onPressed: () {},
            icon: Icon(Icons.search),
            color: Colors.black,
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
      width: double.infinity,
      height: 100,
      padding: EdgeInsets.symmetric(horizontal: 20),
      color: Colors.white,
      child: Row(
        children: [
          Container(
            width: MediaQuery.of(context).size.width * 0.2,
            height: 100,
            decoration: BoxDecoration(
              shape: BoxShape.circle,
              color: Colors.white,
              border: Border.all(
                color: Colors.black, // Màu viền
                width: 2, // Độ rộng viền
              ),
            ),
            child: Center(
              child: Icon(
                Icons.person,
                size: 30,
                color: Colors.black,
              ),
            ),
          ),
          SizedBox(width: 20),
          Expanded(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  name,
                  style: TextStyle(
                    color: Colors.black,
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                SizedBox(height: 5),
                Text(
                  message,
                  style: TextStyle(
                    color: Colors.black,
                    fontSize: 14,
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

void main() {
  runApp(
    MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          elevation: 1.0,
          backgroundColor: Colors.black,
          title: Text('App Title'),
          bottom: PreferredSize(
            preferredSize: Size.fromHeight(100),
            child: Column(
              children: [
                SizedBox(height: 10), // Add some space above search bar
                CustomSearchBar(),
              ],
            ),
          ),
        ),
        body: Column(
          children: [
            MessageNotificationBar(
              name: 'Tên người dùng',
              message: 'Tin nhắn của người dùng',
            ),
          ],
        ),
      ),
    ),
  );
}
