import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import '../widgets/item_container.dart';
import 'package:soulmate_match/pages/home/post/widgets/post_widget.dart';

class HomePost extends StatefulWidget {
  @override
  _HomePostState createState() => _HomePostState();
}

class _HomePostState extends State<HomePost> {
  int selectedIndex = -1;

  @override
  Widget build(BuildContext context) {
    DateTime now = DateTime.now();
    String formattedDate = DateFormat('dd/MM/yyyy').format(now);

    return Scaffold(
      appBar: AppBar(
        title: Text(
          'SoulMate ngày $formattedDate',
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.bold,
          ),
        ),
        automaticallyImplyLeading: false,
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Expanded(
                  child: ItemContainer(
                    color: Colors.red,
                    text: 'Tình yêu',
                    icon: Icons.favorite,
                    onTap: () {
                      setState(() {
                        selectedIndex = 0;
                      });
                    },
                  ),
                ),
                SizedBox(width: 8),
                Expanded(
                  child: ItemContainer(
                    color: Colors.blue,
                    text: 'Hội nhóm',
                    icon: Icons.group,
                    onTap: () {
                      setState(() {
                        selectedIndex = 1;
                      });
                    },
                  ),
                ),
                SizedBox(width: 8),
                Expanded(
                  child: ItemContainer(
                    color: Colors.green,
                    text: 'Bạn bè',
                    icon: Icons.person,
                    onTap: () {
                      setState(() {
                        selectedIndex = 2;
                      });
                    },
                  ),
                ),
              ],
            ),
            SizedBox(height: 10), // Khoảng cách giữa Divider và phần trên
            Container(
              padding: EdgeInsets.symmetric(horizontal: 16.0),
              child: Row(
                children: [
                  Expanded(
                    child: Divider(
                      thickness: 8.0, // Độ dày của thanh kẻ ngang
                      color: Colors.grey,
                    ),
                  ),
                  SizedBox(width: 10), // Khoảng cách giữa Divider và Text
                  Text(
                    'Bài đăng', // Nội dung chữ
                    style: TextStyle(
                      fontSize: 20, // Cỡ chữ
                      fontWeight: FontWeight.bold, // Chữ đậm
                    ),
                  ),
                  SizedBox(width: 10), // Khoảng cách giữa Text và Divider
                  Expanded(
                    child: Divider(
                      thickness: 8.0, // Độ dày của thanh kẻ ngang
                      color: Colors.grey,
                    ),
                  ),
                ],
              ),
            ),
            PostWidget(
              userName: 'Nhâm Tuấn Đạt',
              content: 'Hi hi ịt ẹ m',
              date: '12-5-2024',
              like: 10,
              comment: 5,
              imageURLs: [
                'https://scontent.fhan14-3.fna.fbcdn.net/v/t39.30808-6/432053535_10163403162542926_1541387842787062788_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeG8qPT10uVsuVXSK5V_8gigYMsPU3jAMrhgyw9TeMAyuBO20dwLR2tqp2Qw4SyR2N4&_nc_ohc=Uf2NoMpbYQQQ7kNvgEs5WXs&_nc_ht=scontent.fhan14-3.fna&oh=00_AfBZ6kvkDEXFPJaArAkrLlZUFa6uHJnBBXO_LhhD7cotcg&oe=663A134F',
                'https://scontent.fhan14-5.fna.fbcdn.net/v/t39.30808-6/433600000_10163407031667926_380777595993636346_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeHvRxwlWMHiZQSeoUSrk8WVYApLx3AealFgCkvHcB5qUZwprqVmhzuIYvYdPJ3PsNI&_nc_ohc=fycBoLnkAssQ7kNvgFgQM37&_nc_ht=scontent.fhan14-5.fna&oh=00_AfAoN7Ut6J6lJ5jOIXUUlOrW0T4Wc4jmmW54T42nOp9G1g&oe=6639F025',
                'https://scontent.fhan14-1.fna.fbcdn.net/v/t39.30808-6/431883379_10163383979307926_2154150888895526461_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeET1GYghThD-5DzootdQ9xx-arGHvmRkJL5qsYe-ZGQkrYDaev4yicKDTSeHi4oLig&_nc_ohc=_xjEJRjMS5YQ7kNvgERZt7d&_nc_ht=scontent.fhan14-1.fna&oh=00_AfAMHVtKT6cguTChpjrlfjZf4JBqX6X1p6WgCg4kjEbzhg&oe=663A165D',
                'https://scontent.fhan14-5.fna.fbcdn.net/v/t39.30808-6/433600000_10163407031667926_380777595993636346_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeHvRxwlWMHiZQSeoUSrk8WVYApLx3AealFgCkvHcB5qUZwprqVmhzuIYvYdPJ3PsNI&_nc_ohc=fycBoLnkAssQ7kNvgFgQM37&_nc_ht=scontent.fhan14-5.fna&oh=00_AfAoN7Ut6J6lJ5jOIXUUlOrW0T4Wc4jmmW54T42nOp9G1g&oe=6639F025',
              ],
            ),
            PostWidget(
              userName: 'Nhâm Tuấn Đạt',
              content: 'Hi hi ịt ẹ m',
              date: '12-5-2024',
              like: 10,
              comment: 5,
              imageURLs: [
                'https://scontent.fhan14-3.fna.fbcdn.net/v/t39.30808-6/432053535_10163403162542926_1541387842787062788_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeG8qPT10uVsuVXSK5V_8gigYMsPU3jAMrhgyw9TeMAyuBO20dwLR2tqp2Qw4SyR2N4&_nc_ohc=Uf2NoMpbYQQQ7kNvgEs5WXs&_nc_ht=scontent.fhan14-3.fna&oh=00_AfBZ6kvkDEXFPJaArAkrLlZUFa6uHJnBBXO_LhhD7cotcg&oe=663A134F',
                'https://scontent.fhan14-5.fna.fbcdn.net/v/t39.30808-6/433600000_10163407031667926_380777595993636346_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeHvRxwlWMHiZQSeoUSrk8WVYApLx3AealFgCkvHcB5qUZwprqVmhzuIYvYdPJ3PsNI&_nc_ohc=fycBoLnkAssQ7kNvgFgQM37&_nc_ht=scontent.fhan14-5.fna&oh=00_AfAoN7Ut6J6lJ5jOIXUUlOrW0T4Wc4jmmW54T42nOp9G1g&oe=6639F025',
                'https://scontent.fhan14-1.fna.fbcdn.net/v/t39.30808-6/431883379_10163383979307926_2154150888895526461_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeET1GYghThD-5DzootdQ9xx-arGHvmRkJL5qsYe-ZGQkrYDaev4yicKDTSeHi4oLig&_nc_ohc=_xjEJRjMS5YQ7kNvgERZt7d&_nc_ht=scontent.fhan14-1.fna&oh=00_AfAMHVtKT6cguTChpjrlfjZf4JBqX6X1p6WgCg4kjEbzhg&oe=663A165D',
                'https://scontent.fhan14-5.fna.fbcdn.net/v/t39.30808-6/433600000_10163407031667926_380777595993636346_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeHvRxwlWMHiZQSeoUSrk8WVYApLx3AealFgCkvHcB5qUZwprqVmhzuIYvYdPJ3PsNI&_nc_ohc=fycBoLnkAssQ7kNvgFgQM37&_nc_ht=scontent.fhan14-5.fna&oh=00_AfAoN7Ut6J6lJ5jOIXUUlOrW0T4Wc4jmmW54T42nOp9G1g&oe=6639F025',
              ],
            ),
            PostWidget(
              userName: 'Nhâm Tuấn Đạt',
              content: 'Hi hi ịt ẹ m',
              date: '12-5-2024',
              like: 10,
              comment: 5,
              imageURLs: [
                'https://scontent.fhan14-3.fna.fbcdn.net/v/t39.30808-6/432053535_10163403162542926_1541387842787062788_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeG8qPT10uVsuVXSK5V_8gigYMsPU3jAMrhgyw9TeMAyuBO20dwLR2tqp2Qw4SyR2N4&_nc_ohc=Uf2NoMpbYQQQ7kNvgEs5WXs&_nc_ht=scontent.fhan14-3.fna&oh=00_AfBZ6kvkDEXFPJaArAkrLlZUFa6uHJnBBXO_LhhD7cotcg&oe=663A134F',
                'https://scontent.fhan14-5.fna.fbcdn.net/v/t39.30808-6/433600000_10163407031667926_380777595993636346_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeHvRxwlWMHiZQSeoUSrk8WVYApLx3AealFgCkvHcB5qUZwprqVmhzuIYvYdPJ3PsNI&_nc_ohc=fycBoLnkAssQ7kNvgFgQM37&_nc_ht=scontent.fhan14-5.fna&oh=00_AfAoN7Ut6J6lJ5jOIXUUlOrW0T4Wc4jmmW54T42nOp9G1g&oe=6639F025',
                'https://scontent.fhan14-1.fna.fbcdn.net/v/t39.30808-6/431883379_10163383979307926_2154150888895526461_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeET1GYghThD-5DzootdQ9xx-arGHvmRkJL5qsYe-ZGQkrYDaev4yicKDTSeHi4oLig&_nc_ohc=_xjEJRjMS5YQ7kNvgERZt7d&_nc_ht=scontent.fhan14-1.fna&oh=00_AfAMHVtKT6cguTChpjrlfjZf4JBqX6X1p6WgCg4kjEbzhg&oe=663A165D',
                'https://scontent.fhan14-5.fna.fbcdn.net/v/t39.30808-6/433600000_10163407031667926_380777595993636346_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeHvRxwlWMHiZQSeoUSrk8WVYApLx3AealFgCkvHcB5qUZwprqVmhzuIYvYdPJ3PsNI&_nc_ohc=fycBoLnkAssQ7kNvgFgQM37&_nc_ht=scontent.fhan14-5.fna&oh=00_AfAoN7Ut6J6lJ5jOIXUUlOrW0T4Wc4jmmW54T42nOp9G1g&oe=6639F025',
              ],
            ),
          ],
        ),
      ),
    );
  }
}
