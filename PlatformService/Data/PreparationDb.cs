using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PreparationDb
    {
        public static void Population(IApplicationBuilder app)
        {
            using (var scoped = app.ApplicationServices.CreateScope())
            {
                Seed(scoped.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void Seed(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                context.Platforms.AddRange(
                    new Platform() { Name = "C#", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Java", Publisher = "Oracle", Cost = "Free" },
                    new Platform() { Name = "C", Publisher = "ISO", Cost = "Free" }
                );

                context.SaveChanges();
            }
        }
    }
}
