using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        private Player player1;
        private Player player2;

        string[][] boardMatrix;

        public Board()
        {
            boardMatrix = new string[3][];
            for (int i = 0; i < boardMatrix.Length; i++)
                boardMatrix[i] = new string[3];
        }

        public bool Move(Player p, int row, int col)
        {
            if (row < 0 || row > 3 || col < 0 || col > 3)
                throw new ArgumentException("row or column index is out of bound");
            boardMatrix[row][col] = p.Character;
            return IsBoardGameOver(p, row, col);
        }

        public bool IsBoardGameOver(Player p, int row, int col)
        {
            //check rows
            bool rowWinner = true;
            for (int i = 0; i < boardMatrix.Length; i++)
            {
                if (boardMatrix[row][i] == null || boardMatrix[row][i] != p.Character)
                {
                    rowWinner = false;
                }
            }
            //check columns
            bool colWinner = true;
            for (int i = 0; i < boardMatrix.Length; i++)
            {
                if (boardMatrix[i][col] == null || boardMatrix[i][col] != p.Character)
                    colWinner = false;
            }
            //check diagonals
            bool diagWinnerRight_Left = false;
            bool diagWinnerLeft_Right = false;
            if (row == col)
            {
                row = 0;
                col = boardMatrix.Length - 1;
                diagWinnerRight_Left = true;
                diagWinnerLeft_Right = true;
                for (int i = 0; i < boardMatrix.Length; i++)
                {
                    if (boardMatrix[i][row] == null || boardMatrix[i][row] != p.Character)
                        diagWinnerLeft_Right = false;
                    row++;
                    if (boardMatrix[i][col] == null || boardMatrix[i][col] != p.Character)
                        diagWinnerRight_Left = false;
                    col--;
                }
            }
            return (rowWinner || colWinner || diagWinnerLeft_Right || diagWinnerRight_Left);
        }
        public class BoardBuilder
        {
            Board board;

            public BoardBuilder()
            {
                board= new Board();
            }

            public BoardBuilder setPlayer1(Player p)
            {
                board.player1 = p;
                return this;
            }

            public BoardBuilder setPlayer2(Player p)
            {
                board.player2 = p;
                return this;
            }

            public Board Build()
            {
                return board;
            }
        }

    }
}
