using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StridingSoft.Services.Models.GenTrees
{
    public partial class GenTreesEntities
    {
        public GenTreesEntities(string connectionString) {
            this.Database.Connection.ConnectionString = connectionString;
        }
    }
}