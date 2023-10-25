# Electronic_Market

Asp.Net MVC CRUD Operations.<br>
An electronic store management application that allows you to read, add, modify, delete, and search for data.
There are three different user levels: admin, manager, and regular user (who can be added using the registration form on the page).<br>
The management of users is done using ASP.NET Identity.

## Architecture
![Architecture](./Architecture.PNG)

## How to run
1. Download or Clone the Project.
2. Run these command lines using the NuGet Package Manager Console: <br>
   . Install-Package jQuery <br>
   . Install-Package popper.js <br>
   . Install-Package Bootstrap <br>
3. Execute the SQL script found in the sql.txt file to create the database and tables
4. The database migration to create the user management tables is already available in the IdentityMigration folder; you just need to run the following command:<br>
  . Update-Database

## Screenshot
<div>
  <img src="./login.PNG" alt="Texte alternatif de l'image 1" width="300" />
  <img src="./product.PNG" alt="Texte alternatif de l'image 2" width="300" />
</div>
