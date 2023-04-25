using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SeetourAPI.BL.TourManger;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;
using System.Security.Claims;
using System.Text;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.AdminManger;
using Newtonsoft.Json;

namespace SeetourAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            #region Database
            builder.Configuration.AddJsonFile("appsettings.secret.json", false, false);
            var connectionString = builder.Configuration.GetConnectionString("SeetourConn");
            builder.Services.AddDbContext<SeetourContext>(options =>
            options.UseSqlServer(connectionString));
            #endregion
            #region Identity
            builder.Services.AddIdentityCore<SeetourUser>()
            .AddEntityFrameworkStores<SeetourContext>();
            #endregion
            #region repos
            builder.Services.AddScoped<ITourRepo, TourRepo>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            builder.Services.AddScoped<IAdminRepo, AdminRepo>();

            #endregion
            #region Manger
            builder.Services.AddScoped<ITourManger, TourManger>();
            builder.Services.AddScoped<IReviewManager, ReviewManager>();
            builder.Services.AddScoped<IAdminManger, AdminManger>();
            builder.Services.AddScoped<HttpContextAccessor>();

            #endregion
            #region IdentityManger
            builder.Services.AddIdentity<SeetourUser, IdentityRole>(o =>
            {
                //o.Password.RequireLowercase = true;
                //o.Password.RequireUppercase = true;
                //o.Password.RequiredUniqueChars = 1;
                //o.Password.RequiredLength = 8;

                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequiredLength = 0;
                o.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<SeetourContext>(); ;
            #endregion
            #region Authentication
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "SeeTour";
                o.DefaultChallengeScheme = "SeeTour";

            }).AddJwtBearer("SeeTour", o =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                var secretInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                var SecretKey = new SymmetricSecurityKey(secretInBytes);
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = SecretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion
            #region Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowAdmin", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Admin")
                          .RequireClaim(ClaimTypes.NameIdentifier));
                options.AddPolicy("AllowUser", policy =>
                   policy.RequireClaim(ClaimTypes.Role, "User")
                         .RequireClaim(ClaimTypes.NameIdentifier));
                options.AddPolicy("AllowTourGuide", policy =>
                   policy.RequireClaim(ClaimTypes.Role, "TourGuide")
                         .RequireClaim(ClaimTypes.NameIdentifier));
            });

            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}