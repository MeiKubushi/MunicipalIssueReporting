📄 README — Municipal Services Application
📋 Table of Contents
Project Overview
System Requirements
How to Compile
How to Run
How to Use the Application
Features Implemented
Data Structures Used
Troubleshooting
Submission Details
🎯 Project Overview
Municipal Services Application — Part 2
A C# Windows Forms application developed for South African municipalities. This application provides citizens with a comprehensive platform to report issues, view local events and announcements, and track service request statuses efficiently.
💻 System Requirements
Table
Requirement	Details
Operating System	Windows 10 / Windows 11
Framework	.NET 6.0 or later
IDE	Visual Studio 2022 (Recommended) or VS Code with C# extensions
Git	Optional — for version control only
🛠️ How to Compile
Option 1 — Using Visual Studio (Recommended)
Open the project folder
Double-click MunicipalIssueReporting.csproj to open in Visual Studio
Ensure all project files are included in the Solution Explorer
Press Ctrl + Shift + B or go to Build → Build Solution
✅ Build should succeed with no errors
Option 2 — Using Command Line
Open your terminal in the project directory and run:
bash
dotnet build
✅ Look for "Build succeeded" message
🚀 How to Run
From Visual Studio
Press F5 (Start Debugging) OR Ctrl + F5 (Start Without Debugging)
From Command Line
bash
dotnet run
From File Explorer
Navigate to: bin/Debug/net6.0/
Double-click: MunicipalIssueReporting.exe
📖 How to Use the Application
🏠 Main Menu
When you launch the application, the Municipal Services Portal appears with three options:
Table
Button	Function
Report Issues	Opens the issue reporting form (implemented in Part 1)
Local Events and Announcements	Views upcoming events with search and recommendations
Service Request Status	Tracks the status of submitted service requests
📅 Local Events & Announcements Page
To View All Events:
Click "Show All Events" — displays all upcoming events sorted by date
To Search for Events:
Select a Category from the dropdown (Community, Sports, Education, Culture, Government)
Select a Date using the date picker
Click Search — matching events appear in the list
If no events match your criteria, the message "No events match your search criteria" will display
To View Recommendations:
Based on your search history, recommended events appear at the bottom of the page
These are events in categories you've searched for before
To Return to Main Menu:
Click the "Back to Home" button — closes the Events page and returns to the Main Menu
✨ Features Implemented
Table
Feature	Description
Main Menu	Clean, organised navigation with three options
Events Display	Upcoming events shown in a clear, readable format
Category Search	Filter events by event category
Date Search	Filter events by specific date
Combined Search	Filter by both category and date simultaneously
Show All Events	Reset filters and view the full event list
Back Button	Easy navigation back to Main Menu
Recommendation System	Suggests events based on user search patterns
Unique Categories	Dropdown automatically populated with distinct categories
📐 Data Structures Used
Table
Data Structure	Purpose	Marks Allocation
SortedDictionary<DateTime, List<EventItem>>	Stores and organises events by date. Automatically maintains sorted order for efficient retrieval.	15
HashSet<string>	Stores unique event categories. Ensures no duplicate entries and provides O(1) lookups.	10
Stack<string>	Tracks user search history. Pushes new searches and pops previous ones to analyse user preferences.	15
Dictionary<string, List<EventItem>>	Maps categories to related events for fast recommendation lookups.	—
Queue<ServiceRequest>	Manages service requests in FIFO order for the Status page.	—
🔍 Recommendation Feature Details
The application analyses your search history using a Stack:
Each time you search, your selected category is pushed onto the stack
When viewing recommendations, the application looks at your most frequently searched categories
Related events from those categories are suggested to you
This helps users discover events that match their interests
⚠️ Troubleshooting
Table
Issue	Possible Cause	Solution
Background image not found	municipal_bg.jpg file missing or wrong path	Place the image file in your bin/Debug folder OR remove the BackgroundImage line from your form code
Application won't compile	Missing files or syntax errors	Check the Error List window. Look for red underlines in your code. Ensure all .cs files are included in the project
Search returns "No events match"	No events exist for that category/date	Try different search criteria or click Show All Events to verify what events are available
Date picker shows wrong format	System date settings	This does not affect functionality — the application handles conversion internally
Events not sorted correctly	Not using SortedDictionary	Ensure events are added to a SortedDictionary<DateTime, ...> — it maintains order automatically
Duplicate categories in dropdown	Not using HashSet	Use a HashSet<string> to collect categories before adding them to the dropdown list
📁 Project File Structure
plaintext
MunicipalIssueReporting/
├── README.md                          ← This file
├── MunicipalIssueReporting.csproj     ← Project configuration file
├── Program.cs                         ← Application entry point
├── MainForm.cs                        ← Main Menu window
├── EventsForm.cs                      ← Local Events & Announcements page
├── StatusForm.cs                      ← Service Request Status page
├── EventItem.cs                       ← Event data model class
└── bin/
    └── Debug/
        └── net6.0/
            └── MunicipalIssueReporting.exe   ← Compiled application
📝 Student Declaration
Table
Item	Details
Project Name	Municipal Services Application — Part 2
Student Name	MeiKubushi
Student Number	ST10538212
Module Code	AAPD7112
Date Submitted	13 October 2026
GitHub Repository	https://github.com/MeiKubushi/MunicipalIssueReporting
Submission Platform	VS Code / GitHub