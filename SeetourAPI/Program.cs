using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SeetourAPI.BL.TourManger;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SeetourAPI.BL.TourAnswerManager;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.AdminManger;
using SeetourAPI.Services;
using SeetourAPI.Data.Claims;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Policies;
using SeetourAPI.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SeetourAPI.BL.TourGuideManager;

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
            #region Cors

            var corsPolicy = "AllowAll";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy, p => p.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            #endregion
            #region Database
            builder.Configuration.AddJsonFile("appsettings.secret.json", false, false);
            var connectionString = builder.Configuration.GetConnectionString("SeetourConn");
            builder.Services.AddDbContext<SeetourContext>(options =>
            options.UseSqlServer(connectionString));//.UseLazyLoadingProxies());
            //builder.Services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            #endregion
            #region Identity
            builder.Services.AddIdentityCore<SeetourUser>()
            .AddEntityFrameworkStores<SeetourContext>();
            #endregion
            #region repos
            builder.Services.AddScoped<ITourRepo, TourRepo>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            builder.Services.AddScoped<IAdminRepo, AdminRepo>();
            builder.Services.AddScoped<ITourAnswerRepo, TourAnswerRepo>();
            builder.Services.AddScoped<ITourQuestionRepo, TourQuestionRepo>();
            builder.Services.AddScoped<ITourGuideRepo, TourGuideRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<ITourGuideRatingRepo, TourGuideRatingRepo>();
            builder.Services.AddScoped<TourBookingsRepo>();
            builder.Services.AddScoped<ITourGuideDashBoardRepo, TourGuideDashBoardRepo>();

            builder.Services.AddScoped<ITourGuideRatingRepo, TourGuideRatingRepo>();
            #region Azure
            builder.Services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
            #endregion
            #endregion
            #region Manger
            builder.Services.AddScoped<ITourManger, TourManger>();
            builder.Services.AddScoped<IReviewManager, ReviewManager>();
            builder.Services.AddScoped<IAdminManger, AdminManger>();
            builder.Services.AddScoped<ITourAnswerManager, TourAnswerManager>();
            builder.Services.AddScoped<ITourQuestionManger, TourQuestionManger>();
            builder.Services.AddScoped<ITourGuideManager, TourGuideManager>();
            builder.Services.AddScoped<HttpContextAccessor>();

            #endregion
            #region IdentityManger
            builder.Services.AddIdentity<SeetourUser, IdentityRole>(o =>
            {
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = true;
                o.Password.RequiredUniqueChars = 1;
                o.Password.RequiredLength = 8;
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
                options.AddPolicy(Policies.AllowAdmins, policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Admin")
                          .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy(Policies.AllowCustomers, policy =>
                   policy.RequireClaim(ClaimTypes.Role, "Customer")
                         .RequireAssertion(c => !c.User.Claims.Any(c => c.ValueType == ClaimType.Status && c.Value == "Blocked"))
                         .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy(Policies.AllowTourGuide, policy =>
                   policy.RequireClaim(ClaimTypes.Role, "TourGuide")
                         .RequireAssertion(c => !c.User.Claims.Any(c => c.ValueType == ClaimType.Status && c.Value == "Blocked"))
                         .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy(Policies.AcceptedTourGuides, policy =>
                   policy.RequireClaim(ClaimTypes.Role, "TourGuide")
                         .RequireClaim(ClaimType.Status, TourGuideStatus.Accepted.ToString(),"Allowed")
                         .RequireClaim(ClaimTypes.NameIdentifier));
            });

            #endregion

            #region Hosted Services
            builder.Services.AddHostedService<TimedRatingCalculatorService>();
            builder.Services.AddHostedService<TimedRatingCalculatorService>();
            builder.Services.AddScoped<ToursHandler>();
            builder.Services.AddHostedService<AdminInitializer>();
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(corsPolicy);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

			app.Run();
        }
    }
}


