using FinancialChat.Domain.Contracts;
using FinancialChat.Domain.Mapper;
using FinancialChat.Domain.Services;
using FinancialChat.Infrastructure.Context;
using FinancialChat.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialChat.API
{
    public static class ServiceConfigurator
    {
        /// <summary>
        /// Activate services configuration for custom Controls
        /// </summary>
        /// <param name="services">Services collection from Startup</param>
        /// <param name="configuration">Configuration context from Startup</param>
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();
            services.AddHttpContextAccessor();

            services.AddDbContextPool<FinancialChatDBContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("FinancialChat")));

            services.AddAutoMapper(typeof(UserIdentityMapper));

            services.AddTransient<IFinancialChatRepository, FinancialChatRepository>();
            services.AddTransient<IChatManagementService, ChatManagementService>();
            services.AddTransient<IUserManagementService, UserManagementService>();
            services.AddTransient<IBusMessageService, BusMessageService>();
            services.AddTransient<IBufferProcessService, BufferProcessService>();
            services.AddSingleton<IAuthenticateService, AuthenticateService>();
        }
    }
}
