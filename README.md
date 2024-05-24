<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
<h1>🛒 Supermarket Management Application</h1>
<h2>🔍 Overview</h2>
<p>
    The <strong>Supermarket Management</strong> application is a project designed to efficiently manage a supermarket. The application is built using C#, the WPF framework, and SQL Server for the database. The architecture follows the MVVM (Model-View-ViewModel) design pattern to ensure a clear separation of concerns and maintainability.
</p>
<h2>🌟 Features</h2>
<h3>1. 👥 User Management</h3>
<ul>
    <li><strong>Administrator:</strong>
        <ul>
            <li>Add, modify, delete (logical deletion), and view users, categories, manufacturers, products, and stocks.</li>
            <li>Manage stock entries including setting purchase prices and calculating selling prices automatically.</li>
            <li>Validate all form fields during data entry, modification, and deletion.</li>
            <li>Search and filter data, including viewing products by manufacturer and category, calculating category values, and viewing user-specific sales data.</li>
        </ul>
        <br>
        <img src="https://github.com/Vlazzzz/StoreManagement/assets/132906534/edc24adc-c4f8-49ff-98f3-4ead39529ce1" alt="Admin Dashboard" style="display: block; margin: 20px auto; width: 45%;">
        <img src="https://github.com/Vlazzzz/StoreManagement/assets/132906534/6bbbe745-3e28-45a1-9d5e-1d6a1a1b4952" alt="Admin Manage Users" style="display: block; margin: 20px auto; width: 45%;">
        <br>
    </li>
    <li><strong>Cashier:</strong>
        <ul>
            <li>Search for products by name, barcode, expiration date, manufacturer, and category.</li>
            <li>Issue and view receipt details, including calculating subtotals and totals correctly.</li>
            <li>Manage stock quantities and handle logical stock deactivation.</li>
        </ul>
        <br>
        <img src="https://github.com/Vlazzzz/StoreManagement/assets/132906534/fd973d12-9afa-47a8-8d23-d09b670a34bc" alt="Cashier Search Product" style="display: block; margin: 20px auto; width: 45%;">
        <img src="https://github.com/Vlazzzz/StoreManagement/assets/132906534/a325d42d-9447-478b-aad2-59f18cb45b13" alt="Cashier Issue Receipt" style="display: block; margin: 20px auto; width: 45%;">
    </li>
</ul>
<h3>2. 🗃️ Data Management</h3>
<ul>
    <li><strong>Products:</strong> Store details like product name, barcode, category, and manufacturer.</li>
    <li><strong>Manufacturers:</strong> Store details like manufacturer name and country of origin.</li>
    <li><strong>Categories:</strong> Classify products into categories such as food, clothing, stationery, etc.</li>
    <li><strong>Stocks:</strong> Track product quantities, units, supply dates, expiration dates, purchase prices, and selling prices.</li>
    <li><strong>Users:</strong> Manage users with their names, passwords, and user types.</li>
    <li><strong>Receipts:</strong> Record details of sales, including date, cashier, product list with quantities and subtotals, and total amounts.</li>
</ul>
<h3>3. 🔧 Special Functionalities</h3>
<ul>
    <li><strong>Automatic Price Calculation:</strong> Selling price is automatically calculated based on the purchase price and a commercial markup.</li>
    <li><strong>Logical Deletion:</strong> Data is not physically deleted from the database but marked as inactive.</li>
</ul>
<h2>🛠️ Technical Details</h2>
<ul>
    <li><strong>Database:</strong> Managed with SQL Server using Entity Framework for migrations and stored procedures for data operations.</li>
    <li><strong>Architecture:</strong> Follows the MVVM pattern ensuring a clean separation between UI, business logic, and data layers.</li>
    <li><strong>Validation:</strong> Ensures all data entry and modification forms are validated to prevent invalid data.</li>
    <li><strong>Stored Procedures:</strong> At least 10 stored procedures implemented for insert, update, and select operations, ensuring efficient and secure database management.</li>
    <li><strong>Security:</strong> Protects against SQL injection by using parameterized queries.</li>
</ul>
<h2>⚙️ Installation and Setup</h2>
<ol>
    <li><strong>Clone the Repository:</strong>
        <pre>
            <code>git clone https://github.com/yourusername/SupermarketManagement.git</code>
        </pre>
    </li>
    <li><strong>Setup Database:</strong>
        <ul>
            <li>Ensure SQL Server is installed and running.</li>
            <li>Open SSMS and run the <code>database_script.sql</code> script located in the project to create and populate the database.</li>
            <li>Update the connection string in the <code>appsettings.json</code> file with your SQL Server details.</li>
        </ul>
    </li>
    <li><strong>Run the Application:</strong>
        <ul>
            <li>Open the solution in Visual Studio.</li>
            <li>Build the project to restore dependencies.</li>
            <li>Run the application.</li>
        </ul>
    </li>
</ol>
<h2>🚀 Usage</h2>
<ul>
    <li><strong>Login:</strong> Start by logging in as an administrator or cashier. If you use the database_script from this repository you can use the default admin account (Username: "admin", Password: "123") so you can login and start using the application.</li>
    <li><strong>Administrator Functions:</strong> Access the admin panel to manage users, products, categories, manufacturers, stocks, and view reports.</li>
    <li><strong>Cashier Functions:</strong> Use the cashier interface to search for products, issue receipts, and manage sales.</li>
</ul>
<h2>📌 Notes</h2>
<ul>
    <li>The application is designed to adhere to the 3rd Normal Form (3NF) for database normalization.</li>
    <li>Proper data binding and MVVM structure are followed to ensure maintainability and scalability.</li>
    <li>Exception handling is implemented to manage and log errors effectively.</li>
</ul>
<h2>🤝 Contributions</h2>
<p>Contributions are welcome! Please fork the repository and create a pull request with your changes.</p>
<p>Feel free to open issues for any bugs or feature requests. Your feedback is valuable for the improvement of this project. Thank you for using <strong>Supermarket Management</strong>!</p>
</body>
</html>
