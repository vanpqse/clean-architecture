using System.Threading.Tasks;

namespace ProductFake.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
