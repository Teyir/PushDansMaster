using Microsoft.EntityFrameworkCore;

namespace PushDansMaster.API
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Fournisseurs> Fournisseurs { get; set; }

    }
}