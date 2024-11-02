using EFCoreBasicDemo.Infrastructure.MyEntities;
using EFCoreBasicDemo.Infrastructure.Repositories;
using EFCoreBasicDemo.Infrastructure.Services;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

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

	services.AddControllers();
	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	services.AddEndpointsApiExplorer();
	services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyEFCoreDemo1", Version = "v1.1" });
	});
	services.AddDbContext<EFCoreDemoContext>();
	services.AddMvc().AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	});
}