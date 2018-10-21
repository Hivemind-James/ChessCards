using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyGame
{ 
    [TestClass]
    public class PieceTests_NotUnitTests
    { 
        Board _board;

        [TestInitialize]
        public void Setup()
        {
           _board = new Board();
        }

        [TestMethod]
        public void MoveOnSelf()
        {
            //tests all pieces to see if they can move on them selves
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.D5);
        }

        [TestMethod]
        public void PawnMovement()
        {
            //Pawn Move (1 square) up
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.D5);
            //Pawn Move (2 squares) up first move
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F5));
            _board.Remove(Position.D5);

        }

        [TestMethod]
        public void KingMovement()
        {
            //These tests are all possible movements for a king to move
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C5));
            _board.Remove(Position.D5);
            //These tests are some tests to see if the King can perform an illegal movement
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A1));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A2));
            _board.Remove(Position.D5);
        }

        [TestMethod]
        public void KnightMovement()
        {
            //These tests are all possible movements for a Kinight to move
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B6));
            _board.Remove(Position.D5);
            //These tests are some tests to see if the Knight can perform an illegal movement
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A1));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A2));
            _board.Remove(Position.D5);

        }

        [TestMethod]
        public void BishopMovement()
        {
            //These tests are all possible movements for a Bishop to move
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.D5); 
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G2));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H1));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A2));
            _board.Remove(Position.D5);
            //These tests are some tests to see if the bishop can perform an illegal movement
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A5));
            _board.Remove(Position.D5);
        }

        [TestMethod]
        public void RookMovement()
        {
            //These tests are all possible movements for a Rook to move
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D8));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D2));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D5);
            //These tests are some tests to see if the rook can perform an illegal movement
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A1));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.B1));
            _board.Remove(Position.D5);
        }

        [TestMethod]
        public void QueenMovement()
        {
            //These tests are all possible movements for a Queen to move
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H5));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D8));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D2));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A2));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.B7));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E4));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.F3));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G2));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.H1));
            _board.Remove(Position.D5);
            //These tests are some tests to see if the Queen can perform an illegal movement
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A1));
            _board.Remove(Position.D5);
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.B1));
            _board.Remove(Position.D5);
        }

        [TestMethod]
        public void WhiteRookAttack()
        {
            //these tests are for white rooks to attack all black pieces and white pieces
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.White));
            _board.Add(Position.D1, new Rook(Position.D1, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Pawn(Position.D1, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Knight(Position.D1, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Bishop(Position.D1, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new King(Position.D1, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Queen(Position.D1, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Rook(Position.D1, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Knight(Position.D1, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Pawn(Position.D1, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Bishop(Position.D1, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new King(Position.D1, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Queen(Position.D1, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
        }


        [TestMethod]
        public void WhitePawnAttack()
        {
            //these tests are for white pawns to attack all black pieces and white pieces
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.White));
            _board.Add(Position.E6, new Pawn(Position.E6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            Assert.IsTrue(_board.Find(Position.E6).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Rook(Position.E6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Knight(Position.E6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Bishop(Position.E6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new King(Position.E6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Queen(Position.E6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Rook(Position.E6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Knight(Position.E6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Pawn(Position.E6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Bishop(Position.E6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new King(Position.E6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
            _board.Add(Position.E6, new Queen(Position.E6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E6));
            _board.Remove(Position.E6);
        }

        [TestMethod]
        public void WhiteKnightAttack()
        {
            //these tests are for white Knight's to attack all black pieces and white pieces
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.White));
            _board.Add(Position.E7, new Knight(Position.E7, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Pawn(Position.E7, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Rook(Position.E7, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Bishop(Position.E7, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new King(Position.E7, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Queen(Position.E7, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Rook(Position.E7, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Knight(Position.E7, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Pawn(Position.E7, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Bishop(Position.E7, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new King(Position.E7, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Queen(Position.E7, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
        }

        [TestMethod]
        public void WhiteBishopAttack()
        {
            //these tests are for white NBishops to attack all black pieces and white pieces
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.White));
            _board.Add(Position.G8, new Bishop(Position.G8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.D8, new Pawn(Position.D8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Rook(Position.G8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Knight(Position.G8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new King(Position.G8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Queen(Position.G8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Rook(Position.G8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Knight(Position.G8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Pawn(Position.G8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Bishop(Position.G8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new King(Position.G8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Queen(Position.G8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
        }


        [TestMethod]
        public void WhiteKingAttack()
        {
            //these tests are for white King's to attack all black pieces and white pieces
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.White));
            _board.Add(Position.D6, new King(Position.D6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D8, new Pawn(Position.D8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Rook(Position.D6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Knight(Position.D6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Bishop(Position.D6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Queen(Position.D6, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Rook(Position.D6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Knight(Position.D6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Pawn(Position.D6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Bishop(Position.D6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new King(Position.D6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Queen(Position.D6, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
        }

        [TestMethod]
        public void WhiteQueenAttack()
        {
            //these tests are for white Queens to attack all black pieces and white pieces
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.White));
            _board.Add(Position.A8, new Queen(Position.A8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.D8, new Pawn(Position.D8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Rook(Position.A8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Knight(Position.A8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Bishop(Position.A8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Queen(Position.A8, PlayerColour.Black));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Rook(Position.A8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Knight(Position.A8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Pawn(Position.A8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Bishop(Position.A8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new King(Position.A8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Queen(Position.A8, PlayerColour.White));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
        }


        [TestMethod]
        public void BlackRookAttack()
        {
            //these tests are for Black Rooks pawns to attack all black pieces and white pieces
            _board.Add(Position.D5, new Rook(Position.D5, PlayerColour.Black));
            _board.Add(Position.D1, new Rook(Position.D1, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Pawn(Position.D1, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Knight(Position.D1, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Bishop(Position.D1, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new King(Position.D1, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Queen(Position.D1, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Rook(Position.D1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Knight(Position.D1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Pawn(Position.D1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Bishop(Position.D1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new King(Position.D1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
            _board.Add(Position.D1, new Queen(Position.D1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D1));
            _board.Remove(Position.D1);
        }


        [TestMethod]
        public void BlackPawnAttack()
        {
            //these tests are for Black Pawns pawns to attack all black pieces and white pieces
            _board.Add(Position.D5, new Pawn(Position.D5, PlayerColour.Black));
            _board.Add(Position.C6, new Pawn(Position.C6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            Assert.IsTrue(_board.Find(Position.C6).CanMoveTo(_board, Position.D5));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Rook(Position.C6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Knight(Position.C6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Bishop(Position.C6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new King(Position.C6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Queen(Position.C6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Rook(Position.C6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Knight(Position.C6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Pawn(Position.C6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Bishop(Position.C6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new King(Position.C6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
            _board.Add(Position.C6, new Queen(Position.C6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.C6));
            _board.Remove(Position.C6);
        }

        [TestMethod]
        public void BlackKnightAttack()
        {
            //these tests are for Black Knights pawns to attack all black pieces and white pieces
            _board.Add(Position.D5, new Knight(Position.D5, PlayerColour.Black));
            _board.Add(Position.E7, new Knight(Position.E7, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Pawn(Position.E7, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Rook(Position.E7, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Bishop(Position.E7, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new King(Position.E7, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Queen(Position.E7, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Rook(Position.E7, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Knight(Position.E7, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Pawn(Position.E7, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Bishop(Position.E7, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new King(Position.E7, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
            _board.Add(Position.E7, new Queen(Position.E7, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.E7));
            _board.Remove(Position.E7);
        }

        [TestMethod]
        public void BlackBishopAttack()
        {
            //these tests are for Black Bishops pawns to attack all black pieces and white pieces
            _board.Add(Position.D5, new Bishop(Position.D5, PlayerColour.Black));
            _board.Add(Position.G8, new Bishop(Position.G8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.D8, new Pawn(Position.D8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Rook(Position.G8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Knight(Position.G8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new King(Position.G8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Queen(Position.G8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Rook(Position.G8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Knight(Position.G8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Pawn(Position.G8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Bishop(Position.G8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new King(Position.G8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
            _board.Add(Position.G8, new Queen(Position.G8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.G8));
            _board.Remove(Position.G8);
        }


        [TestMethod]
        public void BlackKingAttack()
        {
            //these tests are for Black Kings pawns to attack all black pieces and white pieces
            _board.Add(Position.D5, new King(Position.D5, PlayerColour.Black));
            _board.Add(Position.D6, new King(Position.D6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D8, new Pawn(Position.D8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Rook(Position.D6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Knight(Position.D6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Bishop(Position.D6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Queen(Position.D6, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Rook(Position.D6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Knight(Position.D6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Pawn(Position.D6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Bishop(Position.D6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new King(Position.D6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
            _board.Add(Position.D6, new Queen(Position.D6, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.D6));
            _board.Remove(Position.D6);
        }

        [TestMethod]
        public void BlackQueenAttack()
        {
            //these tests are for Black Queens pawns to attack all black pieces and white pieces
            _board.Add(Position.D5, new Queen(Position.D5, PlayerColour.Black));
            _board.Add(Position.A8, new Queen(Position.A8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.D8, new Pawn(Position.D8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Rook(Position.A8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Knight(Position.A8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Bishop(Position.A8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Queen(Position.A8, PlayerColour.White));
            Assert.IsTrue(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Rook(Position.A8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Knight(Position.A8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Pawn(Position.A8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Bishop(Position.A8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new King(Position.A8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
            _board.Add(Position.A8, new Queen(Position.A8, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.D5).CanMoveTo(_board, Position.A8));
            _board.Remove(Position.A8);
        }

        [TestMethod]
        public void CantHitMoreThanOneEnemy()
        {
            //these tests are for Black Rooks pawns to attack all black pieces and white pieces
            _board.Add(Position.A3, new Bishop(Position.A3, PlayerColour.White));
            _board.Add(Position.B2, new Pawn(Position.B2, PlayerColour.Black));
            _board.Add(Position.C1, new Pawn(Position.C1, PlayerColour.Black));
            Assert.IsFalse(_board.Find(Position.A3).CanMoveTo(_board, Position.C1));
        }
    }
}
