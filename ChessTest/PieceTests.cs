﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyGame
{
    [TestClass]
    public class PieceTests
    {
        Board _board;

        [TestInitialize]
        public void Setup()
        {
            _board = new Board();
        }

        [TestMethod]
        public void TestBlockedPawn()
        {
            _board.Add(Position.A1, new Pawn(Position.A1, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.A1).CanMoveTo(_board, Position.B1));
            _board.Add(Position.B1, new Pawn(Position.B1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.A1).CanMoveTo(_board, Position.B1));
        }

        [TestMethod]
        public void TestPawnAttack()
        {
            _board.Add(Position.A1, new Pawn(Position.A1, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.A1).CanMoveTo(_board, Position.B2));
            _board.Add(Position.B2, new Pawn(Position.B2, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.A1).CanMoveTo(_board, Position.B2));
        }
    }
}