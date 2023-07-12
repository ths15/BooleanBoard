using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooleanBoard
{
    class Program
    {
        bool[,] board = new bool[,] {{false, false, false, false},
                                    {true, true, false, true},
                                    {false, false, false, false},
                                    {false, false, false, false}};

        int[] start = new int[] {3, 0};
        int[] end = new int[] {0, 0};
        int totalRows;
        int totalCols;
        int matrixSize;

        int[] directionVectorRow = new int[] {-1, 1, 0, 0};
        int[] directionVectorColumn = new int[] {0, 0, 1, -1};

        bool[,] visited;

        Queue<int> rowQueue = new Queue<int>();
        Queue<int> colQueue = new Queue<int>();
        
        int nodesInNextLayer = 0;

        public Program()
        {
            totalRows = board.GetLength(0);
            totalCols = board.GetLength(1);
            matrixSize = board.Length;
            visited = new bool[totalRows, totalCols];

            for(int i = 0; i < totalRows; i++)
            {
                for(int j = 0; j < totalCols; j++)
                {
                    visited[i, j] = false;
                }
            }
        }

        static void Main(string[] args)
        {
            Program Path = new();
            Console.WriteLine("Number of steps: " + Path.FindPath());
        }

        private int FindPath()
        {
            int steps = 0;
            int nodesLeftInLayer = 1;

            bool reachedEnd = false;

            rowQueue.Enqueue(start[0]);
            colQueue.Enqueue(start[1]);

            visited[start[0], start[1]] = true;

            while(rowQueue.Count > 0)
            {
                int currRow = rowQueue.Dequeue();
                int  currCol = colQueue.Dequeue();

                if(currRow == end[0] && currCol == end[1])
                {
                    reachedEnd = true;
                    break;
                }

                ExploreNeighbors(currRow, currCol);

                nodesLeftInLayer--;

                if(nodesLeftInLayer == 0)
                {
                    nodesLeftInLayer = nodesInNextLayer;
                    nodesInNextLayer = 0;
                    steps++;
                }
            }

            if(reachedEnd)
            {
                return steps;
            }
            return -1;
        }

        private void ExploreNeighbors(int row, int col)
        {
            for(int i = 0; i < 4; i++)
            {
                int newRow = row + directionVectorRow[i];
                int newCol = col + directionVectorColumn[i];

                if(newRow < 0 || newCol < 0)
                    continue;
                if(newRow >= totalRows || newCol >= totalCols)
                    continue;

                if(visited[newRow, newCol] == true)
                    continue;
                if(board[newRow, newCol] == true)
                    continue;

                rowQueue.Enqueue(newRow);
                colQueue.Enqueue(newCol);

                visited[newRow, newCol] = true;
                nodesInNextLayer++;
            }
        }

    }
}