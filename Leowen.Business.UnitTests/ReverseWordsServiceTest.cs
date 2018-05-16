using Leowen.Business.ReverseWords;
using NUnit.Framework;
using Shouldly;

namespace Leowen.Business.UnitTests
{
    [TestFixture]
    public class ReverseWordsServiceTest
    {
        private IReverseWordsService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new ReverseWordsService();
        }

        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("123", "321")]
        [TestCase("asd 123 poi", "dsa 321 iop")]
        [TestCase("m", "m")]
        [TestCase("1234           ddd0", "4321           0ddd")]
        public void When_Reverse_called_Should_reverse_words(string words, string expected)
        {
            _sut.Reverse(words).ShouldBe(expected);
        }
    }
}
