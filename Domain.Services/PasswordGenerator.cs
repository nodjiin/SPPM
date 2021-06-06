using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Contracts.Services;

namespace Domain.Services
{
    public class PasswordGenerator : IPasswordGenerator
    {
        public string GeneratePassword(IReadOnlyCollection<char> charSet, IReadOnlyCollection<char> numberSet, 
            IReadOnlyCollection<char> specialCharSet,
            int passwordLength, bool includeUpperCase)
        {
            if (charSet == null) throw new ArgumentNullException(nameof(charSet));
            if (numberSet == null) throw new ArgumentNullException(nameof(numberSet));
            if (specialCharSet == null) throw new ArgumentNullException(nameof(specialCharSet));

            switch (charSet.Any())
            {
                case false when !numberSet.Any() && !specialCharSet.Any():
                    throw new ArgumentException("At least one of the 3 characters collections shouldn't be empty");
                case false when includeUpperCase:
                    throw new ArgumentException($"To include a collection of upper case characters {nameof(charSet)} shouldn't be empty");
            }

            var fullCharSets = new List<IReadOnlyCollection<char>>();
            
            if (charSet.Any()) fullCharSets.Add(charSet);
            if (numberSet.Any()) fullCharSets.Add(numberSet);
            if (specialCharSet.Any()) fullCharSets.Add(specialCharSet);
            if (includeUpperCase) fullCharSets.Add(GenerateUpperCaseCharSet(charSet));
            
            return FillPasswordFromCharSets(passwordLength, fullCharSets);
        }

        private static string FillPasswordFromCharSets(int passwordLength, IReadOnlyList<IReadOnlyCollection<char>> fullCharSets)
        {
            var generatedPassword = string.Empty;
            var rand = new Random();

            for (var i = 0; i < passwordLength; i++)
            {
                var charGroupIndex = rand.Next(1, fullCharSets.Count);
                AddRandomCharToPassword(fullCharSets[charGroupIndex], rand, generatedPassword);
            }

            return generatedPassword;
        }

        private IReadOnlyCollection<char> GenerateUpperCaseCharSet(IEnumerable<char> charSet)
        {
            return charSet.Select(char.ToUpper).ToList();
        }

        private static void AddRandomCharToPassword(IReadOnlyCollection<char> charSet, Random rand, string password)
        {
            var index = rand.Next(0, charSet.Count);
            password = $"{password}{charSet.ElementAt(index).ToString()}";
        }
    }
}