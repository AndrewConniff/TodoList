# TodoList

Application Created in Visual Studio 2017 .NetCore 2.1

## Run 
1. Clone the application into a folder on your machine
1. Restore Nuget Packages
1. In the Package Manager Console in Visual Studio 2017, run Update-Database to create the tables in the database

## Data
1. In the SQL folder, screipst exist to insert test data. 
1. In VS or SSMS (SQL Server Management Studio) connect to the localdb
1. Run the insert scripts for TodoList first (TodoTasks has a dependency)
1. Run the script for the tasks next.

## Tests
1. In visual studio run tests as desired
1. Run the application and using a tool of your choice run the commands against the API to create new lists or view existing ones.
1. [Find scripts here to help](https://app.swaggerhub.com/apis/aweiker/ToDo/1.0.0#/todo/searchLists "Swagger Definitions")
