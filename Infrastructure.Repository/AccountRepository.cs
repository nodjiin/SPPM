using System.Linq;
using Domain.Model;
using Infrastructure.Contracts.Repositories;
using Infrastructure.Entities.Contexts;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(SPPMContext context) : base(context)
        {
        }

        public SPPMContext SppmContext => Context as SPPMContext;
        public int GetAssociatedProfileId() => SppmContext.Accounts.FirstOrDefault()?.ProfileId ?? -1;
        public int GetNewValidId() => SppmContext.Accounts.Local.Select(a => a.Id).Max() + 1;
    }
}