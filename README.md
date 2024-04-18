# SE-4458-Software-Architecture-Design-of-Modern-Large-Scale-Systems-Midterm-1
# Project Objective: 
The aim of the project is to meet the API requests of mobile app, banking app and website. This project is a backend project created using .net and entity framework, mysql technologies. 
# Database: 
There are 2 tables in the database section: bills and billdetails. Bills table shows whether a user pays his/her bills on a monthly basis and the total amount. Billdetails table shows where and how much an invoice was spent that month.

# ER Diagram:

 ![Picture1](https://github.com/kubranurcivelek/SE-4458-Software-Architecture-Design-of-Modern-Large-Scale-Systems-Midterm-1/assets/76735018/4588cebd-2156-4cc8-9974-a2c7a2b01dea)

User table is in the .net project as static for now. It will be added as a user table in the future.

# Design:
The project is built on 3 basic parts. These are Controller, Entities, DTOs.
# •	Controller:
 Controllers create api gates that applications access. In the controller, database-based operations such as listing, updating, creating and deleting are performed  here. In addition, the authorization of the user to access by logging in is done here. The actual operation that the user wants to do is performed here.
# •	Entities: 
  By using Context, the entity classes in the .net part and the tables in the database are matched.
# •	DTO: 
  They are data structures sent by the user or shown to the user. They are created and used in controllers.

# Issues and Assumptions: 
•	Month parameter is introduced as int for now, the exact date is not kept. it is expected to be changed to dateTime in the future and the apis will be run similarly. 
•	The user is static for testing purposes. A table will be created in the database so that the user can be added and removed and the login controller will be changed accordingly.
•	Primary keys are kept as int and are insufficient in high data count. Primary keys need to be edited for data that will reach billions.
•	User role controls are not available for now. In the future, it will be determined which apis will work in which roles.


