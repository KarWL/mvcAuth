# mvcAuth

FIrst In order to start the application in new environment. 
Open up the appsettings.json. Go to the Connectionstrings block{}. Change the connection string inside to connect with your database provider. 
The default which is from the code is connected to the Microsoft Sql Server. Once the connecstring is changes, run the command to start the migrations
and performed databsae update. Upon finish the databse update, open your databse management tools to check the new table created. "PropertyInfo" and asp.net identity
database related table. 

Run the application, you should see the web application. 
1. Reigster with any email and password. (Email Confirmed is set to true by default, mean can straight login once register success) When the registration is success, login with the account credential. 
2. Once login success, you will be show the homepage. Go to the top bar and click the details tab. 
3. In there, you should be able to see the Property(s) Managmenet Title. Beneath it on the right side has a create button. Click it and fill in the necessary information
for the property. **Name is mandatory type. Please fill it. Leave it blank will cause an error pop-up, click okay and fill the detail in the Name Text box.** 
4. Once the property is successful created. It will be shown in the *Property(s) Management* page. You can try to create few more property for the edit and delete action. 
5. Select any of the created property in the grid to edit the property info. Fill in the edit details and save. 
6. Select any of the property in the grid to delete it. Click the delete button to confirm to delete it. If not, click any of the tab button on top. 

You can perform the same action with different account. The application will only show the data that was belong to the users by binding  with user ID. 
During the create property, the users id is save into the *PropertyInfo* entity. By utilize the field, the code will validate if the login users is the owner for the property to perform edit and delete into the property.  

