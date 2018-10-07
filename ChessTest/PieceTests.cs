﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyGame
{
    [TestClass]
    public class PieceTests
    {
        Board _board;
        Game _game;

        [TestInitialize]
        public void Setup()
        {
            _board = new Board();
            _game = new Game();
        }

        [TestMethod]
        public void PawnMovement()
        {
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.D5);

            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F5));    
            _board.Remove(Position.D5);
        }

        [TestMethod]
        public void PawnAttack()
        {
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            _board.Add(Position.E6, new Pawn(Position.E6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            Assert.IsTrue(_board.Find(Position.E6).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.E6);



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
