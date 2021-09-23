using Microsoft.EntityFrameworkCore;

namespace INFW.Core.DataAccess.EntityFrameworkCore.Configuration
{
    public interface IDbContextHelper
    {
        void UseEngine(DbContextOptionsBuilder optionsBuilder);
    }
}