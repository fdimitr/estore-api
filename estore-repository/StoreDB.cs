using estore_model;
using estore_repository.Migrations;
using System.Data.Entity;

namespace estore_repository
{
    public class StoreDB : DbContext
    {
        public StoreDB()
            : base("name=StoreDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreDB, ObjextContextMigration>());
        }

        public virtual DbSet<Category> Categories { get; set; }
    }
}
