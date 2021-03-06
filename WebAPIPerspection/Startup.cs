﻿using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using WebAPIPerspection.Controllers;
using WebAPIPerspection.Models;

namespace WebAPIPerspection
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
            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                                                    .AddJsonOptions(options =>
                                                    {
                                                        var resolver = options.SerializerSettings.ContractResolver;
                                                        if (resolver != null)
                                                            (resolver as DefaultContractResolver).NamingStrategy = null;
                                                    });
            //services.AddMvc().AddJsonOptions(opt =>
            //    {
            //        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    });
            services.AddDbContext<PrescriptionDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddDbContext<PrescriptionDbContext>(ServiceLifetime.Transient);
            services.AddDefaultIdentity<ApplicationUser>()
                                    .AddEntityFrameworkStores<PrescriptionDbContext>();

            //services.Configure<IdentityOptions>(options =>
            // {
            //     options.Password.RequireDigit = false;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireLowercase = false;
            //     options.Password.RequireUppercase = false;
            //     options.Password.RequiredLength = 4;
            // });

            //Jwt Authentication
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer",new string[] { }},
                };
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { 
                Description = "JWT Authorization header using the bearer scheme Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = "header",
                Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseCors(options =>
            options.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            .AllowAnyMethod()
            .AllowAnyHeader());

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
