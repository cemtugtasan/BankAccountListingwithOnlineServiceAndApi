using BankAccountProject.DbConnection;
using BankAccountProject.Presentation.ApiConnection;
using BankAccountProject.Presentation.ApiConnection.ApiInterface;
using BankAccountProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer("Server=;Initial Catalog=;User ID = ; Password = ;"));
builder.Services.AddBusinessServices();
builder.Services.AddScoped<IApiConnection,ApiConnection>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("BankAccounts", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://efatura.etrsoft.com/fmi/data/v1/databases/testdb/layouts/testdb/records");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});
builder.Services.AddHostedService<UpdateInformationWithTimer>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
