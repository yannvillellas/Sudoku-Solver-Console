using System;
namespace S3_APOO_sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new int[,]
            {
                { 0, 0, 0, 0, 1, 9, 2, 0, 0 },
                { 0, 9, 4, 0, 0, 3, 0, 0, 0 },
                { 0, 0, 0, 0, 8, 0, 6, 7, 0 },
                { 7, 0, 9, 5, 0, 4, 0, 0, 0 },
                { 0, 0, 6, 7, 0, 1, 9, 0, 0 },
                { 0, 0, 0, 3, 0, 8, 4, 0, 7 },
                { 0, 3, 2, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 7, 9, 0 },
                { 0, 0, 8, 9, 4, 0, 0, 0, 0 }
            };
            Print(sudoku);
            Solve(sudoku);
            Print(sudoku);
        }
        private static bool Solve(int[,] sudoku)
        {
            if (sudoku != null && sudoku.GetLength(0) == sudoku.GetLength(1) && sudoku.GetLength(0) == 9)
            {
                for (int i = 0; i < sudoku.GetLength(0); i++)
                {
                    for (int j = 0; j < sudoku.GetLength(1); j++)
                    {
                        if (sudoku[i, j] == 0)
                        {
                            for (int c = 1; c <= 9; c++)
                            {
                                if (IsValid(sudoku, i, j, c))
                                {
                                    sudoku[i, j] = c;
                                    if (Solve(sudoku))
                                        return true;
                                    else
                                        sudoku[i, j] = 0;
                                }
                            }
                            return false;
                        }
                    }
                }
                return true;
            }
            else return false;
        }
        private static bool IsValid(int[,] sudoku, int row, int column, int c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, column] != 0 && sudoku[i, column] == c) //row
                    return false;
                if (sudoku[row, i] != 0 && sudoku[row, i] == c) //column
                    return false;
                if (sudoku[3 * (row / 3) + i / 3, 3 * (column / 3) + i % 3] != '.' && sudoku[3 * (row / 3) + i / 3, 3 * (column / 3) + i % 3] == c) //square
                    return false;
            }
            return true;
        }
        private static void Print(int[,] sudoku)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            string result = "";
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    result += "\n";
                    for (int ii = 0; ii < 11; ii++)
                    {
                        result += String.Format("{0,2}", "--");
                    }
                }
                result += "\n";
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0)
                        result += "|";
                    if (sudoku[i, j] != 0)
                        result += String.Format("{0,2}", sudoku[i, j]);
                    else
                        result += String.Format("{0,2}", "*");
                }
                result += "|";
            }
            result += "\n";
            for (int ii = 0; ii < 11; ii++)
            {
                result += String.Format("{0,2}", "--");
            }
            Console.WriteLine(result);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
