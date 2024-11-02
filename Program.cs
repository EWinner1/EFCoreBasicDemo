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
			.AllowAnyHeader() // �����κ�HTTP��ͷ
			.AllowAnyMethod()// �����κ�HTTP����
			.WithOrigins("http://localhost:4200"));  // �����ض���Դ�Ŀ�������
	});

	services.AddScoped<StaffRepository>();
	services.AddScoped<StaffService>();
	services.AddScoped<StaffExpanedService>();
	services.AddScoped<CompanyRepository>();

	// services.AddControllers().AddNewtonsoftJson();
	services.AddControllers().AddNewtonsoftJson(options =>
	{
		// �޸��������Ƶ����л���ʽ������ĸСд�����շ���ʽ
		options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		// ��������Ĭ�ϸ�ʽ������ ��ʽ1
		// options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" });
		// ��������Ĭ�ϸ�ʽ������ ��ʽ2
		options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
		options.SerializerSettings.DateFormatString = "yyyy/MM/dd HH:mm:ss";

		// ����ѭ������
		options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

		// ���������һ������ 
		options.SerializerSettings.ContractResolver = new DefaultContractResolver();

		// ��ֵ����
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