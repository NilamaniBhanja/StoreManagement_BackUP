# StoreManagement <br/> <br/>

dotnet ef migrations add InitialCreate <br/>
dotnet ef database update <br/> <br/>

dotnet ef migrations add AddBlogCreatedTimestamp <br/>
dotnet ef database update <br/> <br/> <br/> <br/>

<b>Remove</b> <br/>
dotnet ef database update InitialCreate <br/>
dotnet ef migrations remove <br/> <br/>
