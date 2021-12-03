# Clean Architecture ASP.NET Core 6
Clean Architecture sample on ASP.NET Core - Visual Studio 2022

Create database 'HrLeaveManagementIdentity':
```powershell
dotnet ef migrations add AddUsers --project .\src\Infrastructure\HR.LeaveManagement.Identity\HR.LeaveManagement.Identity.csproj --startup-project .\src\API\HR.LeaveManagement.Api\HR.LeaveManagement.Api.csproj --context LeaveManagementIdentityDbContext
```

Update database 'HrLeaveManagementIdentity':
```powershell
dotnet ef database update --project .\src\Infrastructure\HR.LeaveManagement.Identity\HR.LeaveManagement.Identity.csproj --startup-project .\src\API\HR.LeaveManagement.Api\HR.LeaveManagement.Api.csproj --context LeaveManagementIdentityDbContext
```

Update database 'HrLeaveManagement':
```powershell
dotnet ef database update --project .\src\Infrastructure\HR.LeaveManagement.Persistance\HR.LeaveManagement.Persistance.csproj --startup-project .\src\API\HR.LeaveManagement.Api\HR.LeaveManagement.Api.csproj --context HrLeaveManagementDbContext
```

Update add migration 'HrLeaveManagement':
```powershell
dotnet ef migrations add name --project .\src\Infrastructure\HR.LeaveManagement.Persistance\HR.LeaveManagement.Persistance.csproj --startup-project .\src\API\HR.LeaveManagement.Api\HR.LeaveManagement.Api.csproj --context HrLeaveManagementDbContext
```