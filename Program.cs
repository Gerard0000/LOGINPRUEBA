using LoginPrueba.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()

//Para CRUD Multinivel para que no de vueltas
.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//INYECTAMOS EL DATACONTEXT
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=SqlConnection"));

//INYECTAMOS LOS SEEDERS
builder.Services.AddTransient<SeedDb>();

var app = builder.Build();

//VA CON LOS SEEDERS
SeedData(app);

//VA CON LOS SEDDERS
static void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    IServiceScope serviceScope = scopedFactory!.CreateScope();
    using IServiceScope? scope = serviceScope;
    SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
    service!.SeedAsync().Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();