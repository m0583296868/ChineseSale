using Microsoft.EntityFrameworkCore;
using MSMA.DAL;
using MSMA.BL;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MsDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services for Dependency Injection
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonorDal, DonorDal>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IGiftDal, GiftDal>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardDal, CardDal>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDal, OrderDal>();

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services to the container.
builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "מכירה סינית - API",
        Description = "A simple example ASP.NET Core API to manage books",
        Contact = new OpenApiContact
        {
            Name = "AM",
            Email = "c7631625@gmail.com",
            Url = new Uri("https://yourwebsite.com"),
        }
    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer {your_token}'"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy", //give it the name you want
                builder =>
                {
                  builder.WithOrigins("http://localhost:4200",
                                         "development web site")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                }
  );
});
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseCors("CorsPolicy");
  app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(
    //    c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
    //    c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    //}
    );
}


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Start the app
app.Run();
