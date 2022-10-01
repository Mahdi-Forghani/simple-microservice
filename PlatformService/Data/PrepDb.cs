using PlatformService.Model;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void DbPrepPopulation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (dbContext != null)
                {
                    SeedData(dbContext);
                }
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                var platforms = new List<Platform>()
                {
                    new Platform() { Id=1, Name=".Net", Publisher="Microsoft", Cost="Free" },
                    new Platform() { Id=2, Name="SQL Server Express", Publisher="Microsoft", Cost="Free" },
                    new Platform() { Id=3, Name="Kubernates", Publisher="Cloud Native Computing Foundation", Cost="Free" }
                };

                context.AddRange(platforms);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}