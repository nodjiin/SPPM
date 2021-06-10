using Infrastructure.Contracts.Repositories;
using Infrastructure.Contracts.Repositories.Foundation;
using Infrastructure.Entities.Contexts;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SPPMContext _context;

        public UnitOfWork(SPPMContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
            Profiles = new ProfileRepository(_context);
        }

        public IAccountRepository Accounts { get; }
        public IProfileRepository Profiles { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}