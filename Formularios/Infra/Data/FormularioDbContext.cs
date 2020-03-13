using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Data.Configuration;
using Shared;

namespace Infra.Data
{
    public class FormularioDbContext : DbContext, IContext
    {
        public FormularioDbContext(DbContextOptions<FormularioDbContext> options) : base(options) { }
        public DbSet<Modelo> Modelo { get { return this.Set<Modelo>(); } }
        public DbSet<Atributo> Atributo { get { return this.Set<Atributo>(); } }
        public DbSet<TipoAtributo> TipoAtributo { get { return this.Set<TipoAtributo>(); } }
        public DbSet<ModeloAtributo> ModeloAtributo { get { return this.Set<ModeloAtributo>(); } }
        public DbSet<ModeloCompleto> ModeloCompleto { get { return this.Set<ModeloCompleto>(); } }
        public DbSet<AtributoCompleto> AtributoCompleto { get { return this.Set<AtributoCompleto>(); } }

        public int Commit()
        {
            return this.SaveChanges();
        }
        
        public Task<int> CommitAsync()
        {
            return this.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return this.DbSet<T>();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtributoConfiguration());
            modelBuilder.ApplyConfiguration(new ModeloConfiguration());
            modelBuilder.ApplyConfiguration(new ModeloAtributoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoAtributoConfiguration());

            modelBuilder.Entity<ModeloCompleto>().HasNoKey().ToView("vw_modelocompleto");
            modelBuilder.Entity<AtributoCompleto>().HasNoKey().ToView("vw_atributos");
        }
    }
}
