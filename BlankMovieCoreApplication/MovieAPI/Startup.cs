using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieAPP.Business.Services;
using MovieAPP.Data.DataConnections;
using MovieAPP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //get connection string from propertis.json
            string sqlConnection = Configuration.GetConnectionString("SqlConnection");
            //pass connnection string as argument to MovieDbcontext class
            services.AddDbContext<MovieDBContext>(options => options.UseSqlServer(sqlConnection));

            services.AddTransient<IUser, User>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<IMovie, Movie>();
            services.AddTransient<MovieService, MovieService>();

            services.AddTransient<ITheater, Theater>();
            services.AddTransient<TheaterService, TheaterService>();


            services.AddTransient<IMovieShowTime, MovieShowTime>();
            services.AddTransient<MovieShowTimeService, MovieShowTimeService>();

            services.AddControllers();
          
           
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyMovieAPI");
            }
            );



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
