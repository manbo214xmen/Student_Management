using Data_Acess_Layer.DBContext;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Data_Acess_Layer.Repositories;
using Business_Logic_Layer.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Business_Logic_Layer.MappingProfiles;
using Business_Logic_Layer.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Student Management",
        Version = "v1",
        Description = "This is a restful API practice, HCM23_CPL_NET_08, Team 7",
        TermsOfService = new Uri("https://www.example.com"),
        Contact = new OpenApiContact
        {
            Name = "Team 7",
            Email = "your.email@example.com",
            Url = new Uri("https://www.example.com")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
   
}); 

builder.Services.AddDbContext<StudentManagementContext>(options =>
{
   options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews().AddXmlSerializerFormatters();


builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<StudentValidation>();
builder.Services.AddScoped<StudentService>();

builder.Services.AddScoped<GradeRepository>();
builder.Services.AddScoped<GradeValidation>();
builder.Services.AddScoped<GradeService>();

builder.Services.AddScoped<StudentAddressRepository>();
builder.Services.AddScoped<StudentAddressValidation>();
builder.Services.AddScoped<StudentAddressService>();

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseValidation>();
builder.Services.AddScoped<CourseService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/Swagger-UI/Background.css");
    });
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("User", "Hao Van");
    context.Response.Headers.Add("User2", "Dung Hoang");
    context.Response.Headers.Add("User3", "Khuong Nguyen");
    context.Response.Headers.Add("User4", "Hung Nguyen");
    await next();
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
