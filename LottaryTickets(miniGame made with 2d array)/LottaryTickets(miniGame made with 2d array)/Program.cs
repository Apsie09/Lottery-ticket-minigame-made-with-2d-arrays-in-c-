using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottaryTickets_miniGame_made_with_2d_array_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Row:");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Col:");
            int col = int.Parse(Console.ReadLine());
            int[,] matrix = new int[row, col];


            Console.WriteLine("Enter the lottery ticket numbers and see what will happen:");
            for (int i = 0; i < row; i++)
            {
                int[] rowArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rowArray[i];
                    matrix[i, j] = rowArray[j];
                }
            }

            var sum = 0;
            var sum1 = 0;
            var sum2 = 0;
            var sum3 = 0;

            bool win = true;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                    if (i + j == 2)
                    {
                        sum1 += matrix[i, j];
                    }
                    if (i < j)
                    {
                        sum2 += matrix[i, j];
                    }
                    if (i > j)
                    {
                        sum3 += matrix[i, j];
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(sum + " sum");
            Console.WriteLine(sum1 + " sum1");
            Console.WriteLine(sum2 + " sum2");
            Console.WriteLine(sum3 + " sum3");
            Console.WriteLine();

            if (sum != sum1) win = false;
            if (sum2 % 2 == 1) win = false;
            if (sum3 % 2 == 0) win = false;

           if (win == false)
            {
                Console.WriteLine("YOU LOST");
            }
           else
            {
                Console.WriteLine("YOU WIN");
            }

            if (win)
            {
                var pechalba = 0;
                var sumDiag = 0;
                var sumVyn = 0;
                var sumKol = 0;
                var sumPod = 0;

                pechalba += sum3;

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (i > j)
                        {
                            sumPod += matrix[i, j];
                        }
                    }
                }

                //sum na diagonal
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (i == j && matrix[i, j] % 2 == 0)
                        {
                            sumDiag += matrix[i, j];
                        }
                    }
                }

                //sum vynshni redove

                //sum vynshni redove
                for (int i = row - 1; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (matrix[i, j] % 2 == 0)
                        {
                            sumVyn += matrix[i, j];
                        }
                    }
                }

                //vynshni koloni
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        if (matrix[i, j] % 2 == 1)
                        {
                            sumKol += matrix[i, j];
                        }
                    }
                }

                //vynshni koloni
                for (int j = col - 1; j < col; j++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        if (matrix[j, i] % 2 == 1)
                        {
                            sumKol += matrix[i, j];
                        }
                    }
                }

                pechalba = sumPod + sumDiag + sumVyn + sumKol;

                Console.WriteLine("The amount of money won is: {0:f0}",pechalba / 4);
            }
        }
    }
}
