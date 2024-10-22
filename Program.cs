using VinxTech.API.Data;
using Microsoft.EntityFrameworkCore;
using VinxTech.API.Repositories;
using VinxTech.API;
using VinxTech.API.Repositories.Services;
using VinxTech.API.Repositories.Employees;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VinxDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VinxTest")));
builder.Services.AddScoped<IUserRepositories, DBUsersRepositories>();
builder.Services.AddScoped<IBranchRepositories,DBBranchRepositories>();
builder.Services.AddScoped<IServiceRepositories,DBServiceRepositories>();
builder.Services.AddScoped<IEmployeesRepositories, DBEmployeesRepositories>();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowVercelOrigin", policy =>
//    {
//        policy.WithOrigins("https://your-angular-app.vercel.app") // Replace with your Vercel app URL
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials(); // Optional if you need to include credentials (cookies, auth headers, etc.)
//    });
//});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigins", policy =>
//    {
//        policy.WithOrigins("https://vinxtech-dashboard.vercel.app/", "http://localhost:4200/") // Add localhost for development
//              .AllowAnyHeader()
//              .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
//              .AllowCredentials();
//    });
//});







//Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
       builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();


Logger.LogEvent("Env" + "-" + app.Environment.EnvironmentName);


if (app.Environment.EnvironmentName.Contains("Production"))
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<VinxDbContext>();
        dbContext.Database.Migrate();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VinxTexh API");
    //    c.RoutePrefix = string.Empty;
    //});
    app.UseStaticFiles();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





// Configure the HTTP request pipeline.

//if (app.Environment.EnvironmentName.Contains("Development"))
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//if (app.Environment.EnvironmentName.Contains("UAT"))
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VinxTexh API");
//        c.RoutePrefix = string.Empty;
//    });

//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");
//app.UseCors("AllowSpecificOrigins");
//app.UseHttpMethodOverride();
app.UseRouting();
app.MapControllers();
app.Run();
