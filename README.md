# Clean Architecture ASP.NET Core 6
Clean Architecture sample on ASP.NET Core - Visual Studio 2022

Update database:
```powershell
dotnet ef database update --project .\src\Infrastructure\HR.LeaveManagement.Persistance\HR.LeaveManagement.Persistance.csproj --startup-project .\src\API\HR.LeaveManagement.Api\HR.LeaveManagement.Api.csproj
```