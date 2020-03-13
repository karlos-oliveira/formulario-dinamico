using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public interface IContext : IDisposable
    {
        DbSet<Atributo> Atributo { get; }
        DbSet<Modelo> Modelo { get; }
        DbSet<ModeloAtributo> ModeloAtributo { get; }
        DbSet<TipoAtributo> TipoAtributo { get; }
        DbSet<ModeloCompleto> ModeloCompleto { get; }
        DbSet<AtributoCompleto> AtributoCompleto { get; }

        DatabaseFacade Database { get; }
        DbSet<T> DbSet<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();

    }
}
