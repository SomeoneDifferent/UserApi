using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserApi.Models;

namespace UserApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("Users"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app) => app.UseMvc();
    }
}