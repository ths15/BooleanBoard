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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program Path = new();
            Console.WriteLine("Number of steps: " + Path.FindPath());
        }

        public int FindPath()
        {
            int steps = 0;

            int [] current = start;

            while(!end.SequenceEqual(current))
            {
                if(current[0] > end[0])
                {
                    if(current[0] > end[0])
                    {
                        current[0]--;
                        steps++;
                    }
                    else
                    {
                        current[0]++;
                        steps++;
                    }
                }
                else
                {
                    if(current[1] > end[1])
                    {
                        current[1]--;
                        steps++;
                    }
                    else
                    {
                        current[1]++;
                        steps++;
                    }
                }

                Console.WriteLine("Current steps: " + steps);
                
            }

            /*
            foreach(bool i in board)
            {
                Console.WriteLine(i);
            }
            */

            return steps;
        }

    }
}