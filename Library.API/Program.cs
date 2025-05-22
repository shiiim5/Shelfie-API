
using System.Text.Json.Serialization;
using Library.API.MiddleWare;
using Library.Core.Entities.Users;
using Library.Infrastructure;
using Library.Infrastructure.Data;
using Library.User.Management.Models;
using Library.User.Management.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace Library.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuiration = builder.Configuration;

            //CORS
            builder.Services.AddCors(op =>
            op.AddPolicy("CORSPolicy",builder=>
            builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200")));

            //Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LibraryDBContext>()
                .AddDefaultTokenProviders();

            //Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            });

            //Email
            var emailConfig = configuiration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguiration>();
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailService,EmailService>();

            builder.Services.Configure<IdentityOptions>(op =>
            op.SignIn.RequireConfirmedEmail = true
            );

            // Add services to the container.

            // builder.Services.AddControllers();
            builder.Services.AddMemoryCache();
            builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.infrastructureRegisteration(builder.Configuration);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
              
            }

            app.UseCors("CORSPolicy");
            if (!app.Environment.IsDevelopment()) {
                app.UseMiddleware<ExceptionMiddleware>();
            }
            app.UseStatusCodePagesWithRedirects("/errors/{0}");
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
