namespace StridingSoft.Models.Collectioner {
    public partial class CollectionerEntities {
        public CollectionerEntities(string connectionString) {
            this.Database.Connection.ConnectionString = connectionString;
        }
    }
}