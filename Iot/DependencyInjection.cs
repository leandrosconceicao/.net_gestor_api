using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gestor.Domain.Handlers;
using Gestor.Domain.Interfaces;
using Gestor.Domain.Profiles;
using Gestor.Repository;
using Gestor.Repository.Db;
using Gestor.Repository.Implementations;
using Gestor.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Iot
{
    public class DependencyInjection
    {
        public static void BuildInfraestructure(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
            var jwtKey = builder.Configuration.GetSection("Jwt").Value;
            builder.Services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", opts =>
            {
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
                opts.SaveToken = true;
                opts.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        //if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chat"))
                        //{
                        //    context.Token = accessToken;
                        //}
                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services
                    .AddDbContext<ApiContext>(opts =>
                        opts.UseMySQL(connectionString, b => b.MigrationsAssembly("Api"))
                    )
                    .AddScoped<IAccountHandler, AccountHandler>()
                    .AddScoped<IUserHandler, UserHandler>()
                    .AddScoped<IChatHandler, ChatHandler>()
                    .AddScoped<IEstablishmentHandler, EstablishmentHandler>()
                    .AddScoped<IAuthenticationRepository, AuthenticationRepository>()
                    .AddScoped<IAccountRepository, AccountRepository>()
                    .AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
                    .AddScoped<IEstablishmentRepository, EstablishmentRepository>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<IProductRepository, ProductRepository>()
                    .AddScoped<IProductExtraRepository, ProductExtraRepository>();

            builder.Services.
                AddAutoMapper(
                    typeof(AccountProfile).Assembly,
                    typeof(EstablishmentProfile).Assembly,
                    typeof(AccountProfile).Assembly,
                    typeof(ProductProfile).Assembly,
                    typeof(ClientProfile).Assembly,
                    typeof(UserProfile).Assembly,
                    typeof(ProductExtraProfile).Assembly
                );

            builder.Services.AddAuthorization();

        }
    }
}
