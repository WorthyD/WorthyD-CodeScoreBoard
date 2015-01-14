using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace WorthyD.CodeScoreBoard.DataAccess
{
    public class CodeScoreBoardContext : DbContext
    {

        public CodeScoreBoardContext()
            : base("ScoreBoard")
        {
        }
        //public DbSet<Models.Event> Events { get; set; }
        //public DbSet<Models.Person> People { get; set; }
        public DbSet<Models.CodeLog> CodeLogs { get; set; }
        public DbSet<Models.Project> Projects { get; set; }
    }
}
