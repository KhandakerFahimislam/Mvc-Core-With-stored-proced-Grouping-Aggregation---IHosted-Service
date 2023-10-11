using Microsoft.EntityFrameworkCore;
using Project_1273081_M09_P1.Models;

namespace Project_1273081_M09_P1.HostedServices
{
    public class ApplyMigrationService
    {
        private readonly TeacherDbContext db;
        public ApplyMigrationService(TeacherDbContext db)
        {
            this.db = db;
        }
        public async Task ApplyAsync()
        {
            var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await db.Database.MigrateAsync();
            }
        }
    }
}
