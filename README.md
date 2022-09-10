# Local Business API

#### By Ryan Gibson

#### A web application api built to store information of local businesses.

## Technologies Used

* C#
* MySQL Workbench
* ASP.NET
* Entity Framework
* REPL
* Swagger

## Description

It is a web API designed with a purpose of enabling local community to add local businesses that are in the community and be able to get information about the businesses that run with in the community. The application has featured a technology _Swagger_ that enables API's to have a friendly UI that makes user's to ADD,GET,EDIT and DELETE information easily in the Web-Page.

## Setup/Installation

* First, make sure you have MySql Workbench downloaded and properly installed. You will also need a text editor(Vscode was used to make this application)
* At https://github.com/DiamondsAndRust206/LocalBusiness.Solution.git copy the git repository URL from the green "code" button.
* Open a shell program & navigate to your desktop
* Clone the repository using the copied URL and the "git clone" command
* Make sure sensitive data/files are in the .gitignore file so they to no get pushed to a remote repository. The files in .gitignore should be:

```
  */obj/
  */bin/
  */appsettings.json
```

* In the shell program, navigate to the root directory of the newly created file called "LocalBusiness.Solution"
* In the LocalBusinessApi directory create a file named "appsettings.json"
* Add the following code to the newly created .json file
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=local_business;uid=root;pwd=epicodus;"
  }
}
```
* Make sure the following packages are restored or type the following in the Project directory.
  * `dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0`
  * `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2`
  * `dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0`
  * `dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0`
* Then do the following accordingly in your terminal to update and connect your project to your local database :
  * `dotnet restore`
  * `dotnet build`
  * `dotnet ef migrations add Initial`
  * `dotnet run`

* The above code will create a new database in your local host with tables designed to store information related to the project.
* To interact with the local host website navigate to the project directory and run `dotnet run`or `dotnet watch run` then type http://localhost:5000 into the URL bar in the browser.

## Known Bugs

* No known issues

## License

[MIT](LICENSE)

Copyright (c) 2022 Timothy R Gibson