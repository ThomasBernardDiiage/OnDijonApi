using AutoMapper;
using OnDijon;
using OnDijon.Controllers;
using OnDijon.DataAccess;
using OnDijon.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<UserMappingProfile>();
    cfg.AddProfile<MeanOfLocomotionProfile>();
    cfg.AddProfile<ReasonForTravelProfile>();
    cfg.AddProfile<ShelterProfile>();
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");
ItineraryController.ApiKey = builder.Configuration.GetValue<string>("GeoveloApiKey");

builder.Services.AddScoped(_ => new OnDijonDbContext(dbConnection));
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<NotFoundMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    FakeDataSeeder.Seed(app.Services);

    app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()); // MUST REMOVE THIS 
}

app.MapHub<ShelterBookingHub>("shelters/booking");



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
