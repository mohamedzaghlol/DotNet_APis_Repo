using Application.Interfaces;
using LBInfastructure.Context;
using LBInfastructure.UnityOfWork;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//string _jwtSecretKey = "1234";
//string _jwtIssuer = "Zoka";
//int _jwtExpirationInMinutes = 60;


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LB>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<LB>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
// Add services to the container.

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//// Configure JWT authentication
//var key = Encoding.ASCII.GetBytes(_jwtSecretKey);
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = true,
//        ValidIssuer = _jwtIssuer,
//        ValidateAudience = false, // You can configure audience validation as well.
//        ValidateLifetime = true
//    };
//});

app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
