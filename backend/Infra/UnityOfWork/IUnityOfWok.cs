using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.UnityOfWork
{
    public interface IUnitOfWork
    {
        DbConnection Connection { get; }

        DbTransaction Transaction { get; }        

        void AddContext(DbContext context);

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
