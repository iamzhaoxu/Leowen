using Leowen.Business.Fibonacci;
using Leowen.Core.ErrorHandling;
using NUnit.Framework;
using Shouldly;

namespace Leowen.Business.UnitTests
{
    [TestFixture]
    public class FibonacciServiceTest
    {
        private IFibonacciService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new FibonacciService();
        }

        [TestCase(-92, -7540113804746346429)]
        [TestCase(-5, 5)]
        [TestCase(-4, -3)]
        [TestCase(-3, 2)]
        [TestCase(-2, -1)]
        [TestCase(-1, 1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        [TestCase(7, 13)]
        [TestCase(12, 144)]
        [TestCase(92, 7540113804746346429)]
        public void When_call_GetNthFibonacciNumber_Given_nth_is_positive_number_Should_return_nth_FibonacciNumber(long nth, long expected)
        {
            _sut.GetNthFibonacciNumber(nth).ShouldBe(expected);
        }


        [TestCase(-94)]
        [TestCase(-93)]
        [TestCase(93)]
        [TestCase(94)]
        public void When_call_GetNthFibonacciNumber_Given_nth_out_of_ranage_Should_throw_out_of_range_exception(long nth)
        {
            Should.Throw<AppException>(() => _sut.GetNthFibonacciNumber(nth))
                .EventId.ShouldBe((int)EventCode.FibonacciBadRequest);
        }
    }
}
