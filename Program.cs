using Microsoft.EntityFrameworkCore;
using ProductCategoryCrud.Data;
using ProductCategoryCrud.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configurar Swagger para la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductCategoryCrud API", Version = "v1" });
    c.UseInlineDefinitionsForEnums(); // Asegúrate de incluir esto si trabajas con esquemas anidados
});

// Registrar AppDbContext con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.Name,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"] ?? "default_secret"))
    };
});

// Configurar CORS para localhost:4200
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigin", policy =>
        policy.WithOrigins("http://localhost:4200")   // Permitir solicitudes solo desde http://localhost:4200
              .AllowAnyMethod()                      // Permite cualquier método HTTP (GET, POST, PUT, DELETE)
              .AllowAnyHeader());                    // Permite cualquier cabecera
});

builder.Services.AddAuthorization();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowAngularOrigin");  // Usar la política CORS "AllowAngularOrigin"

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
