# 🏨 Hotel Management System

The Hotel Management System is a desktop application built using C# (Windows Forms), designed to streamline and simplify hotel operations. It provides an intuitive graphical interface for managing core hotel services such as guest reservations, room assignments, staff records, and booking status.

The application connects to a local SQL Server database (via SQL Server Management Studio) to store and retrieve data efficiently. All operations are handled through a well-structured GUI, offering a responsive and user-friendly experience.

---

# 🧰 Technologies Used

- C# (WinForms) – for building the graphical user interface
- SQL Server Management Studio (SSMS) – for managing the relational database
- ADO.NET – for database connectivity
- Visual Studio – for development and debugging

---

## ✨ Features

- ✅ Make a new reservation
- ✅ Check existing reservations
- ✅ View available hotel rooms
- ✅ Manage hotel staff information
- ✅ Simple and responsive GUI with C# windows forms

---

## 🚀 How to Run the Project

### 🔧 Prerequisites

- Install SQL Server Management Studio 20
- Run app on Visual Studio (C# windows Forms)

---
### 📦 Running the database locally
#### 1) Creating the Database
- Run the SQL Server management studio 20 app
- Connect to your database engine
- Right click on 'Databases' in the object explorer --> new database
- name the new database then press ok
- click on the + icon in 'Databases'
- single click on the new database you just created (just highlight it)
- Then press new query on the top bar (or press CTRL + N)
- copy paste the sql script named 'HotelDB.sql'
- run the query
#### 2) Connecting the Database
- Open project in Visual Studio
- you need to use a connection string to connect to the database each time you send a query request
- to obtain that connection string you click View-->Server Explorer
- Right Click on Data connections--> Add connection
- enter your local server name under "Server Name"
- enter your new database name under "connect to a database"
- click on the checkbox that says "trust server Certificate" --> then click OK
- under properties of connection you will find the connection string that connects the queries in code to the database
- <img width="1036" alt="image" src="https://github.com/user-attachments/assets/1da2d12a-796a-492b-9a1d-0b74b2ed6413" />

---

## 📸 GUI Preview

### 🟩 Home Page
<img src="https://github.com/user-attachments/assets/91a108b4-d7b9-4611-8093-25f15f7b8415" width="700"/>

---

### 🧑‍💼 Staff & Management Screens
<p float="left">
  <img src="https://github.com/user-attachments/assets/c10829fd-3c44-4c9c-9661-d305eccfded2" width="300"/>
  <img src="https://github.com/user-attachments/assets/973ec336-9830-406a-9dd9-10b1f6140f02" width="300"/>
  <img src="https://github.com/user-attachments/assets/a972571c-51ff-46bc-915a-4b507f64e035" width="300"/>
</p>
<p float="left">
  <img src="https://github.com/user-attachments/assets/a13202f7-f537-454e-b2e1-5a59681a8008" width="300"/>
  <img src="https://github.com/user-attachments/assets/90bd229b-40d5-4fe3-b400-634873c5ff6d" width="300"/>
  <img src="https://github.com/user-attachments/assets/86313e13-140f-4d3e-8f98-0a38ce4a77c0" width="300"/>
</p>

---

### 🧾 Additional Screens

<p float="left">
  <img src="https://github.com/user-attachments/assets/e860c221-55e0-411b-b57c-97ce7e79b89e" width="300"/>
  <img src="https://github.com/user-attachments/assets/7a3a7069-bd0d-4f65-ab0f-ea44b0908340" width="300"/>
  <img src="https://github.com/user-attachments/assets/941dcaa7-b695-448a-b371-35fe2d878a83" width="300"/>
  <img src="https://github.com/user-attachments/assets/ee3986b3-7566-4c1a-b021-b40d615a400f" width="300"/>
</p>

---

### 🛏️ Reservation & Room Screens

<p float="left">
  <img src="https://github.com/user-attachments/assets/b272bc7f-11ea-434b-af46-a94ed5daf018" width="300"/>
  <img src="https://github.com/user-attachments/assets/6e2f1979-4abe-4436-9f4b-0b10513f2a2f" width="300"/>
  <img src="https://github.com/user-attachments/assets/19f898ee-21ed-4421-9002-b5dce96faecb" width="300"/>
  <img src="https://github.com/user-attachments/assets/90b609d5-e57c-4456-b7b3-bc7828ef0d27" width="300"/>
</p>

---
