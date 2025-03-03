## Library
ASP.NET Core Web API Biblioteca

![Library](img/1.png)
![Library](img/2.png)


## Program
``` 
builder.Services.AddDbContext<AlmacenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
);
``` 

## appsetting.Development.json
``` 
{
  "ConnectionStrings": {
        "Connection": "Server=*;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
}
``` 