using Leowen.Business.Triangle;
using NUnit.Framework;
using Shouldly;

namespace Leowen.Business.UnitTests
{
    [TestFixture]
    public class EdgeServiceTest
    {
        private IEdgeService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new EdgeService();
        }

        [TestCase(2, 3, 4, false)]
        [TestCase(10, 10, 5, false)]
        [TestCase(1, 1, 1, true)]
        public void When_call_AllEdgesSame_Should_return_boolean(int edgeA, int edgeB, int edgeC, bool expected)
        {
            _sut.AllEdgesSame(edgeA, edgeB, edgeC).ShouldBe(expected);
        }

        [TestCase(2, 3, 4, false)]
        [TestCase(10, 10, 5, true)]
        [TestCase(1, 1, 1, true)]
        public void When_call_AtLeastTwoEdagesSame_Should_return_boolean(int edgeA, int edgeB, int edgeC, bool expected)
        {
            _sut.AtLeastTwoEdagesSame(edgeA, edgeB, edgeC).ShouldBe(expected);
        }

        [TestCase(2, 3, 5, false)]
        [TestCase(2, 3, 4, true)]
        [TestCase(10, 10, 5, true)]
        [TestCase(1, 1, 1, true)]
        public void When_call_NoEdgeLongerThanSumOfOthers_Should_return_boolean(int edgeA, int edgeB, int edgeC, bool expected)
        {
            _sut.EdgeLongerThanSumOfOthers(edgeA, edgeB, edgeC).ShouldBe(expected);
        }

        [TestCase(-2, -3, -2, true)]
        [TestCase(-2, 3, -2, true)]
        [TestCase(-2, 3, 2, true)]
        [TestCase(2, 3, 5, false)]
        [TestCase(2, 3, 4, false)]
        [TestCase(10, 10, 5, false)]
        [TestCase(1, 1, 1, false)]
        public void When_call_InvalidEdges_Should_return_boolean(int edgeA, int edgeB, int edgeC, bool expected)
        {
            _sut.InvalidEdges(edgeA, edgeB, edgeC).ShouldBe(expected);
        }
    }
}
