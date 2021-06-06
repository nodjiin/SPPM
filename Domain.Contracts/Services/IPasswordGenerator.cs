using System.Collections.Generic;

namespace DomainModel.Contracts.Services
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(IReadOnlyCollection<char> charSet, IReadOnlyCollection<char> numberSet,
            IReadOnlyCollection<char> specialCharSet,
            int passLength, bool includeUpperCase);
    }
}