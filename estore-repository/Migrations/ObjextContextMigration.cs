namespace estore_repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ObjextContextMigration : DbMigrationsConfiguration<StoreDB>
    {
        public ObjextContextMigration()
            : base()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(StoreDB context)
        {
            SeedLibrary seedLibrary = new SeedLibrary(context);
            seedLibrary.Category();
        }
    }
}
