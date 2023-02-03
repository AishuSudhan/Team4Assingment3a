using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Data
{
    public static class MigrateDatabase
    {
        public static void EnsureCreated(EventOrdersContext context)
        {
            context.Database.Migrate();
        }
    }
}
