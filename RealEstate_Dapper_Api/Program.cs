using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_API.Hubs;
using RealEstate_Dapper_API.Repositories.AmenityPropertyRepositories;
using RealEstate_Dapper_API.Repositories.AppUserRepositories;
using RealEstate_Dapper_API.Repositories.BottomGridRepository;
using RealEstate_Dapper_API.Repositories.ContactRepository;
using RealEstate_Dapper_API.Repositories.EmployeeRepository;
using RealEstate_Dapper_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using RealEstate_Dapper_API.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_API.Repositories.MessageRepositories;
using RealEstate_Dapper_API.Repositories.PopularLocationRepository;
using RealEstate_Dapper_API.Repositories.ProductImageRepositories;
using RealEstate_Dapper_API.Repositories.ServiceRepository;
using RealEstate_Dapper_API.Repositories.StatisticsRepository;
using RealEstate_Dapper_API.Repositories.TestimonialRepository;
using RealEstate_Dapper_API.Repositories.ToDoListRepositories;
using RealEstate_Dapper_API.Repositories.WhoWeAreDetailRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();
builder.Services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IProductImageRepository, IProductImageRepository>();
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
builder.Services.AddTransient<IAmenityPropertyRepository, AmenityPropertyRepository>();

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader()
			   .AllowAnyMethod()
			   .SetIsOriginAllowed((host) => true)
			   .AllowCredentials();
	});
});

builder.Services.AddHttpClient();

builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/SignalRHub");

app.Run();
