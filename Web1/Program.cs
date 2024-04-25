var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name:"Araba",
    pattern:"car/index"
    );

app.MapControllerRoute(
    name:"Ozel",
    pattern:"ozelalan/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name:"Yeni",
    pattern:"yeni/{controller=Home}/{action=index}"
    );


app.Run();
