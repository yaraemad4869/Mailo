using Microsoft.EntityFrameworkCore;
using Mailo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Mailo.Models;
using Mailo.IRepo;
using Mailo.Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Other service registrations

//builder.Services.AddScoped(typeof(BasicRepo<>), typeof(BasicRepo<>)); // Register generic repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(ILoginRepo), typeof(LoginRepo));
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddIdentity<Mailo.Models.User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddSingleton<IEmailSender>(new EmailSender(
    smtpHost: "smtp.gmail.com",
    smtpPort: 587,
    smtpUser: "Mailoeg093@gmail.com",
    smtpPass: "mailoeg0000"));  // Your Gmail password (use environment variables in production for security)

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
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
	name: "area",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints => endpoints.MapRazorPages());


app.Run();
