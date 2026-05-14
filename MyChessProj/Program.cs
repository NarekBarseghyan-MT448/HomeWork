using System;
using System.Collections.Generic;

namespace MyChessProj;

class Program
{
    static void Main()
    {
        int n = 8;
=
        PrintMainDiagonal(n);

        Console.WriteLine("Երկրորդական անկյունագիծ:");
        PrintSecondDiagonal(n);
==

        // Նավակի քայլի ստուգում
        Console.WriteLine($"Կարո՞ղ է նավակը (2,3)-ից գնալ (5,3): {PrintCanRookMove(2, 3, 5, 3)}");
        Console.WriteLine("---------------------------");

        // Ձիու մեկ քայլի ստուգում
        Console.WriteLine($"Կարո՞ղ է ձին (2,3)-ից գնալ (4,4): {PrintCanKnightMove(2, 3, 4, 4)}");
        Console.WriteLine("------------------------------");

        // Ձիու նվազագույն քայլերը
        int steps = GetKnightMinSteps(1, 1, 8, 8);
        Console.WriteLine("Ձիու նվազագույն քայլերի քանակը (1,1)-ից (8,8): " + steps);

        Console.ReadKey();
    }

    static void PrintMainDiagonal(int MatrixSize)
    {
        for (int i = 0; i < MatrixSize; i++)
        {
            for (int j = 0; j < MatrixSize; j++)
            {
                Console.Write(i == j ? "# " : "* ");
            }
            Console.WriteLine();
        }
    }

    static void PrintSecondDiagonal(int MatrixSize)
    {
        for (int i = 0; i < MatrixSize; i++)
        {
            for (int j = 0; j < MatrixSize; j++)
            {
                Console.Write(i + j == MatrixSize - 1 ? "# " : "* ");
            }
            Console.WriteLine();
        }
    }

    static bool PrintCanRookMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        if (startRow == targetRow && startCol == targetCol) return false;

        // Նավակը շարժվում է կամ նույն տողով, կամ նույն սյունով
        return startRow == targetRow || startCol == targetCol;
    }

    static bool PrintCanKnightMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        int deltaRow = Math.Abs(startRow - targetRow);
        int deltaCol = Math.Abs(startCol - targetCol);

        // Ավելացվեց || օպերատորը
        return (deltaRow == 2 && deltaCol == 1) || (deltaRow == 1 && deltaCol == 2);
    }

    static int GetKnightMinSteps(int startRow, int startCol, int targetRow, int targetCol)
    {
        // Հնարավոր բոլոր 8 ուղղությունները
        int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

        Queue<(int r, int c, int dist)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((startRow, startCol, 0));

        bool[,] visited = new bool[9, 9]; // Օգտագործում ենք 1-8 ինդեքսները
        visited[startRow, startCol] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.r == targetRow && current.c == targetCol)
                return current.dist;

            for (int i = 0; i < 8; i++)
            {
                int nextR = current.r + dx[i];
                int nextC = current.c + dy[i];

                if (nextR >= 1 && nextR <= 8 && nextC >= 1 && nextC <= 8 && !visited[nextR, nextC])
                {
                    visited[nextR, nextC] = true;
                    queue.Enqueue((nextR, nextC, current.dist + 1));
                }
            }
        }
        return -1;
    }
}