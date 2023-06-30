var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();  

//para que compile los cambios en tiempo de ejecucion 
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default", 
    //Cambio la pagina que quiero ejecutar al inicio
    pattern: "{controller=Mantenedor}/{action=Guardar}/{id?}");

app.Run();
