import 'package:flutter/material.dart';

class PostPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: CustomRow(), // Sử dụng CustomRow như là title của AppBar
      ),
      body: ListView.builder(
        itemCount: posts.length,
        itemBuilder: (context, index) {
          return ListTile(
            title: Text(posts[index].title),
            subtitle: Text(posts[index].content),
            // Các thông tin khác của bài đăng như tác giả, hình ảnh, ngày đăng, v.v.
          );
        },
      ),
    );
  }
}

class CustomRow extends StatelessWidget implements PreferredSizeWidget {
  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);

  @override
  Widget build(BuildContext context) {
    return Container(
      // Thêm Container để thiết lập màu nền
      color: Colors.grey[200], // Màu nền mới cho CustomRow
      child: Padding(
        padding: const EdgeInsets.all(10.0),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Container(
              width: MediaQuery.of(context).size.width * 0.1,
              height: kToolbarHeight,
              decoration: BoxDecoration(
                shape: BoxShape.circle,
                color: Colors.blue,
              ),
            ),
            Container(
              width: MediaQuery.of(context).size.width * 0.7,
              height: 30.0,
              child: Material(
                color:
                    Colors.transparent, // Đặt màu nền trong suốt cho Material
                child: InkWell(
                  onTap: () {
// Hành động khi nhấn
                    print('Container tapped!');
                  },
                  onTapDown: (TapDownDetails details) {
// Hành động khi nhấn xuống
                    print('Container pressed down!');
                  },
                  onTapUp: (TapUpDetails details) {
// Hành động khi nhả ra
                    print('Container released!');
                  },
                  highlightColor:
                      Colors.grey.withOpacity(0.5), // Màu khi nhấn xuống
                  splashColor:
                      Colors.blue.withOpacity(0.5), // Màu mực lan tỏa khi nhấn
                  borderRadius: BorderRadius.circular(10),
                  child: Center(
                    child: Text(
                      'Nêu cảm nghĩ hiện tại của bạn?',
                      style: TextStyle(fontSize: 18),
                    ),
                  ),
                ),
              ),
              decoration: BoxDecoration(
                border: Border.all(
                  color: Colors.black, // Màu viền
                  width: 1, // Độ dày của viền
                ),
                borderRadius: BorderRadius.circular(20),
              ),
            ),
            Icon(
              Icons.image,
              size: 24,
              color: Colors.green, // Màu sắc của icon
            ),
          ],
        ),
      ),
    );
  }
}

// Class để biểu diễn một bài đăng
class Post {
  final String title;
  final String content;

  Post({
    required this.title,
    required this.content,
  });
}

// Danh sách các bài đăng giả định
List<Post> posts = [
  Post(title: 'Bài đăng 1', content: 'Nội dung bài đăng 1'),
  // Thêm các bài đăng khác vào đây
];
