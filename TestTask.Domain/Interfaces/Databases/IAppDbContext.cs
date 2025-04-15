using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Interfaces.Databases
{
    public interface IAppDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
