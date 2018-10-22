using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace MyGame
{
    [TestClass]
    public class HelperFunctionUnitTests
    {
        [TestMethod]
        public void GetRelativePositions()
        {
            List<int> output;
            List<int> expected = new List<int>();
            output = HelperFunctions.GetRelativePosition(Position.A5, Position.B2);
            expected.Add(1);
            expected.Add(2);

            Assert.ReferenceEquals(output, expected);
        }

        [TestMethod]
        public void GetNewPosition()
        {
            List<int> deltaP;
            Position output;
            deltaP = HelperFunctions.GetRelativePosition(Position.A1, Position.A2);
            output = HelperFunctions.GetNewPosition(Position.A1, deltaP);

            Assert.AreEqual(output, Position.A2);
        }

        [TestMethod]
        public void GetAbsPosition()
        {
            List<int> deltaP = new List<int>();
            List<int> output;
            deltaP.Add(0);
            deltaP.Add(0);

            output = HelperFunctions.GetAbsPos(Position.A1);

            Assert.ReferenceEquals(output, deltaP);
        }

        [TestMethod]
        public void GetOpponent()
        {
            PlayerColour expected;
            expected = PlayerColour.Black;

            Assert.AreEqual(PlayerColour.White, HelperFunctions.GetOpponent(expected));
        }

        [TestMethod]
        public void Setup()
        {
            Piece expected = new Pawn(Position.B1, PlayerColour.White);

            Assert.ReferenceEquals(expected, HelperFunctions.Setup(8));
        }
    }
}
