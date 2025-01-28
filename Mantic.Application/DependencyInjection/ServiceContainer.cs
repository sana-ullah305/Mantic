using System.Text;
using Mantic.Application.Contracts;
using Mantic.Application.Extensions;
using Mantic.Application.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetcodeHub.Packages.Extensions.LocalStorage;

namespace Mantic.Application.DependencyInjection
{
    public static class ServiceContainer
    {


        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddAuthorizationCore();
            services.AddNetcodeHubLocalStorageService();
            services.AddScoped<Extensions.LocalStorageService>();
            services.AddScoped<HttpClientService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddTransient<CustomHttpHandler>(); services.AddCascadingAuthenticationState();
            services.AddHttpClient(Constant.HttpClientName, client =>
            {
                client.BaseAddress = new Uri("https://localhost:7063/");
            }).AddHttpMessageHandler<CustomHttpHandler>();
            return services;
        }
    }
}
