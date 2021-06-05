using System;

namespace Infrastructure.Contracts.Repositories.Foundation
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IProfileRepository Profiles { get; }
        int Complete();
    }
}