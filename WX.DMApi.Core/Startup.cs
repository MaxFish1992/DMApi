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
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WX.DMApi.IServices;
using WX.DMApi.Services;
using WX.DMApi.Services.DataContext;
using WX.DMApi.Util;

namespace WX.DMApi.Core
{
    public class Startup
    {
        //private ScanerHook listener = new ScanerHook();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //listener.ScanerEvent += Listener_ScanerEvent;
            //listener.Start();

            //�����˳��¼�
            //AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            //ж���¼�
            //AssemblyLoadContext.Default.Unloading += Default_Unloading;
        }

        //private void Default_Unloading(AssemblyLoadContext obj)
        //{
        //    listener.Stop();
        //}

        //private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        //{
        //    listener.Stop();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //���ÿ���������������Դ��
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyHeader()
                        .AllowCredentials();
                }));

            services.AddControllers();

            services.AddDbContext<OrderContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IOrderService, OrderService>();

            services.AddDbContext<UserContext>(options => options.UseMySql(Configuration.GetConnectionString("DMConnection")));
            services.AddScoped<IUserService, UserService>();

            #region ����ע��
            services.AddSingleton<IQRCode, RaffQRCode>();
            #endregion

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//�Ƿ���֤Issuer
                        ValidateAudience = true,//�Ƿ���֤Audience
                        ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
                        ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
                        ValidAudience = "igbom_web",//Audience
                        ValidIssuer = "igbom_web",//Issuer���������ǰ��ǩ��jwt������һ��
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))//�õ�SecurityKey
                    };
                });

            #region swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("V1", new OpenApiInfo
                    {
                        Version = "V1",//�汾��
                        Title = $"DM �ӿ��ĵ�����.Net Core 3.1",//�༭����
                        Description = $"DM HTTP API V1",//�༭����
                        Contact = new OpenApiContact { Name = "DM", Email = "348756718@qq.com" },//�༭��ϵ��ʽ
                        License = new OpenApiLicense { Name = "DM" }//�༭���֤
                    });
                    c.OrderActionsBy(o => o.RelativePath);

                    var xmlPath = Path.Combine(ApplicationEnvironment.ApplicationBasePath, "WX.DMApi.Core.xml");// ���ýӿ��ĵ��ļ�·��
                    c.IncludeXmlComments(xmlPath, true); // �ѽӿ��ĵ���·�����ý�ȥ���ڶ���������ʾ�����Ƿ���������Controller��ע������
                });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            // ��������������Դ����
            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private static void Listener_ScanerEvent(ScanerHook.ScanerCodes codes)
        //{

        //}
    }
}
