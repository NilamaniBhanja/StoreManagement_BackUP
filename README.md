# StoreManagement
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations add AddBlogCreatedTimestamp
dotnet ef database update

remove
dotnet ef database update InitialCreate
 dotnet ef migrations remove
