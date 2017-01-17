using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class Chess : IChessGame
    {
        // TODO: needs some data type to hold the 8x8 board

        public Piece getPieceAt(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void movePiece(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            throw new NotImplementedException();
        }

        public void putPiece(Piece p, int row, int column)
        {
            throw new NotImplementedException();
        }

        public void setupBoard()
        {
            throw new NotImplementedException();
        }
    }
}
