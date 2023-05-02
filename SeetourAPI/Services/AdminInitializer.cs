using Microsoft.AspNetCore.Identity;
using SeetourAPI.Data.Claims;
using SeetourAPI.Data.Models.Users;
using System.Security.Claims;

namespace SeetourAPI.Services
{
	public class AdminInitializer: IHostedService
	{
		private readonly IServiceScopeFactory _serviceProvider;

		public AdminInitializer(IServiceScopeFactory serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async Task CreateAdminUserAsync()
		{
			using (var scope = _serviceProvider.CreateScope())
			{
				UserManager<SeetourUser> _userManager = scope.ServiceProvider.GetRequiredService<UserManager<SeetourUser>>();
				IConfiguration _configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

				var adminName = _configuration.GetValue<string>("AdminUsername") ?? throw new Exception();
				var adminEmail = _configuration.GetValue<string>("AdminEmail") ?? throw new Exception();
				var adminPassword = _configuration.GetValue<string>("AdminPassword") ?? throw new Exception();

				var adminUser = await _userManager.FindByEmailAsync(adminEmail);
				if (adminUser == null)
				{
					adminUser = new SeetourUser
					{
						UserName = adminName,
						Email = adminEmail,
						SecurityLevel = "Admin"
					};

					await _userManager.CreateAsync(adminUser, adminPassword);

					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.NameIdentifier, adminUser.Id),
						new Claim(ClaimTypes.Role, adminUser.SecurityLevel)
					};

					await _userManager.AddClaimsAsync(adminUser, claims);
				}
			}
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await CreateAdminUserAsync();
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
