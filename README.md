# ContactManager
A simple ASP.NET Core MVC application to help you manage your contacts.

## How to run
Clone the repository and create the database using the **dotnet ef database update** command.
Run the app with **dotnet run** command.

## Adding new contacts
To add new contacts to the list, upload a CSV file with the following columns:
  +  name *(string)*
  +  birthDate *(date)*
  +  isMarried *(bool)*
  +  phone *(string)*
  +  salary *(decimal)*

Note that the **birthDate** must be formatted in *mm-dd-yyyy* format.
