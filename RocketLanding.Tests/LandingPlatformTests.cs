using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketLanding;

namespace TestProject1
{
    [TestClass]
    public class LandingPlatformTests
    {
        [TestMethod]
        // Platform on point zero
        [DataRow(3, 0, 0, 0, 0, true)]
        [DataRow(3, 0, 0, 0, 1, true)]
        [DataRow(3, 0, 0, 0, 2, true)]
        [DataRow(3, 0, 0, 1, 0, true)]
        [DataRow(3, 0, 0, 1, 1, true)]
        [DataRow(3, 0, 0, 1, 2, true)]
        [DataRow(3, 0, 0, 2, 0, true)]
        [DataRow(3, 0, 0, 2, 1, true)]
        [DataRow(3, 0, 0, 2, 2, true)]
        [DataRow(3, 0, 0, 3, 0, false)]
        [DataRow(3, 0, 0, 3, 1, false)]
        [DataRow(3, 0, 0, 3, 2, false)]
        [DataRow(3, 0, 0, 3, 3, false)]
        [DataRow(3, 0, 0, 2, 3, false)]
        [DataRow(3, 0, 0, 1, 3, false)]
        [DataRow(3, 0, 0, 0, 3, false)]

        // Platform somewhere in the middle
        [DataRow(3, 4, 4, 5, 5, true)]
        [DataRow(3, 4, 4, 6, 5, true)]
        [DataRow(3, 4, 4, 6, 6, true)]
        [DataRow(3, 4, 4, 5, 6, true)]
        [DataRow(3, 4, 4, 4, 6, true)]
        [DataRow(3, 4, 4, 4, 5, true)]
        [DataRow(3, 4, 4, 4, 4, true)]
        [DataRow(3, 4, 4, 5, 4, true)]
        [DataRow(3, 4, 4, 6, 4, true)]

        [DataRow(3, 4, 4, 7, 5, false)]
        [DataRow(3, 4, 4, 7, 6, false)]
        [DataRow(3, 4, 4, 7, 7, false)]
        [DataRow(3, 4, 4, 6, 7, false)]
        [DataRow(3, 4, 4, 5, 7, false)]
        [DataRow(3, 4, 4, 4, 7, false)]
        [DataRow(3, 4, 4, 3, 7, false)]
        [DataRow(3, 4, 4, 3, 6, false)]
        [DataRow(3, 4, 4, 3, 5, false)]
        [DataRow(3, 4, 4, 3, 4, false)]
        [DataRow(3, 4, 4, 3, 3, false)]
        [DataRow(3, 4, 4, 4, 3, false)]
        [DataRow(3, 4, 4, 5, 3, false)]
        [DataRow(3, 4, 4, 6, 3, false)]
        [DataRow(3, 4, 4, 7, 3, false)]
        [DataRow(3, 4, 4, 7, 4, false)]
        public void IsInside_ScenarioUnderTest_ExpectedResult(
            int platformSize,
            int platformPositionX, int platformPositionY,
            int testX, int testY,
            bool expectedResult)
        {
            // Arrange
            var platformPosition = new Position(platformPositionX, platformPositionY);
            var platform = new LandingPlatform(platformSize, platformPosition);
            var positionUnderTest = new Position(testX, testY);

            // Act
            var result = platform.IsInside(positionUnderTest);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}