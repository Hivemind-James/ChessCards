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
    public class PieceUnitTests
    {
        Board _board;

        [TestInitialize]
        public void Setup()
        {
            _board = new Board();
            _board.Setup();

        }

        [TestMethod]
        public void CanMoveTo_RookCanMoveToLocations_False()
        {
            Piece selected = _board.Find(Position.A1);

            Assert.IsFalse(selected.CanMoveTo(_board, Position.C8));
        }

        [TestMethod]
        public void CanMoveTo_QueenCanMoveToLocations_False()
        {
            Piece selected = _board.Find(Position.A4);

            Assert.IsFalse(selected.CanMoveTo(_board, Position.C8));
        }

        [TestMethod]
        public void ToString_PiecetoStringEqualsStringOutput_Equal()
        {
            Piece selected = _board.Find(Position.A1);
            string expected = "A1: White Rook\n";
            string actual = selected.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanMoveTo_PawnCanMoveToLocations_True()
        {
            Piece selected = _board.Find(Position.B1);

            Assert.IsFalse(selected.CanMoveTo(_board, Position.B3));
        }


        [TestMethod]
        public void CanMoveTo_NullPieceCanMoveToLocations_False()
        {
            Piece notapiece = new NullPiece();

            Assert.IsFalse(notapiece.CanMoveTo(_board, Position.C8));
        }


                    [TestMethod]
        public void CanMoveTo_KnightCanMoveToLocations_False()
        {
            Piece selected = _board.Find(Position.A3);

            Assert.IsFalse(selected.CanMoveTo(_board, Position.C8));
        }

        [TestMethod]
        public void CanMoveTo_KingCanMoveToLocations_False()
        {
            Piece selected = _board.Find(Position.A5);

            Assert.IsFalse(selected.CanMoveTo(_board, Position.C8));
        }

        [TestMethod]
        public void CanMoveTo_BishopCanMoveToLocations_False()
        {
            Piece selected = _board.Find(Position.A2);

            Assert.IsFalse(selected.CanMoveTo(_board, Position.C8));
        }
    }
}
