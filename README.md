🛒 Supermarket Management Application
Overview
The Supermarket Management application is a project designed to efficiently manage a supermarket. The application is built using C#, the WPF framework, and SQL Server for the database. The architecture follows the MVVM (Model-View-ViewModel) design pattern to ensure a clear separation of concerns and maintainability.

Features
1. User Management
Administrator:

Add, modify, delete (logical deletion), and view users, categories, manufacturers, products, and stocks.
Manage stock entries including setting purchase prices and calculating selling prices automatically.
Validate all form fields during data entry, modification, and deletion.
Search and filter data, including viewing products by manufacturer and category, calculating category values, and viewing user-specific sales data.


Cashier:

Search for products by name, barcode, expiration date, manufacturer, and category.
Issue and view receipt details, including calculating subtotals and totals correctly.
Manage stock quantities and handle logical stock deactivation.


2. Data Management
Products: Store details like product name, barcode, category, and manufacturer.
Manufacturers: Store details like manufacturer name and country of origin.
Categories: Classify products into categories such as food, clothing, stationery, etc.
Stocks: Track product quantities, units, supply dates, expiration dates, purchase prices, and selling prices.
Users: Manage users with their names, passwords, and user types.
Receipts: Record details of sales, including date, cashier, product list with quantities and subtotals, and total amounts.
Offers: (Optional) Manage offers based on product expiration or stock clearance, including setting discount percentages and validity dates.
3. Special Functionalities
Automatic Price Calculation: Selling price is automatically calculated based on the purchase price and a commercial markup.
Logical Deletion: Data is not physically deleted from the database but marked as inactive.
Offer Management: Optional functionality to handle special offers for products nearing expiration or stock clearance.
Technical Details
Database: Managed with SQL Server using Entity Framework for migrations and stored procedures for data operations.
Architecture: Follows the MVVM pattern ensuring a clean separation between UI, business logic, and data layers.
Validation: Ensures all data entry and modification forms are validated to prevent invalid data.
Stored Procedures: At least 10 stored procedures implemented for insert, update, and select operations, ensuring efficient and secure database management.
Security: Protects against SQL injection by using parameterized queries.
Installation and Setup
Clone the Repository:

sh
Copy code
git clone https://github.com/yourusername/SupermarketManagement.git
Setup Database:

Ensure SQL Server is installed and running.
Update the connection string in the appsettings.json file with your SQL Server details.
Run the migrations to set up the database schema:
sh
Copy code
dotnet ef database update
Run the Application:

Open the solution in Visual Studio.
Build the project to restore dependencies.
Run the application.
Usage
Login: Start by logging in as an administrator or cashier.
Administrator Functions: Access the admin panel to manage users, products, categories, manufacturers, stocks, and view reports.
Cashier Functions: Use the cashier interface to search for products, issue receipts, and manage sales.
Notes
The application is designed to adhere to the 3rd Normal Form (3NF) for database normalization.
Proper data binding and MVVM structure are followed to ensure maintainability and scalability.
Exception handling is implemented to manage and log errors effectively.
Contributions
Contributions are welcome! Please fork the repository and create a pull request with your changes.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Feel free to open issues for any bugs or feature requests. Your feedback is valuable for the improvement of this project. Thank you for using Supermarket Management!
