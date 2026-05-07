# DVLD - Driving & Vehicles Licensing Department System

A comprehensive desktop application designed to manage the entire lifecycle of driving licenses, applications, tests, and users. Built with a focus on data integrity, security, and scalable architecture.

## 🚀 Technical Stack
* **Language:** C# .NET
* **UI Framework:** Windows Forms (WinForms)
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET (Secure Parameterized Queries)
* **Architecture:** 3-Tier Architecture (Presentation, Business Logic, and Data Access Layers)

## ✨ Key Features
* **User & People Management:** Full CRUD operations with advanced filtering and search capabilities.
* **Application Lifecycle:** Manage various application types (New, Renew, Replacement for Lost/Damaged).
* **License Management:** Issuing Local and International licenses with strict validation logic.
* **Testing System:** Comprehensive management for Vision, Theory, and Practical tests, including Retake logic.
* **Detain & Release System:** Manage detained licenses and handle the release process after fine payments.
* **Security:** Implemented login systems, password encryption, and prevented SQL injection.
* **Business Rules:** Prevents duplicate active applications and ensures data integrity through relational constraints.

## 🏗️ Architecture Overview
The project follows the **3-Tier Architecture** pattern to ensure separation of concerns:
1.  **Presentation Layer (PL):** Handles the UI and user interactions.
2.  **Business Logic Layer (BLL):** Enforces business rules and processes data.
3.  **Data Access Layer (DAL):** Manages direct communication with the SQL database.


