using LibraryApp.Business.AutoMapper;
using LibraryApp.Business.Implementation;
using LibraryApp.Business.Interface;
using LibraryApp.Repository.Entity;
using LibraryApp.Repository.Implementation;
using LibraryApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LibraryApp.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMapper));
            services.AddTransient<IBookDAL, BookDAL>();
            services.AddTransient<IBookBL, BookBL>();
            services.AddDbContext<BookDbContext>(options => options.UseSqlServer(Configuration.GetSection("ConnectionStrings").GetSection("Connection").Value));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryApp.Service", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryApp.Service v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
