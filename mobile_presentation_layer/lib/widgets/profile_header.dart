import 'package:flutter/material.dart';

class ProfileHeaderWidget extends StatelessWidget {
  final String name;
  final String email;
  final String bio;

  const ProfileHeaderWidget({
    Key? key,
    required this.name,
    required this.email,
    required this.bio,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(0),
      color: Colors.grey[200], // Màu nền của khung
      child: Row(
        children: [
          // Hình tròn chiếm 30% bên trái
          Container(
            width: MediaQuery.of(context).size.width * 0.3,
            height: MediaQuery.of(context).size.width * 0.4,
            decoration: BoxDecoration(
              shape: BoxShape.circle,
              color: Colors.blue, // Màu của hình tròn
            ),
          ),
          SizedBox(width: 10.0), // Khoảng cách giữa hình tròn và văn bản

          // Cột chứa văn bản bên phải
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                // Tiêu đề
                Text(
                  '$name',
                  style: TextStyle(
                    fontSize: 20.0,
                  ),
                ),
                SizedBox(height: 10.0), // Khoảng cách giữa các dòng văn bản
                // Email
                Text(
                  'Email: $email',
                  style: TextStyle(
                    fontSize: 12.0,
                  ),
                ),
                // Bio
                Text(
                  'Bio: $bio',
                  style: TextStyle(
                    fontSize: 12.0,
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
