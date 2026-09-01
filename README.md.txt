# Municipal Services — Issue Reporting Application

A C# Windows Forms application built with .NET that allows citizens to report municipal service issues easily. Designed with a simple, low-data interface suitable for all community members.

---

## 📋 Overview
This application provides a citizen portal for reporting municipal issues such as water leaks, electricity faults, sanitation problems, and more. Only the **Report Issues** feature is active; other features are reserved for future development.

---

## ✨ Features
- **Main Menu** — Clear, simple dashboard with three options
  - ✅ Report Issues — **Active**
  - ⏳ Local Events and Announcements — **Active**
  - ⏳ Service Request Status — **Active**
- **Report Issues Form**
  - 📍 Location / Address input
  - 🏷️ Category selection dropdown
  - 📝 Detailed description box
  - 📎 Optional file attachment (images & documents)
  - ✅ Submit button with validation & confirmation
- **Data Storage** — Reports saved in-memory for processing
- **User-Friendly Design** — Large readable fonts, clear colours, simple layout

---

## 🛠️ Technologies Used
- **Language:** C#
- **Framework:** .NET 8.0 (Windows Forms)
- **IDE:** Visual Studio Code
- **Platform:** Windows

---

## 📁 Project Structure


---

## 🚀 How to Run the Application

### Prerequisites
- .NET 8.0 SDK or later installed
- Windows operating system

### Build & Run
1. Open the project folder in **Visual Studio Code**
2. Open the **Terminal** (Ctrl+` or View → Terminal)
3. Build the project: dotnet build
4. Run the application:dotnet run


---

## 📖 How to Use

### Main Menu
When the app starts, you will see three buttons:
- **Report Issues** — Click to open the reporting form
- The other two buttons are **greyed out** and cannot be used yet

### Reporting an Issue
1. Click **Report Issues**
2. Fill in:
- **Location** — Enter street address or nearest landmark
- **Category** — Select the type of issue from the list
- **Description** — Provide details about the problem
3. **(Optional)** Attach a photo or document:
- Click **Browse…**
- Select an image (.jpg, .png) or document (.pdf, .doc)
4. Click **✅ Submit Report**
5. You will see a **confirmation message** with a reference number
6. Click **← Back** to return to the Main Menu

---

## 🎯 Design Strategy
This application follows a **Simplified, Low-Data Reporting Workflow** strategy:
- Minimal inputs — only essential information required
- Optional attachments — not mandatory to submit
- Clear feedback — confirmation messages after submission
- Consistent, accessible design — suitable for all users

---

## ⚠️ Important Notes
- Report data is stored in memory and **will be cleared** when the application closes
- Supported attachment formats: `.jpg`, `.jpeg`, `.png`, `.pdf`, `.doc`, `.docx`
- Internet connection is **not required** to submit reports

---

## 📌 Future Improvements
- Save reports to a file or database
- Add offline functionality
- Support all 11 official South African languages

---

**Developed for: Municipal Services Application Project**
