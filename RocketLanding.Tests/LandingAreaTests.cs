using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketLanding;

namespace TestProject1
{
    [TestClass]
    public class LandingAreaTests
    {
        [TestMethod]
        public void QueryPosition_DesiredPositionInsidePlatform_ReturnsOkay()
        {
            // Arrange
            var platformPosition = new Position(5, 5);
            var landingArea = new LandingArea(100, 10, platformPosition);
            var positionToTest = new Position(5, 5);

            // Act
            var result = landingArea.QueryPosition(positionToTest);

            // Assert
            Assert.AreEqual(LandingQueryResult.Okay, result);
        }

        [TestMethod]
        [DataRow(15, 10)]
        [DataRow(15, 15)]
        [DataRow(10, 15)]
        [DataRow(4, 15)]
        [DataRow(4, 9)]
        [DataRow(4, 4)]
        [DataRow(9, 4)]
        [DataRow(15, 4)]
        public void QueryPosition_DesiredPositionOutsidePlatform_ReturnsOutOfPlatform(
            int positionToTestX, int positionToTestY)
        {
            // Arrange
            var platformPosition = new Position(5, 5);
            var landingArea = new LandingArea(100, 10, platformPosition);
            var positionToTest = new Position(positionToTestX, positionToTestY);

            // Act
            var result = landingArea.QueryPosition(positionToTest);

            // Assert
            Assert.AreEqual(LandingQueryResult.OutOfPlatform, result);
        }

        [TestMethod]
        public void QueryPosition_DesiredPositionQueriedPreviously_ReturnsClash()
        {
            // Arrange
            var platformPosition = new Position(5, 5);
            var landingArea = new LandingArea(100, 10, platformPosition);
            var positionToTest = new Position(10, 10);
            landingArea.QueryPosition(positionToTest);

            // Act
            var result = landingArea.QueryPosition(positionToTest);

            // Assert
            Assert.AreEqual(LandingQueryResult.Clash, result);
        }

        [TestMethod]
        [DataRow(11, 10)]
        [DataRow(11, 11)]
        [DataRow(10, 11)]
        [DataRow(9, 11)]
        [DataRow(9, 10)]
        [DataRow(9, 9)]
        [DataRow(10, 9)]
        [DataRow(11, 9)]
        public void QueryPosition_DesiredPositionNextToPreviousQuery_ReturnsClash(
            int positionToTestX, int positionToTestY)
        {
            // Arrange
            var platformPosition = new Position(5, 5);
            var landingArea = new LandingArea(100, 10, platformPosition);
            landingArea.QueryPosition(new Position(10, 10));

            var positionToTest = new Position(positionToTestX, positionToTestY);

            // Act
            var result = landingArea.QueryPosition(positionToTest);

            // Assert
            Assert.AreEqual(LandingQueryResult.Clash, result);
        }

        [TestMethod]
        [DataRow(12, 10)]
        [DataRow(12, 11)]
        [DataRow(12, 12)]
        [DataRow(11, 12)]
        [DataRow(10, 12)]
        [DataRow(9, 12)]
        [DataRow(8, 12)]
        [DataRow(8, 10)]
        [DataRow(8, 9)]
        [DataRow(8, 8)]
        [DataRow(9, 8)]
        [DataRow(10, 8)]
        [DataRow(11, 8)]
        [DataRow(12, 8)]
        [DataRow(12, 9)]
        public void QueryPosition_DesiredPositionFarFromPreviousQuery_ReturnsOkay(
            int positionToTestX, int positionToTestY)
        {
            // Arrange
            var platformPosition = new Position(5, 5);
            var landingArea = new LandingArea(100, 10, platformPosition);
            landingArea.QueryPosition(new Position(10, 10));

            var positionToTest = new Position(positionToTestX, positionToTestY);

            // Act
            var result = landingArea.QueryPosition(positionToTest);

            // Assert
            Assert.AreEqual(LandingQueryResult.Okay, result);
        }
    }
}