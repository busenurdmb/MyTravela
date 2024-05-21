using Travela.BusinessLayer.Abstract;
using Travela.BusinessLayer.Concrete;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.EntityFramework;

using Travela.DataAccessLayer.Context;
using Travela.EntityLayer.Concrete;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TravelaContext>();
builder.Services.AddDbContext<TravelaContext>();

builder.Services.AddCors(

//    cors =>
//{
//    //cors.AddPolicy("EnYakýnSatýcýCors", opt =>
//    //{
//    //    opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    //});

//}
);

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IDestinationDal, EfDestinationDal>();
builder.Services.AddScoped<IDestinationService, DestinationManager>();


builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();


builder.Services.AddScoped<IAboutFeatureDal, EfAboutFeatureDal>();
builder.Services.AddScoped< IAboutFeatureService, AboutFeatureManager>();


builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService,ContactManager>();

builder.Services.AddScoped<IGaleryDal, EfGaleryDal>();
builder.Services.AddScoped<IGaleryService, GaleryManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "File Upload API", Version = "v1" });

    var fileUploadSchema = new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Type = "object",
        Properties = {
                    { "file", new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string", Format = "binary" } }
                }
    };

    c.MapType<IFormFile>(() => fileUploadSchema);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "File Upload API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
