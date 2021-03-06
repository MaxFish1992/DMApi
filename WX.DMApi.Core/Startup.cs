using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using WX.DMApi.IServices;
using WX.DMApi.Services;
using WX.DMApi.Services.DataContext;
using WX.DMApi.Util;

namespace WX.DMApi.Core
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
            //配置跨域处理，允许所有来源：
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyHeader()
                        .AllowCredentials();
                }));

            services.AddControllers();

            services.AddDbContext<ProductContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IProductService, ProductService>();

            services.AddDbContext<ZxcProductContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IZxcProductService, ZxcProductService>();

            services.AddDbContext<OrderContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IOrderService, OrderService>();

            services.AddDbContext<ZxcOrderContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IZxcOrderService, ZxcOrderService>();

            services.AddDbContext<NewZxcOrderContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<INewZxcOrderService, NewZxcOrderService>();

            services.AddDbContext<UserContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<MenuContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IMenuService, MenuService>();

            //配置文件大小限制
            //services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = 60000000;
            //});

            #region 依赖注入
            services.AddSingleton<IQRCode, RaffQRCode>();
            #endregion

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = "igbom_web",//Audience
                        ValidIssuer = "igbom_web",//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))//拿到SecurityKey
                    };
                });

            #region swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("V1", new OpenApiInfo
                    {
                        Version = "V1",//版本号
                        Title = $"DM 接口文档——.Net Core 3.1",//编辑标题
                        Description = $"DM HTTP API V1",//编辑描述
                        Contact = new OpenApiContact { Name = "DM", Email = "348756718@qq.com" },//编辑联系方式
                        License = new OpenApiLicense { Name = "DM" }//编辑许可证
                    });
                    c.OrderActionsBy(o => o.RelativePath);

                    var xmlPath = Path.Combine(ApplicationEnvironment.ApplicationBasePath, "WX.DMApi.Core.xml");// 配置接口文档文件路径
                    c.IncludeXmlComments(xmlPath, true); // 把接口文档的路径配置进去。第二个参数表示的是是否开启包含对Controller的注释容纳
                });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"DM V1");
                    c.RoutePrefix = "";
                });


            #endregion

            // 设置允许所有来源跨域
            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
