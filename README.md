# DotNot Module: Item Packaging

## Overview
The Item Packaging module is part of a larger Enterprise Resource Planning (ERP) application developed using C# and .NET Core 6.0. This module focuses on managing item packages, including their categorization, barcodes, serial numbers, and associated details, to streamline inventory and operational processes.

## Features
1. **Master-Detail Entry Management:**
   - **Browse Entries:** View a list of item packages with filtering options.
   - **Create New Entries:** Add new items and their associated packages.
   - **Edit Existing Entries:** Modify item and packaging details.
   - **Delete Entries:** Remove items and their associated packages.

2. **Lookup Table Integration:**
   - Connect with related tables, such as categories and measurement units, for data consistency.
   - Add and manage entries in lookup tables directly.

3. **Detail-Specific Management:**
   - Assign unique barcodes and serial numbers to packages.
   - Categorize packages for organizational clarity.

4. **UI and Usability:**
   - Intuitive master-detail views.
   - Filter and search functionalities for ease of navigation.
   - Validation and feedback mechanisms for data input.

## Technologies Used
- **Programming Language:** C#
- **Framework:** .NET Core 6.0
- **Database:** SQL Server
- **Design Principles:**
  - Object-Oriented Design and Development (OODD)
  - Software Design Patterns for maintainability and scalability

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/OJOCoding/DotNotModule.git
   cd DotNotModule
   ```

2. Open the solution in Visual Studio:
   - Navigate to the `.sln` file and open it in Visual Studio.

3. Configure the database connection:
   - Update the `appsettings.json` file with your SQL Server connection string.

4. Build and run the project:
   - Restore NuGet packages and build the solution.
   - Start the application using Visual Studio.

## Project Structure
```plaintext
DotNotModule/
├── Controllers/         # API Controllers for CRUD operations
├── Models/              # Database models and business logic
├── Views/               # Razor views for the user interface
├── Data/                # Database context and migrations
├── Services/            # Business services and logic
├── appsettings.json     # Application configuration
├── Program.cs           # Main entry point of the application
├── README.md            # Project documentation
└── LICENSE              # License file
```

## Database Schema
- **Lookup Tables:**
  - ITEM_CATEGORY
  - MEASUREMENT_UNIT
- **Master Table:**
  - ITEM
- **Detail Table:**
  - ITEM_PKG

## Usage
1. **Navigate to the Item Packaging Section:**
   - Use the ERP's navigation menu to access the module.

2. **Create or Update Items:**
   - Use the interface to add or modify item details, including packages.

3. **View and Filter Items:**
   - Use search and filter functionalities to locate specific entries.

4. **Manage Lookup Tables:**
   - Add or update categories and measurement units as needed.

## Contributing
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch for your changes:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes and push to your fork.
4. Open a pull request detailing your updates.

## License
This project is licensed under the [MIT License](LICENSE).

## Contact
For any questions or support, please reach out:
- GitHub: [OJOCODING](https://github.com/OJOCODING)
- Email: [oniluca@ymail.com](mailto:oniluca@ymail.com)

---

Thank you for exploring the Item Packaging module! This component aims to simplify and enhance the management of item packaging in ERP systems.
