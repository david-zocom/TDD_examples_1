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
        private Piece[,] board = new Piece[8, 8];

        public Piece getPieceAt(int row, int column)
        {
            return board[row - 1, column - 1];
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
            for (int row = 0; row < 8; row++)
                for (int col = 0; col < 8; col++)
                    board[row, col] = new Piece()
                    {
                        ePiece = ePiece.None,
                        eColor = eColor.White
                    };
        }
    }
}
