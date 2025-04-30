
TaskManaPro

TaskMana Pro is a Trello-style task management application developed in C# using Windows Forms and SQL Server. 
It allows users to create boards, lists, and tasks with features like drag-and-drop organization, task editing, 
due date alerts, and more. The project emphasizes clean UI, user control modularity, and robust backend integration.

Features
--------
- Create, edit, and delete Boards, Lists, and Tasks
- Drag-and-drop task management within lists
- Task due date notifications
- User authentication system
- Modern Trello-style UI with icons and themes
- Database integration via SQL Server
- Modular UserControls (TaskCard, ListControl, BoardControl, etc.)
- Task editing in a separate detailed view
- Real-time board updates

Tech Stack
----------
- Frontend: Windows Forms (C# in Visual Studio 2022)
- Backend: SQL Server
- Language: C# (.NET Framework)
- Database Tools: Server Explorer & Table Designer in Visual Studio
- UI: Custom UserControls, FontAwesome icons, FlowLayoutPanel containers

Setup Instructions
------------------
1. Clone the Repository
   git clone https://github.ofeyhalo/TaskManaPro.git

2. Open the Solution
   - Open TaskManaPro.sln in Visual Studio 2022

3. Configure Database
   - Ensure SQL Server is running.
   - Run the TaskManaDB.sql script to create the database and tables.
   - Update your connection string in DatabaseHelper.cs if needed:
     private string connectionString = "Data Source=.;Initial Catalog=TaskManaDB;Integrated Security=True";

4. Run the Application
   - Set MainForm.cs as the startup form and press F5.
  
5. Download the .zip file, extract and open the .sln file inside

Project Structure
-----------------
TaskMana-Pro/
|
├── Controls/
│   ├── BoardControl.cs
│   ├── ListControl.cs
│   ├── TaskCard.cs
│   ├── AddListControl.cs
│   └── EditTaskControl.cs
|
├── Database/
│   └── TaskManaDB.sql
|
├── Forms/
│   ├── MainForm.cs
|   └── LoginForm.cs
|   └── RegistrationForm.cs
│   └── EditTaskForm.cs
|
├── Helpers/
│   └── DatabaseHelper.cs
|
├── TaskManaPro.sln
└── README.txt

To-Do
-----
- [+] Board/List/Task creation logic
- [+] Task editing form
- [+] Drag-and-drop tasks
- [+] Database integration
- [+] Checklist and label support
- [+] Email or popup notifications
- [+] User preferences and themes

Contributors
------------
- [Pascal Ukhurebor] – Lead Developer, Designer
- n
- n
- n
- n

License
-------
This project is licensed under the MIT License - see the LICENSE file for details.

Built with ❤️ in Visual Studio 2022
