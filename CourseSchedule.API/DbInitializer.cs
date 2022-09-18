﻿using CourseSchedule.Core;
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
            if (context.Institutions.Count() > 0)
            {
                _logger.LogInformation("Databse has already been seeded.");
                return;
            }

            _logger.LogInformation("Attempting to set directory for seeding data");

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory + "SeedingData/");

            _logger.LogInformation("Successfully set the directory for seeding data");

            List<string> files = new()
            {
                "Institutions.json"
            };

            Dictionary<Guid, Institution> institutions = new();

            for (int file = 0; file < files.Count; file++)
            {
                string text = File.ReadAllText(files[file]);
                Dictionary<string, object> deserializedInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
                JArray infoList = (JArray)deserializedInfo["data"];

                _logger.LogInformation("Attempting to add the data for {files}.", files[file]);

                foreach (JObject data in infoList)
                {
                    switch (file)
                    {
                        case 0: // Instutitions
                            {
                                Institution i = new(
                                    (string)data["Name"]
                                );

                                institutions[i.Id] = i;
                                context.Add(i);
                                context.SaveChanges();

                                break;
                            }
                        case 1:
                            {
                                Institution institution = context.Institutions.Where(i => i.Name == data["InstitutionName"].ToString()).FirstOrDefault();
                                Discipline disciplines = new
                                (
                                    institution.Id,
                                    (string)data["MajorCode"],
                                    (string)data["Name"],
                                    (bool)data["IsMajor"]
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
