using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Shared
{
    public interface IUnitOfWork
    {
        void Rollback();

        Task CommitAsync();

        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}
