using FitskedApp.Client.Pages;
using FitskedApp.Components;
using FitskedApp.Components.Account;
using FitskedApp.Data;
using FitskedApp.Data.Repository;
using FitskedApp.Data.Service;
using FitskedApp.Helpers;
using FitskedApp.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;




builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddScoped<IUserPlanRepository, UserPlanRepository>();
builder.Services.AddScoped<IUserWorkoutRepository, UserWorkoutRepository>();
builder.Services.AddScoped<IUserExerciseRepository, UserExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IFilteredExercisesManager, FilteredExercisesManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserPlanRepository, UserPlanRepository>();
builder.Services.AddScoped<IUserService,IdentityUserService>();
builder.Services.AddScoped<IUIFunctionality, UIFunctionality>();
builder.Services.AddScoped<NavigationLinks>();




builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Database connection string is not set. Please configure 'DB_CONNECTION_STRING'.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Updated migration logic with retry
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    try
    {
        var efMigrate = Environment.GetEnvironmentVariable("EF_MIGRATE");

        if (!string.IsNullOrEmpty(efMigrate) && efMigrate.ToLower() == "true")
        {
            Console.WriteLine("EF_MIGRATE is set to true. Applying migrations...");
            var context = service.GetRequiredService<ApplicationDbContext>();

            const int maxRetryCount = 5;
            const int delayMilliseconds = 5000;
            int retryCount = 0;

            while (retryCount < maxRetryCount)
            {
                try
                {
                    await context.Database.MigrateAsync();
                    Console.WriteLine("Migrations applied successfully.");
                    break; // Exit the retry loop if successful
                }
                catch (Exception ex)
                {
                    retryCount++;
                    Console.WriteLine($"Migration attempt {retryCount} failed: {ex.Message}");
                    if (retryCount == maxRetryCount)
                    {
                        Console.WriteLine("Max retry attempts reached. Migration failed.");
                        throw; // Re-throw the exception to stop the app from running
                    }
                    Console.WriteLine($"Retrying in {delayMilliseconds / 1000} seconds...");
                    await Task.Delay(delayMilliseconds);
                }
            }
        }
        else
        {
            Console.WriteLine("EF_MIGRATE is not set to true. Skipping migrations.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error applying migrations: {ex.Message}");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FitskedApp.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();
app.MapGet("/", () => Results.Ok("Service is running."));
app.Run();

