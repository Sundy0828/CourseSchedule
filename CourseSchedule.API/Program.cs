using CourseSchedule.API;
using CourseSchedule.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

try
{
    var builder = WebApplication.CreateBuilder(args);
    ConfigureServices(builder);

    var app = builder.Build();
    List<IServiceInitializer> serviceInitializers = app.Services.GetServices<IServiceInitializer>().ToList();
    foreach (var serviceInitializer in serviceInitializers)
    {
        serviceInitializer.Initialize();
    }
    ConfigureApplication(app);

    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine("Web host failed to start correctly");
    Console.WriteLine(ex);
    return 1;
}
finally
{
    Console.Out.Flush();
}
return 0;

static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<CourseScheduleDBContext>((config) =>
    {
        AppSettings settings = GetSettings(builder.Configuration);
        config.UseNpgsql(settings.ConnectionStrings.DefaultConnection, c =>
        {
            c.MigrationsAssembly(typeof(CourseScheduleDBContext).Assembly.GetName().Name);
            c.EnableRetryOnFailure(5);
        });
    });

    builder.Services.AddMemoryCache();

    builder.Services.AddScoped<InstitutionLogic>();

    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen(c =>
    {
        c.EnableAnnotations();

        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "CourseSchedule",
            Version = "v1",
            Description = "This is an API"
        });

        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        foreach (var file in dir.GetFiles("*.xml"))
        {
            c.IncludeXmlComments(file.FullName);
        }

        c.SchemaFilter<SwaggerFilter>();
    });

    builder.Services.AddServiceInitializer<DbInitializer>();

    //builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    //{
    //    options.InvalidModelStateResponseFactory = context =>
    //    {
    //        FormatValidationProblemDetails problems new(context);

    //        throw problems.GetDetails();
    //    }
    //});
}

static void ConfigureApplication(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourseSchedule v1");

        c.RoutePrefix = "swagger";
        c.DefaultModelExpandDepth(-1);
    });
}

static AppSettings GetSettings(IConfigurationRoot configuration) => configuration.Get<AppSettings>();
