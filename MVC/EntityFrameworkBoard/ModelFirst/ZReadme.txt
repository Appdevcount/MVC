Model First
===========
->Add Entity Framework Designer to the project 
->Add Table Entity from designer toolbox and design columns and Table relations
->Right Click and select Generate Database from Model. It will create sql script file for the DB OBJECTS for execution and excute it by connecting to DB 
->Right Click and select Add code generation item[select DBContextgenerator] ,It will add Entity and context class.Comment out the context file generated during designer creation
->Thereafter , it normal as DBFirst

