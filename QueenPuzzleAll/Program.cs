using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenPuzzleAll
{
    class Program
    {
        static void Main(string[] args)
        {
            solveNQ();
            Console.Read();
        }
        static int N = 8;
        static int k = 1;

      
        static void printSolution(string[,] board)
        {
            Console.Write("{0}-\n", k++);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" {0} ", board[i, j]);
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        static void solveNQ()
        {
            string[,] board = new string[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    board[i, j] = ".";
            if (solveNQUtil(board, 0) == false)
            {
                Console.Write("Solution does not exist");
                return;
            }

            return;
        }

        static bool solveNQUtil(string[,] board, int col)
        {
        
            if (col == N)
            {
                printSolution(board);
                return true;
            }

        
            bool res = false;
            for (int i = 0; i < N; i++)
            {
           
                if (isSafe(board, i, col))
                {
                 
                    board[i, col] = "Q";

                    res = solveNQUtil(board, col + 1) || res;

           
                    board[i, col] = "."; 
                }
            }

      
            return res;
        }

        static bool isSafe(string[,] board, int row, int col)
        {
            int i, j;

           
            for (i = 0; i < col; i++)
                if (board[row, i] == "Q")
                    return false;

       
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == "Q")
                    return false;

     
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
                if (board[i, j] == "Q")
                    return false;

            return true;
        }
    }
}
