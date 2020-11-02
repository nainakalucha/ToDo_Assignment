# Adform_ToDo: Web API in .Net Core 3.1

Description: A rest api project to do CRUD operations for labels, todoitems and lists via HTTP Verbs (GET, POST, PUT, DELETE, PATCH). It includes functionality to create labels which can be assigned to items or lists. It also includes user management which only allows registered users to access or create the respective entities. It includes authorization via JWT Token. It also logs each and every request/response or error if any. It has an added support for GraphQL and unit test cases.

DB Setup -

1. Database is configured and migration is already present. It will be created when the application runs for the first time automatically. Only the connection string in appsettings.json needs to be changed accordingly.
2. If database is to be updated with changes "Update-database" command will update the database.
3. Migrations can be created with command "add-migration ToDoMigrationV1 -StartupProject Adform_ToDo.api"
4. If database is to be created without running the application, run the "Update-database" command in Package Manager Console to create the database from the latest existing migration:

Pre Requisite:

Microsoft dot net core 3.1 sdk package/ dot net core runtime 3.1 version should be installed on machine.

How to run application:

Step 1: Clone repository in destination folder: git clone https://github.com/nainakalucha/ToDo_Assignment.git

Step 2: Go to the project folder and run “dotnet restore” in cmd.

Step 3: Go the folder “Adform_ToDo\Adform_ToDo.API” and run “dotnet run” in cmd.

Navigate to http://localhost:5000/PlayGround to play with GraphQl Interface.


For Swagger:

Navigate to http://localhost:5000/ in a browser to open the Swagger UI.

Step 1: Click RegisterUser and provide valid values.

Step 2:	After registration, click Login and enter your credentials. On Success, it will generate JWT token in result. Copy it and keep it for the subsequent steps.

Step 3: Click Authorize and set token in "Authorization" header as "Bearer copied_token_from_step_2" without quotes.

For GraphQL:

Step 1: clear httpheaders if any.

Step 2: Use below mutation:

mutation{
  authenticateUser(userName:"enter username",password: "enter password"){
    isSuccess
    result
    message
  }
}

Above mutation will generate token in result field.

Set HttpHeaders as below for accessing api resources:
{
  "Authorization":"Bearer (copied token)"
}

Note - 
1. A user has to create todo list first in order to add todo item. 
2. Duplicate Usernames are not allowed
3. Base64 password encoding algorithm is used for storing password in database.
