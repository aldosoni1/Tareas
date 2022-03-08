using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using PJENL.Shared.Kernel.EntityFramework.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class TareaContext : DbContext
    {
        private readonly IEFInterceptor _interceptor;
        public DbSet<Tarea> Tarea { get; set; }
        public TareaContext(IEFInterceptor interceptor, DbContextOptions<TareaContext> options):base(options)
        {
            this._interceptor = interceptor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().HasKey(x => x.Id);
            modelBuilder.Entity<Tarea>().Property(x => x.IdTrack).HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Tarea>().Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<Tarea>().HasQueryFilter(x => EF.Property<bool>(x, nameof(x.Eliminado)) == false);
            modelBuilder.Entity<Tarea>().HasOne(x => x.Usuario).WithMany(x => x.Tareas).HasForeignKey(x => x.IdUsuario);
            modelBuilder.Entity<Usuario>().HasKey(x=>x.Id);
            modelBuilder.Entity<Usuario>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Usuario>().HasMany(x => x.Tareas).WithOne(x => x.Usuario).HasForeignKey(x => x.IdUsuario);
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            _interceptor.Intercept(ChangeTracker.Entries());
            _interceptor.InterceptTracker(ChangeTracker.Entries());
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _interceptor.Intercept(ChangeTracker.Entries());
            _interceptor.InterceptTracker(ChangeTracker.Entries());
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
