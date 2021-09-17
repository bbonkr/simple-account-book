using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SimpleAccountBook.Data.Seeder;

namespace SimpleAccountBook.Data
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigrations(this IApplicationBuilder app, bool recreateOnStartup = false, bool seedSampleData = false)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    if (recreateOnStartup)
                    {
                        dbContext.Database.EnsureDeleted();
                    }

                    dbContext.Database.Migrate();

                    if (seedSampleData)
                    {
                        var hasChanges = false;
                        if (!dbContext.Users.Any())
                        {
                            dbContext.Users.AddRange(UserSeeder.GetUser());
                            hasChanges = true;
                        }

                        if (!dbContext.Codes.Any())
                        {
                            dbContext.Codes.AddRange(GeneralCodeSeeder.GetCodes());
                            hasChanges = true;
                        }

                        if (hasChanges)
                        {
                            dbContext.SaveChanges();
                        }
                    }
                }
            }

            return app;
        }
    }
}
