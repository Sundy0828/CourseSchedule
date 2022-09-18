using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CourseSchedule.API
{
    public class DbInitializer : IServiceInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(IServiceScopeFactory scopeFactory, ILogger<DbInitializer> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public void Initialize()
        {
            using IServiceScope serviceScope = _scopeFactory.CreateScope();
            using CourseScheduleDBContext context = serviceScope.ServiceProvider.GetService<CourseScheduleDBContext>();
            _logger.LogInformation("Attempting to initialize data storage");
            context.Database.Migrate();

            if (Environment.GetEnvironmentVariable("SEED_INSERT_DATA") == "1")
            {
                _logger.LogInformation("Starting to seed data");
                SeedData(context);
            }
            else
            {
                _logger.LogInformation("Skipping seed data");
            }
        }

        public void SeedData(CourseScheduleDBContext context)
        {
            _logger.LogInformation("Attempting to set directory for seeding data");

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory + "SeedingData/");

            _logger.LogInformation("Successfully set the directory for seeding data");

            List<string> files = new()
            {
                "Institutions.json"
            };

            for (int i = 0; i < files.Count; i++)
            {
                string text = File.ReadAllText(files[i]);
                Dictionary<string, object> deserializedInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
                JArray infoList = (JArray)deserializedInfo["data"];

                _logger.LogInformation("Attempting to add the data for {files}.", files[i]);

                foreach (JObject data in infoList)
                {
                    switch (i)
                    {
                        case 0: // Instutitions
                            {
                                Institution institutions = new(
                                    (string)data["name"]
                                );

                                context.Add(institutions);
                                context.SaveChanges();

                                break;
                            }
                        case 1:
                            {
                                Discipline disciplines = new
                                (
                                    (string)data["name"],
                                    (bool)data["is_major"]
                                );

                                context.Add(disciplines);
                                context.SaveChanges();

                                break;
                            }
                        default:
                            {
                                throw new Exception();
                            }
                    }
                }
            }
        }
    }
}
