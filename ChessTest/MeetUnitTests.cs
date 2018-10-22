using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MyGame
{
    [TestClass]
    public class MeetUnitTest
    {
        Board _board;

        [TestInitialize]
        public void Setup()
        {
            _board = new Board();
        }
        [TestMethod]
        public void AddPieceTest()
        {
            _board.Add(Position.H5, new Pawn(Position.H5, PlayerColour.Black));
            string expected = "H5: Black Pawn\n";
            string actual = _board.Find(Position.H5).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemovePieceTest()
        {
            _board.Add(Position.H5, new King(Position.H5, PlayerColour.Black));
            _board.Remove(Position.H5);
            string expected = "NotAPosition: NoOwner NullPiece\n";
            string actual = _board.Find(Position.H5).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CurrentStateTest()
        {
            _board.Add(Position.H5, new King(Position.H5, PlayerColour.Black));
            _board.Add(Position.H6, new Pawn(Position.H6, PlayerColour.Black));
            _board.Add(Position.A5, new Queen(Position.A5, PlayerColour.White));
            string expected = "H5: Black King\nH6: Black Pawn\nA5: White Queen\n";
            string actual = _board.CurrentBoardState();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindPositionTest()
        {
            _board.Add(Position.H5, new King(Position.H5, PlayerColour.Black));
            string expected = "H5: Black King\n";
            string actual = _board.Find(Position.H5).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindPositionPieceTest()
        {
            _board.Add(Position.H5, new King(Position.H5, PlayerColour.Black));
            string expected = "H5: Black King\n";
            string actual = _board.Find(Kind.King, PlayerColour.Black).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindListPieceTest()
        {
            _board.Add(Position.H5, new King(Position.H5, PlayerColour.Black));
            _board.Add(Position.H8, new Rook(Position.H8, PlayerColour.White));
            string actual = _board.FindList(Kind.King, PlayerColour.Black)[0].ToString();
            string expected = "H5: Black King\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContainsTest()
        {
            _board.Add(Position.H5, new King(Position.H5, PlayerColour.Black));
            
            bool actual = _board.Contains(Kind.King, PlayerColour.Black);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsClearTest()
        {
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.Black));
            
            bool actual = _board.IsClear(Position.C5, Position.H5);
            Assert.IsTrue(actual);
            _board.Remove(Position.D5);
            bool actual1 = _board.IsClear(Position.C5, Position.H5);
            Assert.IsNotNull(actual1);
        }

        [TestMethod]
        public void CountKindPLayerColourTest()
        {
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.Black));
            _board.Add(Position.A1, new King(Position.A1, PlayerColour.White));
            _board.Add(Position.C5, new Pawn(Position.C5, PlayerColour.Black));
            _board.Add(Position.F5, new Pawn(Position.F5, PlayerColour.White));
            _board.Add(Position.H8, new Queen(Position.H8, PlayerColour.Black));
            _board.Add(Position.G5, new Pawn(Position.G5, PlayerColour.Black));

            int expected = 2;
            int actual = _board.Count(Kind.Pawn, PlayerColour.Black);
            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void CountKindTest()
        {
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.Black));
            _board.Add(Position.A1, new King(Position.A1, PlayerColour.White));
            _board.Add(Position.C5, new Pawn(Position.C5, PlayerColour.Black));
            _board.Add(Position.F5, new Pawn(Position.F5, PlayerColour.White));
            _board.Add(Position.H8, new Queen(Position.H8, PlayerColour.Black));
            _board.Add(Position.G5, new Pawn(Position.G5, PlayerColour.Black));

            int expected = 3;
            int actual = _board.Count(Kind.Pawn);
            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void CountPlayerColourTest()
        {
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.Black));
            _board.Add(Position.A1, new King(Position.A1, PlayerColour.White));
            _board.Add(Position.C5, new Pawn(Position.C5, PlayerColour.Black));
            _board.Add(Position.F5, new Pawn(Position.F5, PlayerColour.White));
            _board.Add(Position.H8, new Queen(Position.H8, PlayerColour.Black));
            _board.Add(Position.G5, new Pawn(Position.G5, PlayerColour.Black));

            int expected = 2;
            int actual = _board.Count(PlayerColour.White);
            Assert.IsTrue(expected == actual);
        }
    }
}
