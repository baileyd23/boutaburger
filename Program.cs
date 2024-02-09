using boutaburger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
//using boutaburger.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<boutaburgerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Stores.MaxLengthForKeys = 128;
})
.AddEntityFrameworkStores<boutaburgerContext>()
.AddRoles<IdentityRole>()
.AddDefaultUI()
.AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmins", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeFolder("/addMenu", "RequireAdmins");
        options.Conventions.AuthorizeFolder("/DeleteAllMyHardWork", "RequireAdmins");
    });

builder.Services.AddDbContext<CartItemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CartItemsDbConnectionString")));
builder.Services.AddDbContext<MenuItemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MenuItemsDbConnectionString")));
builder.Services.AddDbContext<PastOrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PastOrdersDbConnectionString")));
builder.Services.AddDbContext<UserAccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AccountsDbConnectionString")));
builder.Services.AddDbContext<SearchDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SearchDbConnectionString")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
  //  .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

using(var scope = app.Services.CreateScope())
    {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<boutaburgerContext>();
    context.Database.Migrate();
    var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
    test.Initialize(context, userMgr, roleMgr).Wait();
}

app.Run();
