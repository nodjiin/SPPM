using Domain.Model;
using Infrastructure.Contracts.Repositories.Foundation;

namespace Infrastructure.Contracts.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
    }
}