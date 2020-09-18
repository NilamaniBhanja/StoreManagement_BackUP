using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StoreManagement.Core.Data;
using StoreManagement.Models;
using StoreManagement.Repository;
using StoreManagement.Repository.IRepository;

namespace StoreManagement
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
            services.AddCors(options =>
       {
           options.AddDefaultPolicy(
               builder =>
               {
                   builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
               });
       });

            services.AddControllers();

            services.AddScoped<IRoleRepository, RoleRepository>();

            //Connection String Configuration
            services.AddDbContext<StoreDbContext>(
                options => options.UseMySql(Configuration.GetConnectionString("Default"))
            );
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StoreDbContext>()
            .AddDefaultTokenProviders();


            // Get JWT Settings from JSON file
            JwtConfig jwtConfig;
            jwtConfig = GetJwtConfig();
            services.AddSingleton<JwtConfig>(jwtConfig);
            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfig.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtConfig.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
                        ClockSkew = TimeSpan.FromMinutes(jwtConfig.MinutesToExpiration) // remove delay of token when expire
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //loggerFactory.AddFile("Logs/mylog-{Date}.txt");
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Jwt Configuration
        public JwtConfig GetJwtConfig()
        {
            JwtConfig jwtConfig = new JwtConfig();
            jwtConfig.Key = Configuration["JwtConfig:key"];
            jwtConfig.Audience = Configuration["JwtConfig:audience"];
            jwtConfig.Issuer = Configuration["JwtConfig:issuer"];
            jwtConfig.MinutesToExpiration = Convert.ToInt32(Configuration["JwtConfig:minutesToExpiration"]);
            return jwtConfig;
        }

    }
}
