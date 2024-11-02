using EFCoreBasicDemo.Infrastructure.MyEntities;
using EFCoreBasicDemo.Infrastructure.Repositories;
using EFCoreBasicDemo.Infrastructure.Services;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
ConfigureServices(builder.Services);
var app = builder.Build();
ConfigureMiddleware(app);
app.Run();

void ConfigureMiddleware(WebApplication app)
{
	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}
	app.UseHttpsRedirection();
	app.UseAuthorization();
	app.MapControllers();
	app.UseCors("AllowSpecificOrigin");
}
void ConfigureServices(IServiceCollection services)
{
	services.AddCors(options =>
	{
		options.AddPolicy("AllowSpecificOrigin",
			builder => builder
			.AllowAnyHeader() // 允许任何HTTP标头
			.AllowAnyMethod()// 允许任何HTTP方法
			.WithOrigins("http://localhost:4200"));  // 允许特定来源的跨域请求
	});

	services.AddScoped<StaffRepository>();
	services.AddScoped<StaffService>();
	services.AddScoped<StaffExpanedService>();
	services.AddScoped<CompanyRepository>();

	// services.AddControllers().AddNewtonsoftJson();
	services.AddControllers().AddNewtonsoftJson(options =>
	{
		// 修改属性名称的序列化方式，首字母小写，即驼峰样式
		options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		// 日期类型默认格式化处理 方式1
		// options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" });
		// 日期类型默认格式化处理 方式2
		options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
		options.SerializerSettings.DateFormatString = "yyyy/MM/dd HH:mm:ss";

		// 忽略循环引用
		options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

		// 解决命名不一致问题 
		options.SerializerSettings.ContractResolver = new DefaultContractResolver();

		// 空值处理
		options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
	});
	services.AddMvc();
	//services.AddMvc().AddJsonOptions(options =>
	//{
	//	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
	//	options.JsonSerializerOptions.WriteIndented = true;
	//});

	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	services.AddEndpointsApiExplorer();
	services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyEFCoreDemo1", Version = "v1.1" });
	});
	services.AddDbContext<EFCoreDemoContext>();
}