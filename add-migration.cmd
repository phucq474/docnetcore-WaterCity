pushd Repository\WaterCity.Repository
dotnet ef migrations add QL_SPH -v --context AppDbContext
dotnet ef database update -v --context AppDbContext
pause
popd