ADd migration

```bash
dotnet ef migrations add AddProductPrice --project NMHD_DataAccess/NMHD_DataAccess.csproj --startup-project ./NuocMamHongDuc_Web_App/NuocMamHongDuc_Web_App.csproj
```

Update database

```bash
dotnet ef database update --project ./NMHD_DataAccess/NMHD_DataAccess.csproj --startup-project ./NuocMamHongDuc_Web_App/NuocMamHongDuc_Web_App.csproj
```