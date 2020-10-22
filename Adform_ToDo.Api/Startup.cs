using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Helpers;
using Adform_Todo.Common.Models;
using Adform_ToDo.API.Middlewares;
using Adform_ToDo.API.Services;
using Adform_ToDo.BL;
using Adform_ToDo.Common.Constants;
using Adform_ToDo.CommonLib.Contracts.DbOps;
using Adform_ToDo.DAL;
using Adform_ToDo.DAL.DbContexts;
using Adform_ToDo.Middlewares;
using AutoMapper;
using CorrelationId;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;

namespace Adform_ToDo
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
            services.AddDbContext<ToDoDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString(Constants.SqlConnectionString)));
            services.Configure<AppSettings>(Configuration.GetSection(Constants.AppSettings));
            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));

            //configure services for checking, logging and forwarding correlationID.
            services.AddCorrelationIdHandlerAndDefaults();

            services.AddControllers(p => p.RespectBrowserAcceptHeader = true).AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();
            services.AddHttpContextAccessor();
            services.AddApiVersioning(x =>
                    {
                        x.DefaultApiVersion = new ApiVersion(1, 0);
                        x.AssumeDefaultVersionWhenUnspecified = true;
                        x.ReportApiVersions = true;
                    });
            //Configure InApp services
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<IToDoListManager, ToDoListManager>();
            services.AddTransient<IToDoListDal, ToDoListDal>();
            services.AddTransient<ILabelManager, LabelManager>();
            services.AddTransient<ILabelDal, LabelDal>();
            services.AddTransient<IToDoItemManager, ToDoItemManager>();
            services.AddTransient<IToDoItemDal, ToDoItemDal>();

            services.AddJwtAuthentication(Configuration);
            services.AddAuthorization(config =>
            {
                config.AddPolicy(Constants.Admin,
                    policy => policy.RequireClaim(ClaimTypes.Role, new string[] { Constants.Admin }));
                config.AddPolicy(Constants.User,
                    policy => policy.RequireClaim(ClaimTypes.Role, new string[] { Constants.User }));
            });

            //Configure Swagger services.
            services.AddSwagger();

            services.AddCors(options =>
            {
                options.AddPolicy(Constants.AllowAllCors,
                                  builder =>
                                  {
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyOrigin();
                                  });
            });
            services.AddGraphQLServices();
            services.AddControllersWithViews(options =>
                    {
                        options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
                    })
                    .AddNewtonsoftJson();
        }
        //This method gets NewtonsoftJsonPatchInputFormatter for formatting JsonPatch document input.
        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            ServiceProvider builder = new ServiceCollection()
                .AddLogging()
                .AddMvc().AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()))
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();
            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Constants.LogFile, isJson: true);
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                ToDoDbContext toDoContext = serviceScope.ServiceProvider.GetRequiredService<ToDoDbContext>();
                toDoContext.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorrelationId();
            app.UseContentLocationMiddleware();
            app.UseRequestResponseLogging();
            app.ConfigureExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseJwtMiddleware();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseGraphQL()
                .UsePlayground();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Adform ToDo API v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
