using Microsoft.EntityFrameworkCore;
using NetCore_API.Entities;

namespace NetCore_API.Database
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }

        public virtual DbSet<Usuario> tUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}