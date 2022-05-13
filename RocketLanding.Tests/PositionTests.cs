using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketLanding;

namespace TestProject1
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        // Target on point zero
        [DataRow(0, 0, 0, 0, true)]
        [DataRow(0, 0, 1, 0, true)]
        [DataRow(0, 0, 0, 1, true)]
        [DataRow(0, 0, 1, 1, true)]
        [DataRow(0, 0, 2, 0, false)]
        [DataRow(0, 0, 2, 1, false)]
        [DataRow(0, 0, 2, 2, false)]
        [DataRow(0, 0, 0, 2, false)]
        [DataRow(0, 0, 1, 2, false)]
        [DataRow(0, 0, 2, 2, false)]

        // Target on top edge
        [DataRow(5, 0, 5, 0, true)]
        [DataRow(5, 0, 4, 0, true)]
        [DataRow(5, 0, 6, 0, true)]
        [DataRow(5, 0, 4, 1, true)]
        [DataRow(5, 0, 5, 1, true)]
        [DataRow(5, 0, 6, 1, true)]

        // Target on left edge
        [DataRow(0, 5, 0, 5, true)]
        [DataRow(0, 5, 0, 4, true)]
        [DataRow(0, 5, 0, 6, true)]
        [DataRow(0, 5, 1, 4, true)]
        [DataRow(0, 5, 1, 5, true)]
        [DataRow(0, 5, 1, 6, true)]

        // Target inside area
        [DataRow(5, 5, 5, 5, true)]
        [DataRow(5, 5, 4, 4, true)]
        [DataRow(5, 5, 4, 5, true)]
        [DataRow(5, 5, 5, 4, true)]
        [DataRow(5, 5, 6, 5, true)]
        [DataRow(5, 5, 5, 6, true)]
        [DataRow(5, 5, 6, 6, true)]
        [DataRow(5, 5, 7, 7, false)]
        [DataRow(5, 5, 7, 5, false)]
        [DataRow(5, 5, 5, 7, false)]
        [DataRow(5, 5, 3, 3, false)]
        [DataRow(5, 5, 3, 5, false)]
        [DataRow(5, 5, 5, 3, false)]
        public void IsAdjacentTo_ScenarioUnderTest_ExpectedResult(
            int targetX, int targetY,
            int testX, int testY, 
            bool expectedResult)
        {
            // Arrange
            var targetPosition = new Position(targetX, targetY);
            var positionUnderTest = new Position(testX, testY);

            // Act
            var result = positionUnderTest.IsAdjacentTo(targetPosition);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}