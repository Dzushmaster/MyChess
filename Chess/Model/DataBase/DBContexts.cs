using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.DataBase
{
    class DBContexts:DbContext
    {
        public DBContexts() : base("DefaultConnection") { }
        public DbSet<Player> Players { get; set; }
    }
}
