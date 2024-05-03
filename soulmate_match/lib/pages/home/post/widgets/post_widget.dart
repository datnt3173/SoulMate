import 'package:flutter/material.dart';

class PostMenu extends StatelessWidget {
  final bool isLoggedIn;
  final VoidCallback? onDelete;
  final VoidCallback? onEdit;
  final VoidCallback? onReport;

  const PostMenu({
    Key? key,
    required this.isLoggedIn,
    this.onDelete,
    this.onEdit,
    this.onReport,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return PopupMenuButton<String>(
      itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
        if (isLoggedIn) ...[
          if (onDelete != null) buildMenuItem('Xóa bài viết'),
          if (onEdit != null) buildMenuItem('Chỉnh sửa bài viết'),
        ] else ...[
          buildMenuItem('Lưu bài viết'),
          buildMenuItem('Báo cáo vi phạm'),
        ],
        if (onReport != null) buildMenuItem('Báo cáo bài viết'),
      ],
      onSelected: (String value) {
        switch (value) {
          case 'Xóa bài viết':
            onDelete?.call();
            break;
          case 'Chỉnh sửa bài viết':
            onEdit?.call();
            break;
          case 'Báo cáo bài viết':
            onReport?.call();
            break;
          default:
            break;
        }
      },
    );
  }

  PopupMenuItem<String> buildMenuItem(String title) {
    return PopupMenuItem<String>(
      value: title,
      child: Text(title),
    );
  }
}

class PostWidget extends StatefulWidget {
  final String userName;
  final String content;
  final String date;
  final int like;
  final int comment;
  final List<String> imageURLs;

  const PostWidget({
    Key? key,
    required this.userName,
    required this.content,
    required this.date,
    required this.like,
    required this.comment,
    required this.imageURLs,
  }) : super(key: key);

  @override
  _PostWidgetState createState() => _PostWidgetState();
}

class _PostWidgetState extends State<PostWidget> {
  bool isLiked = false;

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(16.0),
      margin: EdgeInsets.symmetric(vertical: 8.0, horizontal: 10.0),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(15.0),
        boxShadow: [
          BoxShadow(
            color: Colors.grey.withOpacity(0.5),
            spreadRadius: 2,
            blurRadius: 5,
            offset: Offset(0, 3),
          ),
        ],
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Row(
                children: [
                  CircleAvatar(
                    radius: 20,
                    backgroundColor: Colors.grey,
                    child: Text(
                      widget.userName.substring(0, 1).toUpperCase(),
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 20,
                        color: Colors.white,
                      ),
                    ),
                  ),
                  SizedBox(width: 8), // Khoảng cách giữa avatar và username
                  Text(
                    widget.userName,
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ],
              ),
              PostMenu(
                isLoggedIn: true, // Thay đổi trạng thái đăng nhập ở đây
                onDelete: () {
                  // Xử lý khi người dùng chọn xóa bài viết
                },
                onEdit: () {
                  // Xử lý khi người dùng chọn chỉnh sửa bài viết
                },
                onReport: () {
                  // Xử lý khi người dùng chọn báo cáo bài viết
                },
              ),
            ],
          ),
          SizedBox(height: 8.0),
          Wrap(
            spacing: 5.0,
            runSpacing: 5.0,
            children: widget.imageURLs
                .take(3)
                .map((url) => Image.network(
                      url,
                      fit: BoxFit.cover,
                      width: 90,
                      height: 100,
                    ))
                .toList(),
          ),
          if (widget.imageURLs.length > 3)
            TextButton(
              onPressed: () {},
              child: Text(
                'Xem thêm (${widget.imageURLs.length - 3} ảnh)',
                style: TextStyle(color: Colors.blue),
              ),
            ),
          SizedBox(height: 4.0),
          Text(
            widget.content,
            maxLines: 3,
            overflow: TextOverflow.ellipsis,
            style: TextStyle(
              fontSize: 14,
            ),
          ),
          SizedBox(height: 8.0),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                widget.date,
                style: TextStyle(
                  color: Colors.grey,
                ),
              ),
              Row(
                children: [
                  IconButton(
                    onPressed: () {
                      setState(() {
                        isLiked = !isLiked;
                      });
                    },
                    icon: Icon(
                      isLiked ? Icons.favorite : Icons.favorite_border,
                      color: isLiked ? Colors.red : null,
                    ),
                  ),
                  SizedBox(width: 8.0),
                  IconButton(
                    onPressed: () {
                      // Xử lý khi nhấn nút bình luận
                    },
                    icon: Icon(Icons.comment),
                  ),
                ],
              ),
            ],
          ),
        ],
      ),
    );
  }
}
