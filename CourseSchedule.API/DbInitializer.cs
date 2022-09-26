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
            using CourseScheduleDBContext context = serviceScope.ServiceProvider.GetService<CourseScheduleDBContext>() ?? throw new NullReferenceException("Invalid DBConext");
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
            if (context.Institutions.Any())
            {
                _logger.LogInformation("Databse has already been seeded.");
                return;
            }

            _logger.LogInformation("Attempting to set directory for seeding data");

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory + "SeedingData/");

            _logger.LogInformation("Successfully set the directory for seeding data");

            List<string> files = new()
            {
                "Institutions.json",
                "Disciplines.json"
            };

            Dictionary<Guid, Institution> institutions = new();
            Dictionary<Guid, Discipline> disciplines = new();

            for (int file = 0; file < files.Count; file++)
            {
                string text = File.ReadAllText(files[file]);
                Dictionary<string, object> deserializedInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(text) ?? throw new NullReferenceException("Invalid seed file json.");
                JArray infoList = (JArray)deserializedInfo["Data"];

                _logger.LogInformation("Attempting to add the data for {files}.", files[file]);

                foreach (JObject data in infoList.Cast<JObject>())
                {
                    switch (file)
                    {
                        case 0: // Instutitions
                            {
                                Institution institution = new()
                                {
                                    Name = (string)data["Name"]
                                };

                                institutions[institution.Id] = institution;
                                context.Add(institution);
                                context.SaveChanges();

                                break;
                            }
                        case 1:
                            {
                                // Add discipline to institution
                                Institution institution = context.Institutions.Where(i => i.Name == data["InstitutionName"].ToString()).First();

                                Discipline discipline = new(institution)
                                {
                                    Name = (string)data["Name"],
                                    MajorCode = (string)data["MajorCode"],
                                    IsMajor = (bool)data["IsMajor"]
                                };

                                institution.Disciplines.Add(discipline);

                                disciplines[discipline.Id] = discipline;

                                context.Add(discipline);
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
