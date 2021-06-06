using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

namespace Domain.Services.Unit.Tests
{
    [TestFixture]
    public class PasswordGenerator_Test
    {
        private PasswordGenerator _generator;
        private IReadOnlyCollection<char> _charSet;
        private IReadOnlyCollection<char> _numberSet;
        private IReadOnlyCollection<char> _specialCharSet;
        private IReadOnlyCollection<char> _fullCharSet;
        
        [SetUp]
        public void SetUp()
        {
            _generator = new PasswordGenerator();
            _charSet = new[] { 'a', 'b', 'c', 'd' };
            _numberSet = new[] { '1', '2', '3' };
            _specialCharSet = new[] { '+', '-' };
            _fullCharSet = new[] { 'a', 'b', 'c', 'd', 'A', 'B', 'C', 'D', '1', '2', '3', '+', '-' };
        }
                
        [Test]
        public void PasswordGenerator_charSetIsNull_ThrowArgumentNullException()
        {
            _charSet = null;

            Assert.That(() => _generator.GeneratePassword(_charSet, _numberSet, _specialCharSet),
                Throws.ArgumentNullException);
        }

        [Test]
        public void PasswordGenerator_specialCharSetIsNull_ThrowArgumentNullException()
        {
            _specialCharSet = null;

            Assert.That(() => _generator.GeneratePassword(_charSet, _numberSet, _specialCharSet),
                Throws.ArgumentNullException);
        }

        [Test]
        public void PasswordGenerator_numberSetIsNull_ThrowArgumentNullException()
        {
            _numberSet = null;

            Assert.That(() => _generator.GeneratePassword(_charSet, _numberSet, _specialCharSet),
                Throws.ArgumentNullException);
        }
        
        [Test]
        public void PasswordGenerator_AllTheSetsAreEmpty_ThrowArgumentException()
        {
            _charSet = new Collection<char>();
            _numberSet = new Collection<char>();
            _specialCharSet = new Collection<char>();

            Assert.That(() => _generator.GeneratePassword(_charSet, _numberSet, _specialCharSet),
                Throws.ArgumentException);
        }
        
        [Test]
        public void PasswordGenerator_CharSetIsEmptyAndUpperCaseAttributeIsTrue_ThrowArgumentException()
        {
            _charSet = new Collection<char>();

            Assert.That(() => _generator.GeneratePassword(_charSet, _numberSet, _specialCharSet),
                Throws.ArgumentException);
        }
        
        [Test]
        public void PasswordGenerator_3SetDefined_ReturnPasswordWithContainingOnlyElementsOfTheSets()
        {
            var password = _generator.GeneratePassword(_charSet, _numberSet, _specialCharSet);
            
            Assert.That(password.ToCharArray().Distinct(), Is.SubsetOf(_fullCharSet));
        }
        
        [Test]
        [TestCase(20)]
        public void PasswordGenerator_PasswordLengthDefined_ReturnPasswordWithRequestedLength(int length)
        {
            var password = _generator.GeneratePassword(_charSet,
                _numberSet,
                _specialCharSet,
                passwordLength: length);
            
            Assert.That(password, Has.Length.EqualTo(length));
        }
    }
}