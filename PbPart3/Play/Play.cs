using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Play
{
    public class Play
    {

        public static int ReturnMoves(char[,] board, int row, int col, ref int totalMoves)
        {
            if ((col < 0) || (row < 0) ||

        (col >= board.GetLength(1)) || (row >= board.GetLength(0)))
            {              
                return totalMoves;
            }

            if ((board[row, col] == ' ') && (board[row - 1, col] == ' ' || board[row + 1, col] == ' ' || board[row, col - 1] == ' ' || board[row, col + 1] == ' '))
                totalMoves++;
                        
            totalMoves = ReturnMoves(board, row - 1, col, ref totalMoves);
            totalMoves = ReturnMoves(board, row + 1, col, ref totalMoves);
            totalMoves = ReturnMoves(board, row, col - 1, ref totalMoves);
            totalMoves = ReturnMoves(board, row, col + 1, ref totalMoves);

            return totalMoves;
        }

        public static bool NoMoreMoves(char[,] board)
        {
            var noMoreMoves = true;

            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)

                    if ((board[i, j] == ' ') && (board[i - 1, j] == ' ' || board[i + 1, j] == ' ' || board[i, j - 1] == ' ' || board[i, j + 1] == ' '))
                        noMoreMoves = false;

            return noMoreMoves;
        }

    }
}
