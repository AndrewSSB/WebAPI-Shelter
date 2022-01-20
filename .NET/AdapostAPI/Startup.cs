using AdapostAPI.BLL.Helper;
using AdapostAPI.BLL.Interfaces;
using AdapostAPI.BLL.Managers;
using AdapostAPI.DAL;
using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using AdapostAPI.DAL.Repositories;
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
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdapostAPI
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

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnString")));
            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);

            services.AddTransient<IAdapostRepository, AdapostRepository>(); //daca il mai scrii odata, il ia pe al 2-lea
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<IAngajatRepository, AngajatRepository>();
            services.AddTransient<IAdoptantRepository, AdoptantiRepository>();
            services.AddTransient<IAsociatieRepository, AsociatieRepository>();
            services.AddTransient<IAdapostAsociatieRepository, AdapostAsociatieRepository>();
            services.AddTransient<IVizitatorRepository, VizitatorRepository>();
            services.AddTransient<IAdapostVizitatorRepository, AdapostVizitatorRepository>();

            services.AddTransient<IAdapostManager, AdapostManager>();
            services.AddTransient<IAnimalManager, AnimalManager>();
            services.AddTransient<IAngajatManager, AngajatManager>();
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddTransient<IAdoptantiManager, AdoptantiManager>();
            services.AddTransient<IVizitatorManager, VizitatorManager>();
            services.AddTransient<IViziteManager, ViziteManager>();
            services.AddTransient<IAsociatieManager, AsociatieManager>();
            services.AddTransient<ISponsorizareManager, SponsorizareManager>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.AddTransient<IAuthManager, AuthManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdapostAPI", Version = "v1" });
            });


            //Identity
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(options =>
                {

                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("AuthScheme", options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    var secret = Configuration.GetSection("Jwt").GetSection("Token").Get<String>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
                opt.AddPolicy("User", policy => policy.RequireRole("User").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
                opt.AddPolicy("User, Admin", policy => policy.RequireRole("User").RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
            });

            services.AddTransient<InitialSeed>(); //nu i-am mai creeat o interfata

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44390", "http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InitialSeed initialSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdapostAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //initialSeed.CreateRoles(); //dupa ce avem totul in baza, putem sa comentam
        }                              //chiar daca la o noua rulare nu se mai creaza aceste roluri.
    }
}
