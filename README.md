# mvcAuth

Configuration - setup databse connection
1. Open appsettings.json. Change the connection string to connect with your database provider. 
2. Run the command : 
-* dotnet ef migrations <OUTPUT_NAME>*
-*dotnet ef database update*
3. Open databse management tools to check the table "PropertyInfo" and asp.net identity database related table. 

Steps to use the application
1. Run the application.
2. Reigster with any email and password.
3. Login with the registered account credential. 
4. Click the *Details* in the menu bar on top. 
5. In Property(s) Managmenet page, click the create button.
6. Fill in the necessary information in the page and click the create button.
7. Created property be shown in the *Property(s) Management* page. 
8. Repeat step 5 and 6 to create more property.
9. Select any of the record in the grid and press the edit button on the right side. Amemnd the details and save.
10. Select any of the property in the grid and press the delete button on the right side. Click the delete button to confirm to delete it.

You can perform the same action with different account. The application will only show the data that is belong to the user.
