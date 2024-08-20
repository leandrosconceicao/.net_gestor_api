using Gestor.Helpers.Profiles;
using Gestor.Repository;
using Gestor.Repository.Implementations;
using Gestor.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services
        .AddDbContext<ApiContext>(opts =>
            opts.UseMySQL(connectionString, b => b.MigrationsAssembly("Api"))
        )
        .AddScoped<IAccountRepository, AccountRepository>()
        .AddScoped<IProductRepository, ProductCategoryRepository>()
        .AddScoped<IEstablishmentRepository, EstablishmentRepository>()
        .AddScoped<IUserRepository, UserRepository>();

builder.Services.
    AddAutoMapper(
        typeof(UserProfile).Assembly,
        typeof(EstablishmentProfile).Assembly,
        typeof(AccountProfile).Assembly,
        typeof(ProductProfile).Assembly,
        typeof(ClientProfile).Assembly
    );


builder.Services.AddControllers().AddNewtonsoftJson(opts =>
{
    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
