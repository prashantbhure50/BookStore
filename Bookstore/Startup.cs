using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore
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
            //services.AddSingleton<INlog, Nlog>();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                });
            });
            services.AddSwaggerGen();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IUserBL, UserBL>();
            services.AddTransient<IUserRL, UserRL>();
            services.AddTransient<IBookRL, BookRL>();
            services.AddTransient<IBookBL, BookBL>();
            services.AddTransient<ICartRL, CartRL>();
            services.AddTransient<ICartBL, CartBL>();
            services.AddTransient<IOrderRL, OrderRL>();
            services.AddTransient<IOrderBL, OrderBL>();
            services.AddTransient<IWishListRL, WishListRL>();
            services.AddTransient<IWishListBL, WishListBL>();
            services.AddTransient<IFeedBackRL, FeedBackRL>();
            services.AddTransient<IFeedBackBL, FeedBackBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore-API ");
                
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AnyOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
