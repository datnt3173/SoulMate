// import 'package:flutter/material.dart';

// class HomePage extends StatefulWidget {
//   @override
//   _HomePageState createState() => _HomePageState();
// }

// class _HomePageState extends State<HomePage> {
//   IconData _selectedIcon = Icons.home;

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       body: Column(
//         mainAxisAlignment: MainAxisAlignment.end,
//         children: [
//           Container(
//             //color: Colors.grey[300],
//             padding: const EdgeInsets.symmetric(horizontal: 20.0),
//             child: Row(
//               mainAxisAlignment: MainAxisAlignment.spaceBetween,
//               children: [
//                 IconButton(
//                   icon: Icon(Icons.home,
//                       color: _selectedIcon == Icons.home
//                           ? Colors.green
//                           : Colors.black),
//                   onPressed: () {
//                     setState(() {
//                       _selectedIcon = Icons.home;
//                     });
//                     // Xử lý khi nhấn nút Home
//                   },
//                 ),
//                 IconButton(
//                   icon: Icon(Icons.search,
//                       color: _selectedIcon == Icons.search
//                           ? Colors.green
//                           : Colors.black),
//                   onPressed: () {
//                     setState(() {
//                       _selectedIcon = Icons.search;
//                     });
//                     // Xử lý khi nhấn nút Search
//                   },
//                 ),
//                 Container(
//                   margin: EdgeInsets.symmetric(horizontal: 10.0),
//                   transform: Matrix4.translationValues(0.0, -15.0, 0.0),
//                   child: Container(
//                     decoration: BoxDecoration(
//                       shape: BoxShape.circle,
//                       color: Colors.blue,
//                       boxShadow: [
//                         BoxShadow(
//                           color: Colors.black
//                               .withOpacity(0.3), // Màu đen với độ mờ 30%
//                           spreadRadius: 2, // Bán kính lan rộng của đổ bóng
//                           blurRadius: 5, // Độ mờ
//                           offset: Offset(0, 3), // Độ dịch chuyển của đổ bóng
//                         ),
//                       ],
//                     ),
//                     child: Material(
//                       color: Colors.transparent, // Màu trong suốt cho Material
//                       child: InkWell(
//                         borderRadius: BorderRadius.circular(20.0),
//                         onTap: () {
//                           // Xử lý khi nhấn nút Đăng bài
//                         },
//                         child: Padding(
//                           padding: EdgeInsets.all(
//                               20.0), // Độ chồng cao và độ rộng của nút
//                           child: Icon(
//                             Icons.add,
//                             color: Colors.white,
//                             size: 30.0,
//                           ),
//                         ),
//                       ),
//                     ),
//                   ),
//                 ),
//                 IconButton(
//                   icon: Icon(Icons.notifications,
//                       color: _selectedIcon == Icons.notifications
//                           ? Colors.green
//                           : Colors.black),
//                   onPressed: () {
//                     setState(() {
//                       _selectedIcon = Icons.notifications;
//                     });
//                     // Xử lý khi nhấn nút Thông báo
//                   },
//                 ),
//                 IconButton(
//                   icon: Icon(Icons.person,
//                       color: _selectedIcon == Icons.person
//                           ? Colors.green
//                           : Colors.black),
//                   onPressed: () {
//                     setState(() {
//                       _selectedIcon = Icons.person;
//                     });
//                     // Xử lý khi nhấn nút Profile
//                   },
//                 ),
//               ],
//             ),
//           ),
//         ],
//       ),
//     );
//   }
// }

// void main() {
//   runApp(MaterialApp(
//     debugShowCheckedModeBanner: false,
//     home: HomePage(),
//   ));
// }

import 'package:flutter/material.dart';
import 'package:soulmate_match/pages/home/post/post.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> with TickerProviderStateMixin {
  int _selectedIndex = 0;

  final List<Widget> _widgetOptions = <Widget>[
    HomePost(),
    Center(
      child: Text('Search Page'),
    ),
    Center(
      child: Text('Post'),
    ),
    Center(
      child: Text('Notifications Page'),
    ),
    Center(
      child: Text('Prifile Page'),
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: IndexedStack(
        index: _selectedIndex,
        children: _widgetOptions,
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.search),
            label: 'Search',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.notifications),
            label: 'Notifications',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.mail),
            label: 'Messages',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.person),
            label: 'Profile',
          ),
        ],
        currentIndex: _selectedIndex,
        selectedItemColor: Colors.blue,
        unselectedItemColor: Colors.grey,
        onTap: (index) {
          setState(() {
            _selectedIndex = index;
          });
        },
      ),
    );
  }
}
