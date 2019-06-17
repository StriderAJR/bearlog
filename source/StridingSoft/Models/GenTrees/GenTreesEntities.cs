namespace StridingSoft.Models.GenTrees {
    public partial class GenTreesEntities {
        public GenTreesEntities(string connectionString) {
            this.Database.Connection.ConnectionString = connectionString;
        }
    }
}