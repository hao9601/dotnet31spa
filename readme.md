Prerequisites:
- .Net Core 3.1
- node.js version 12+
- npm version 6.14+
- Angular version 10.1.0

Run
- Open with Visual Studio Code
- Make sure the C# extension is installed
- open the console (integrated terminal) in the "ClientApp" folder
- run "npm install"
- run "ng build"
- launch the application from the debug section ".NET Core Launch (web)" or press "F5"
- click on the "Fetch Data" menu item to verify that the angular app is recieving data from the api portion

-------------------------------------------------------------------------------------------------------------------

September 2020: We are hiring!
Applicants must be able to legally work in the USA and are preferably located in the Eastern or Central time zone.

To be considered do the following:
- create a fork of the project (or clone it and send us the link)
- change the "Fetch Data" functionality from hard-coded values in the controller to be retrieved from a SQLite database (1 table)

We are looking for the follwing in your fork:
- a sql lite database with one table to hold the temperatures and dates
- a service class that uses Dapper to retrieve the temperatures from the database
- the service being used in the weather forecast controller to retrieve the data.

For additional bonus points:
- change the angular app to use angular material styling
- create a component for temperature CRUD operations using reactive forms
- add the required endpoints to the weather forecast controller
- add the required CRUD methods to the data service

For even more bonus points:
- secure the app with the identity provider of your choice (Google, etc) using OAuth and the angular-auth-oidc-client version 11+, if possible implementing PKCE flow

Finally, submit a pull request for your fork as well as your contact information!
