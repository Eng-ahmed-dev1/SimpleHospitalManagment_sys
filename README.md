# 🏥 Hospital Management System

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=xaml&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=nuget&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

**A modern, elegant desktop application for managing hospital patients and appointments**

[Features](#-features) • [Installation](#-installation) • [Usage](#-usage) • [Technologies](#-technologies)

</div>

---

## 📖 Overview

Hospital Management System is a comprehensive desktop application designed to streamline patient registration and appointment scheduling. Built with modern technologies and best practices, it offers an intuitive interface for healthcare administrators.

## ✨ Features

- 🏥 **Patient Management** - Register patients with unique IDs, names, and medical conditions
- 📅 **Appointment Scheduling** - Schedule and track appointments with precise date and time
- 📊 **Data Visualization** - View all appointments in an organized, sortable data grid
- 🎨 **Modern UI** - Clean, professional interface with dark theme
- 💾 **Persistent Storage** - Reliable database integration with SQL Server
- 🔄 **Real-time Updates** - Instant reflection of changes across all views

## 🛠️ Technologies

<table>
  <tr>
    <td align="center" width="96">
      <img src="https://skillicons.dev/icons?i=cs" width="48" height="48" alt="C#" />
      <br>C#
    </td>
    <td align="center" width="96">
      <img src="https://skillicons.dev/icons?i=dotnet" width="48" height="48" alt=".NET" />
      <br>.NET
    </td>
    <td align="center" width="96">
      <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/microsoftsqlserver/microsoftsqlserver-plain.svg" width="48" height="48" alt="SQL Server" />
      <br>SQL Server
    </td>
  </tr>
</table>

### Core Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| **C#** | 10.0+ | Primary programming language |
| **WPF** | .NET 6.0+ | Desktop UI framework |
| **XAML** | - | Declarative UI markup |
| **Entity Framework Core** | 6.0+ | Object-relational mapping |
| **SQL Server** | 2019+ | Database management |

## 📦 Prerequisites

Before running this application, ensure you have:

- ✅ **Visual Studio 2022** or later
- ✅ **.NET 6.0 SDK** or later
- ✅ **SQL Server 2019** or later (Express edition is sufficient)

## 🚀 Installation

### Step 1: Clone the Repository

```bash
git clone https://github.com/yourusername/hospital-management-system.git
cd hospital-management-system
```

### Step 2: Database Setup

The project includes a database SQL script file. Run it in SQL Server Management Studio:

1. Open **SQL Server Management Studio**
2. Connect to your SQL Server instance
3. Open the provided database script file
4. Execute the script to create `HospitalDB` database

### Step 3: Configure Connection String

Open `Model/HospitalDB.cs` and update the connection string:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
```

Replace `YOUR_SERVER` with:
- `.` or `localhost` for local instance
- `.\SQLEXPRESS` for SQL Server Express
- Your server name for remote instances

### Step 4: Build and Run

1. Open the solution in Visual Studio
2. Restore NuGet packages (automatic)
3. Press **F5** to build and run

## 💻 Usage

### Adding a New Patient

1. Launch the application
2. Enter patient **ID** (unique number)
3. Enter patient **Name**
4. Enter patient **Condition** (medical diagnosis)
5. Click **Add** button

### Scheduling an Appointment

After adding a patient, you'll be directed to the appointment window:

1. **Patient ID** is auto-filled
2. Enter **Date** in format: `yyyy-MM-dd` (e.g., `2025-10-15`)
3. Enter **Time** in format: `HH:mm` (e.g., `14:30`)
4. Click **Add** button

### Viewing Appointments

The appointments view displays all scheduled appointments with:
- Appointment ID
- Patient ID
- Patient Name
- Medical Condition
- Date & Time

## 📁 Project Structure

```
Hospital_man_sys/
│
├── Model/                      # Data models and database context
│   ├── Patients.cs            # Patient entity
│   ├── Appointments.cs        # Appointment entity
│   └── HospitalDB.cs          # EF Core DbContext
│
├── Views/                      # XAML views
│   ├── MainWindow.xaml        # Patient registration window
│   ├── AddAppointment.xaml    # Appointment scheduling window
│   └── Appoin.xaml            # Appointments list window
│
├── App.xaml                    # Application configuration
└── DatabaseScript.sql          # Database creation script
```

## 🗄️ Database Schema

### Patients Table

| Column | Type | Description |
|--------|------|-------------|
| `ID` | `INT` | Primary key, unique patient identifier |
| `Name` | `NVARCHAR(25)` | Patient full name |
| `Condition` | `NVARCHAR(MAX)` | Medical condition/diagnosis |

### Appointments Table

| Column | Type | Description |
|--------|------|-------------|
| `Id` | `INT` | Primary key, auto-increment |
| `Pat_ID` | `INT` | Foreign key to Patients(ID) |
| `DateTime` | `DATETIME` | Appointment date and time |

**Relationships:**
- One Patient can have many Appointments (1:N)

## 🎨 UI Design Philosophy

The application features a carefully crafted design system:

### Color Palette
- **Background**: `#27374D` - Deep blue-gray
- **Panels**: `#526D82` - Medium slate
- **Borders**: `#DDE6ED` - Light gray
- **Accent**: `#000000` - Pure black for buttons

### Typography
- **Font Family**: Century
- **Weight**: ExtraBold for headers and buttons
- **Sizes**: 16-25px for optimal readability

### Components
- **Rounded Corners**: 4-12px radius for modern look
- **Border Thickness**: 3px for clear boundaries
- **Consistent Spacing**: Uniform padding and margins

## 📝 Date & Time Formats

| Field | Format | Example | Description |
|-------|--------|---------|-------------|
| **Date** | `yyyy-MM-dd` | `2025-10-15` | Year-Month-Day |
| **Time** | `HH:mm` | `14:30` | 24-hour format |

## 🔧 Configuration

### Entity Framework Core

The project uses Code First approach with:
- Navigation properties for relationships
- Data annotations for constraints
- DbContext for database operations

### NuGet Packages Required

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0+" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0+" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0+" />
```

## 🐛 Troubleshooting

### Common Issues

**Connection Failed**
- Verify SQL Server is running
- Check connection string accuracy
- Ensure Windows Authentication or SQL Auth is configured

**Database Not Found**
- Run the provided SQL script first
- Verify database name is `HospitalDB`

**Patient ID Already Exists**
- Each patient must have a unique ID
- Check existing patients before adding new ones

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👨‍💻 Author

**Your devAhmed**
- GitHub: [@yourusername](https://github.com/Eng-ahmed-dev1)

## 🙏 Acknowledgments

- Entity Framework Core team for excellent ORM
- WPF community for UI inspiration
- Microsoft for comprehensive documentation

---

<div align="center">

**Made with ❤️ for Healthcare Management**

⭐ Star this repository if you find it helpful!

</div>
