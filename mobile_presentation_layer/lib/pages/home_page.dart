import 'package:flutter/material.dart';
import 'package:mobile_presentation_layer/pages/profile_page.dart';
import 'package:mobile_presentation_layer/pages/message_page.dart';

class MainPage extends StatefulWidget {
  const MainPage({Key? key}) : super(key: key);

  @override
  _MainPageState createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> with TickerProviderStateMixin {
  int _selectedIndex = 0;

  final List<Widget> _widgetOptions = <Widget>[
    Center(
      child: Text('Home Page'),
    ),
    Center(
      child: Text('Search Page'),
    ),
    Center(
      child: Text('Notifications Page'),
    ),
    Column(
      children: [
        SizedBox(height: 40),
        CustomSearchBar(),
        MessageNotificationBar(
          name: 'Tên người dùng',
          message: 'Tin nhắn của người dùng',
        ),
      ],
    ),
    ProfilePage(),
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
