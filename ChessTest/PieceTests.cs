using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyGame
{
    [TestClass]
    public class PieceTests_NotUnitTests
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
        public void PawnMovement_Week8()
        {
            //Pawn Move (1 square)
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.D5);
            //Pawn Move (2 squares) first move
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F5));
            _board.Remove(Position.D5);

        }

        [TestMethod]
        public void KingMovement_Week9()
        {
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D4));
            _board.Remove(Position.D4);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C4));
            _board.Remove(Position.C4);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E4));
            _board.Remove(Position.E4);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.E5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C5));
            _board.Remove(Position.C5);
        }

        [TestMethod]
        public void KnightMovement_Week9()
        {
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C7));
            _board.Remove(Position.C7);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F6));
            _board.Remove(Position.F6);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F4));
            _board.Remove(Position.F4);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C3));
            _board.Remove(Position.C3);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E3));
            _board.Remove(Position.E3);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B4));
            _board.Remove(Position.B4);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B6));
            _board.Remove(Position.B6);
        }

        [TestMethod]
        public void BishopMovement_Week9()
        {
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B7));
            _board.Remove(Position.B7);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F7));
            _board.Remove(Position.F7);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E4));
            _board.Remove(Position.E4);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F3));
            _board.Remove(Position.F3);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G2));
            _board.Remove(Position.G2);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H1));
            _board.Remove(Position.H1);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C4));
            _board.Remove(Position.C4);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B3));
            _board.Remove(Position.B3);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A2));
            _board.Remove(Position.A2);
        }

        [TestMethod]
        public void RookMovement_Week9()
        {
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C5));
            _board.Remove(Position.C5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B5));
            _board.Remove(Position.B5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A5));
            _board.Remove(Position.A5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.E5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F5));
            _board.Remove(Position.F5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G5));
            _board.Remove(Position.G5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H5));
            _board.Remove(Position.H5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D7));
            _board.Remove(Position.D7);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D8));
            _board.Remove(Position.D8);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D4));
            _board.Remove(Position.D4);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D3));
            _board.Remove(Position.D3);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D2));
            _board.Remove(Position.D2);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
        }

        [TestMethod]
        public void QueenMovement_Week9()
        {
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C5));
            _board.Remove(Position.C5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B5));
            _board.Remove(Position.B5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A5));
            _board.Remove(Position.A5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.E5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F5));
            _board.Remove(Position.F5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G5));
            _board.Remove(Position.G5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H5));
            _board.Remove(Position.H5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D7));
            _board.Remove(Position.D7);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D8));
            _board.Remove(Position.D8);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D4));
            _board.Remove(Position.D4);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D3));
            _board.Remove(Position.D3);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D2));
            _board.Remove(Position.D2);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C4));
            _board.Remove(Position.C4);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B3));
            _board.Remove(Position.B3);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A2));
            _board.Remove(Position.A2);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F7));
            _board.Remove(Position.F7);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B7));
            _board.Remove(Position.B7);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E4));
            _board.Remove(Position.E4);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F3));
            _board.Remove(Position.F3);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G2));
            _board.Remove(Position.G2);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H1));
            _board.Remove(Position.H1);
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
        public void CantHitMoreThanOneEnemy()
        {
            _board.Add(Position.A3, new Bishop(Position.A3, PlayerColour.White));
            _board.Add(Position.B2, new Pawn(Position.B2, PlayerColour.Black));
            _board.Add(Position.C1, new Pawn(Position.C1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.A3).CanMoveTo(_board, Position.C1));
        }
    }
}
