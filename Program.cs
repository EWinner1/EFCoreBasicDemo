using EFCoreDemo1.Infrastructure.Entities;
using EFCoreDemo1.Infrastructure.Repositories;
using EFCoreDemo1.Infrastructure.Services;
using Microsoft.OpenApi.Models;

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
	services.AddControllers();
	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	services.AddEndpointsApiExplorer();
	services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyEFCoreDemo1", Version = "v1.1" });
	});
	services.AddDbContext<EFCoreDemoContext>();
	services.AddMvc();
}