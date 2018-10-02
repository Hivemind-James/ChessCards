using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyGame
{
    [TestClass]
    public class BoardTest
    {
        Board _board;

        [TestInitialize]
        public void Setup()
        {
            _board = new Board();
            _board.Setup();
        }
        [TestMethod]
        public void TestSetup()
        {
            string expected =   "A1: White Rook\n" +
                                "A2: White Knight\n" +
                                "A3: White Bishop\n" +
                                "A4: White Queen\n" +
                                "A5: White King\n" +
                                "A6: White Bishop\n" +
                                "A7: White Knight\n" +
                                "A8: White Rook\n" +
                                "B1: White Pawn\n" +
                                "B2: White Pawn\n" +
                                "B3: White Pawn\n" +
                                "B4: White Pawn\n" +
                                "B5: White Pawn\n" +
                                "B6: White Pawn\n" +
                                "B7: White Pawn\n" +
                                "B8: White Pawn\n" +
                                "G1: Black Pawn\n" +
                                "G2: Black Pawn\n" +
                                "G3: Black Pawn\n" +
                                "G4: Black Pawn\n" +
                                "G5: Black Pawn\n" +
                                "G6: Black Pawn\n" +
                                "G7: Black Pawn\n" +
                                "G8: Black Pawn\n" +
                                "H1: Black Rook\n" +
                                "H2: Black Knight\n" +
                                "H3: Black Bishop\n" +
                                "H4: Black Queen\n" +
                                "H5: Black King\n" +
                                "H6: Black Bishop\n" +
                                "H7: Black Knight\n" +
                                "H8: Black Rook\n";
            string actual = _board.CurrentBoardState();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEmptyCell()
        {
            Assert.IsNull(_board.Find(Position.C1));
        }

        [TestMethod]
        public void TestFullCell()
        {
            string expected = "A1: White Rook\n";
            string actual = _board.Find(Position.A1).ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
