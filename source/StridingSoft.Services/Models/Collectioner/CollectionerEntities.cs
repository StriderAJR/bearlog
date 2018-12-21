using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StridingSoft.Services.Models.Collectioner
{
    public partial class CollectionerEntities
    {
        public CollectionerEntities(string connectionString) {
            this.Database.Connection.ConnectionString = connectionString;
        }
    }
}