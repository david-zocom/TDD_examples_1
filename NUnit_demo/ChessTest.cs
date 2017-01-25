using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_examples_1.implementations;
using TDD_examples_1;
using NUnit.Framework;

namespace NUnit_demo
{
    /*void setupBoard();
    Piece getPieceAt(int row, int column);
    void putPiece(Piece p, int row, int column);
    void movePiece(int rowFrom, int columnFrom, int rowTo, int columnTo);
    public class IllegalMoveException : Exception { }
    public class NoPieceAtPositionException : Exception { }
     */

    [TestFixture]
    public class ChessTest
    {
        [Test]
        public void SetupBoard_CorrectPieceAtEveryPosition()
        {
            Chess c = new Chess();
            c.setupBoard();

            TestPieceAtPosition(c.getPieceAt(1, 1), eColor.White, ePiece.Rook);
            TestPieceAtPosition(c.getPieceAt(2, 1), eColor.White, ePiece.Pawn);
            /* Lägg till testfall för alla pjäser som
             * ska ha placerats ut. Använd for-loopar 
             * när det finns mönster som upprepas:
             * det tomma området i mitten av brädet och
             * de två raderna med bönder.
            **/
            for (int row = 3; row <= 6; row++)
                for (int col = 1; col <= 8; col++)
                    TestPieceAtPosition(c.getPieceAt(row, col), ePiece.None);
        }
        private void TestPieceAtPosition(Piece actual, eColor expectedColor,
            ePiece expectedPiece)
        {
            Assert.That(actual.eColor, Is.EqualTo(expectedColor));
            Assert.That(actual.ePiece, Is.EqualTo(expectedPiece));
        }
        private void TestPieceAtPosition(Piece actual, ePiece expectedPiece)
        {
            Assert.That(actual.ePiece, Is.EqualTo(expectedPiece));
        }


        public void GetPieceAt_CoordinatesOutOfBounds() { }
        public void GetPieceAt_CorrectPiece() { }


        //void putPiece(Piece p, int row, int column);
        // Piece kan vara: null eller ett objekt, ePiece.None eller riktig pjäs
        // row och column: möjliga värden är alla int-värden,
        //     tillåtna värden är 1-8
        public void PutPiece_CorrectPieceValidPosition_Success() { }
        public void PutPiece_NullPiece_Fail() { }
        public void PutPiece_PositionOutOfBounds_Fail() { }

        // null
        // objekt med korrekta värden
        // objekt med något felaktigt värde

        // void movePiece(int rowFrom, int columnFrom, int rowTo, int columnTo);
        [TestCase(-5, -7, 1, 1)]
        [TestCase(-3, 4, 1, 1)]
        [TestCase(3, -3, 1, 1)]
        [TestCase(10, 10, 1, 1)]
        public void MovePiece_PositionOutOfBounds_Fail(int r1, int c1, int r2, int c2)
        {
            Chess c = new Chess();
            Assert.That(() => c.movePiece(r1, c1, r2, c2),
                Throws.TypeOf<IndexOutOfRangeException>());
            Assert.That(() => c.movePiece(r2, c2, r1, c1),
                Throws.TypeOf<IndexOutOfRangeException>());

            //Assert.Throws<IndexOutOfRangeException>(
            //    () => c.movePiece(-5, -9, 5, 7), "Ska inte godkänna positionen");
            /*Assert.That(() => c.movePiece(-5, -7, 1, 1),
                Throws.TypeOf<IndexOutOfRangeException>());
            Assert.That(() => c.movePiece(1, 1, -5, -7),
                Throws.TypeOf<IndexOutOfRangeException>());*/
        }
        [Test]
        public void MovePiece_NoPieceToMove()
        {
            Chess c = new Chess();
            int row = 3, col = 4;
            c.putPiece(new Piece { ePiece = ePiece.None }, row, col);
            Assert.That(() => c.movePiece(row, col, row + 1, col),
                Throws.TypeOf<NoPieceAtPositionException>());
        }

        [Test]
        public void MovePiece_SameColorPieceOnDestination()
        {
            Chess c = new Chess();
            c.setupBoard();
            int row = 1, col = 1;
            Assert.That(() => c.movePiece(row, col, row, col + 1),
                Throws.TypeOf<IllegalMoveException>());
        }

        [Test]
        public void MovePiece_PieceInTheWay()
        {
            Chess c = new Chess();
            c.setupBoard();
            int row = 1, col = 1;
            Assert.That(() => c.movePiece(row, col, row + 3, col),
                Throws.TypeOf<IllegalMoveException>());
        }

        [Test]
        public void MovePiece_MoveToSamePosition()
        {
            Chess c = new Chess();
            c.setupBoard();
            int row = 1, col = 4;
            Assert.That(() => c.movePiece(row, col, row, col),
                Throws.TypeOf<IllegalMoveException>());
        }

        [Test]
        public void MovePiece_Rook_IncorrectMove()
        {
            Chess c = new Chess();
            c.setupBoard();
            int row = 5, col = 4;
            c.putPiece(new Piece() { ePiece = ePiece.Rook, eColor = eColor.Black },
                row, col);
            Assert.That(() => c.movePiece(row, col, row - 1, col + 1),
                Throws.TypeOf<IllegalMoveException>());
        }
        [Test]
        public void MovePiece_Rook_CorrectMove()
        {
            Chess c = new Chess();
            c.setupBoard();
            int row = 5, col = 4;
            c.putPiece(new Piece() { ePiece = ePiece.Rook, eColor = eColor.Black },
                row, col);
            c.movePiece(row, col, row, 8);

            ePiece ep = c.getPieceAt(row, col).ePiece;
            Assert.That(ep, Is.EqualTo(ePiece.None));
            Piece p = c.getPieceAt(row, 8);
            Assert.That(p.ePiece, Is.EqualTo(ePiece.Rook));
            Assert.That(p.eColor, Is.EqualTo(eColor.Black));

            // todo: move left, move up, move down
        }

        [Test]
        public void MovePiece_Pawn_IncorrectMove()
        {
            Chess c = new Chess();
            c.setupBoard();
            int row = 5, col = 4;
            c.putPiece(new Piece() { ePiece = ePiece.Pawn, eColor = eColor.Black },
                    row, col);
            Assert.That(() => c.movePiece(row, col, row, col + 1),
                Throws.TypeOf<IllegalMoveException>());
            // todo: återstående felaktiga drag, t.ex.
            // gå bakåt, gå snett om det inte finns en pjäs att slå...
        }
        [TestCase()]
        public void MovePiece_Pawn_CorrectMove()
        {
            // 2 steg framåt om på startpositionen
            // 1 steg framåt annars
            // slå en pjäs i sidled framåt
        }
    }
}
