using Leowen.Business.Triangle;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Leowen.Business.UnitTests
{
    [TestFixture]
    public class TriangleServiceTest
    {
        private Mock<IEdgeService> _edageService;
        private ITriangleService _sut;

        [SetUp]
        public void Setup()
        {
            _edageService = new Mock<IEdgeService>();
            _sut = new TriangleService(_edageService.Object);
        }

        [TestCase(true, true, true, true, "Error")]
        [TestCase(false, true, true, false, "Error")]
        [TestCase(false, true, false, true, "Equilateral")]
        [TestCase(false, true, true, true, "Equilateral")]
        [TestCase(false, false, true, true, "Isosceles")]
        [TestCase(false, false, false, true, "Scalene")]
        public void When_call_GeTriangleType_Should_return_TriangleType(bool hasInvalidEdge,
            bool allEdgesSame, bool atLeastTwoEdgesSame,
            bool edgeLongerThanOtherSum, string expected)
        {
            var edgeA = 1;
            var edgeB = 1;
            var edgeC = 1;
            _edageService.Setup(c => c.InvalidEdges(edgeA, edgeB, edgeC)).Returns(hasInvalidEdge);
            _edageService.Setup(c => c.AllEdgesSame(edgeA, edgeB, edgeC)).Returns(allEdgesSame);
            _edageService.Setup(c => c.AtLeastTwoEdagesSame(edgeA, edgeB, edgeC)).Returns(atLeastTwoEdgesSame);
            _edageService.Setup(c => c.EdgeLongerThanSumOfOthers(edgeA, edgeB, edgeC)).Returns(edgeLongerThanOtherSum);
            _sut.GetTriangleType(edgeA, edgeB, edgeC).Name.ShouldBe(expected);

        }
    }
}
