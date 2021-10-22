using AutoMapper;
using FluentValidation.AspNetCore;
using TUSA.API.Extensions.DI;
using TUSA.API.Services;
using TUSA.Core;
using TUSA.Core.Result;
using TUSA.Data;
using TUSA.Data.DependencyInjection;
using TUSA.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TUSA.API
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
           
            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddHttpContextAccessor();
            //services.AddMvc(options =>
            //{
            //    options.Filters.AddService<SetBranchDataFilter>();
            //})
            services.AddMvc()
           .ConfigureApiBehaviorOptions(o =>
           {
               o.InvalidModelStateResponseFactory = actionContext =>
               {
                   BaseResult error = new BaseResult();
                   error.Messages = actionContext.ModelState
                       .Where(e => e.Value.Errors.Count > 0)
                       .Select(e => new MessageItem
                       (
                           source: "DataError",
                           field: e.Key,
                           description: e.Value.Errors.First().ErrorMessage
                       )).ToList();

                   return new BadRequestObjectResult(error);
               };

           });
            //.AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});

            string dbConnString = Configuration.GetConnectionString("TUSADB");

            services.AddDbContext<TUSAContext>(options =>
                options.UseSqlServer(dbConnString, builder => builder.MigrationsAssembly(typeof(Startup).Assembly.FullName)
                )).AddUnitOfWork<TUSAContext>();

            ////This registers the service layer: I only register the classes who name ends with "Service" (at the moment)
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(IBaseService<>)))
                .Where(c => c.Name.EndsWith("Service")).AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

         //   services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IApplicationUser, ApplicationUser>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(typeof(MappingProfile));

            // Default is Cookie, for API is JWT
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(cfg =>
              {
                  cfg.RequireHttpsMetadata = false;
                  cfg.SaveToken = true;

                  cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      ClockSkew = TimeSpan.Zero,
                      RequireExpirationTime = true,
                      ValidateLifetime = true,
                      ValidateIssuer = false,
                      ValidIssuer = Configuration["Tokens:Issuer"],
                      ValidAudience = Configuration["Tokens:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                      RequireSignedTokens = true,
                  };

              });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme);

                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = actionContext =>
            //    {
            //        var errors = actionContext.ModelState
            //            .Where(e => e.Value.Errors.Count > 0)
            //            .Select(e => new Error
            //            {
            //                Name = e.Key,
            //                Message = e.Value.Errors.First().ErrorMessage
            //            }).ToArray();

            //        return new BadRequestObjectResult(errors);
            //    };
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HIMS API", Version = "v1" });
                c.CustomSchemaIds(type => type.ToString());
                c.DescribeAllParametersInCamelCase();
                // To Enable authorization using Swagger (JWT)    
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, TUSAContext dbContext)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //dbContext.Database.Migrate();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HIMS API V1");
            });
        }
    }

    class Error
    {
        public string Name { get; set; }

        public string Message { get; set; }
    }
}
