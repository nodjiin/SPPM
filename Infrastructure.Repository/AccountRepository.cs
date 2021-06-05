using Infrastructure.Contracts.Repositories;
using Infrastructure.Entities.Contexts;
using Infrastructure.Entities.Models;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(SPPMContext context) : base(context)
        {
        }
    }
}