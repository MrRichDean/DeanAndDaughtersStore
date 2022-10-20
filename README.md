# DeanAndDaughtersStore

Database Creation

The following connection string has been added to the secrets file:

{
  "ConnectionStrings": {
    "DatabaseConnStr": "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=DeanAndDaughtersLtd;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True;"
  }
}

You may need to adjust the DataSource depending uponthe name of your local SQL instance 

In order to create the database, please start up the solution
NuGetPackageManager >>> Package Manager Console and type "update-database"

This should create the db. 
Go to your new DeanAndDaughtersLtd db and open up a new query windown. 
Copy the script within the SQL Scripts folder named "Create Database Table.sql"



API
- Once you have cloned the repo, please go to C:\*YourGitHubRoot*\DeanAndDaughtersStore\Store.Api and run the Store.sln
- To run the code, ensure all nuget packages have been correctly updated
- Build the solution 
- If needed, changed from IISExpress to Kestrel
- Hit F5 to run code, this should open a browser with the following url https://localhost:5001/swagger/index.html where you can use the api 
- Alternatively, go to the Store.UnitTests project and run the BooksControllerTests tests 

ASSUMPTIONS: 
1. Users of the code can readily access and have permissions to SQL 
2. I haven't used the Swagger "Generate Server" before but I went down that route as I thought it would get me as close to the spec as possible, which I would assume you would prefer over any alternative.