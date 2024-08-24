using LapShop.Models;
using Microsoft.EntityFrameworkCore;
using LapShop.BL;
using LapShop.Bl;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LapShop2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//3 steps to use identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 4;
    //options.Password.RequireNonAlphanumeric = true;
    //options.Password.RequireUppercase= true;
    //options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<LapShop2Context>();



#region Custom Service

builder.Services.AddScoped<IClsCategories, ClsCategories>();
builder.Services.AddScoped<IClsItems, ClsItems>();
builder.Services.AddScoped<IClsItemTypes, ClsItemTypes>();
builder.Services.AddScoped<IClsOs, ClsOs>();
builder.Services.AddScoped<IItemImages, ClsItemImages>();
builder.Services.AddScoped<ISliders, ClsSliders>();
builder.Services.AddScoped<ISettings, ClsSettings>();
builder.Services.AddScoped<IPages, ClsPages>();
builder.Services.AddScoped<ISalesInvoice, ClsSalesInvoice>();
builder.Services.AddScoped<ISalesInvoiceItems, ClsSalesInvoiceItems>();

#endregion


//to add session 
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Users/AccessDenied";
    options.Cookie.Name = "Cookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
    options.LoginPath = "/Users/Login";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});



//builder.Services.AddSwaggerGen(obtions =>
//{
//    obtions.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Lao Shop Api",
//        Description = "api to access items and related categories",
//        TermsOfService = new Uri("https://itlegend.net/"),
//        Contact = new OpenApiContact
//        {
//
//
//
//
//
//
//
//
//
//            = "walid30189@gmail.com",
//            Name = "Emad Moawaad",
//            Url = new Uri("https://itlegend.net/")
//        },
//        License = new OpenApiLicense
//        {
//            Name = "It Legend Licence",
//            Url = new Uri("https://itlegend.net/")
//        }



//    });
   // var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
   // var fullPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    //options.IncludeXmlComments(fullPath);


//});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//app.UseSwagger();

//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix = string.Empty;
//});


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
//4 steps
app.UseAuthentication();
app.UseAuthorization();
//seasion
app.UseSession();



#region Routing

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");
    //endpoints.MapControllerRoute(
    //name: "admin",
    //pattern: "{area:exists}/{controller=Categories}/{action=List}");

    endpoints.MapControllerRoute(
        name: "LandingPages",
        pattern: "{area:exists}/{controller=Home}/{action=Index}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "ali",
    pattern: "ali/{controller=Home}/{action=Index}/{id?}");

}
);
app.Run(); 
#endregion
