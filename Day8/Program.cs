using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main()
        {
            string[] rows = File.ReadAllLines("input.txt");
            string[] columns = new string[rows.Length];

            int edgeVisibles = 2 * rows.Length + 2 * columns.Length - 4;

            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i];

                for (int j = 0; j < row.Length; j++)
                {
                    columns[j] += row[j];
                }
            }

            Console.WriteLine("Part A\n");
            Console.WriteLine("visibles in the center (height, row, column)");

            List<string> centerVisibles = new List<string>();

            for (int i = 1; i < (rows.Length - 1); i++)
            {
                string row = rows[i];

                for (int j = 1; j < (row.Length - 1); j++)
                {
                    string column = columns[j];
                    
                    int x = int.Parse(row[j].ToString());

                    string left = row.Substring(0, j);
                    string right = row.Substring((j + 1));
                    string up = column.Substring(0, i);
                    string down = column.Substring((i+1));

                    int l = 0;
                    int r = 0;
                    int u = 0;
                    int d = 0;

                    for (int k = 0; k < left.Length; k++)
                    {
                        if (int.Parse(left[k].ToString()) >= x)
                        {
                            l = -99;
                            break;
                        }
                            
                        l++;
                    }

                    for (int k = 0; k < right.Length; k++)
                    {
                        if (int.Parse(right[k].ToString()) >= x)
                        {
                            r = -99;
                            break;
                        }

                        r++;
                    }

                    for (int k = 0; k < up.Length; k++)
                    {
                        if (int.Parse(up[k].ToString()) >= x)
                        {
                            u = -99;
                            break;
                        }

                        u++;
                    }

                    for (int k = 0; k < down.Length; k++)
                    {
                        if (int.Parse(down[k].ToString()) >= x)
                        {
                            d = -99;
                            break;
                        }

                        d++;
                    }

                    if (l == left.Length || r == right.Length || u == up.Length || d == down.Length)
                    {
                        string visible = x + "," + i + "," + j;
                        Console.WriteLine(visible);
                        centerVisibles.Add(visible);
                    }
                }
            }

            Console.WriteLine("Visibles in the center: " + centerVisibles.Count);
            Console.WriteLine("Visibles in the edges: " + edgeVisibles);
            Console.WriteLine("Total visible trees: " + (centerVisibles.Count + edgeVisibles));

            Console.WriteLine("\nPart B\n");

            int highestScore = 0;

            for (int i = 1; i < (rows.Length - 1); i++)
            {
                string row = rows[i];

                for (int j = 1; j < (row.Length - 1); j++)
                {
                    string column = columns[j];

                    int x = int.Parse(row[j].ToString());

                    string left = row.Substring(0, j);
                    string right = row.Substring((j + 1));
                    string up = column.Substring(0, i);
                    string down = column.Substring((i + 1));

                    int l = 0;
                    int r = 0;
                    int u = 0;
                    int d = 0;

                    for (int k = (left.Length - 1); k >= 0; k--)
                    {
                        l++;

                        if (int.Parse(left[k].ToString()) >= x)
                        {
                            break;
                        }
                    }

                    for (int k = 0; k < right.Length; k++)
                    {
                        r++;

                        if (int.Parse(right[k].ToString()) >= x)
                        {
                            break;
                        }
                    }

                    for (int k = (up.Length - 1); k >= 0; k--)
                    {
                        u++;

                        if (int.Parse(up[k].ToString()) >= x)
                        {
                            break;
                        }
                    }

                    for (int k = 0; k < down.Length; k++)
                    {
                        d++;

                        if (int.Parse(down[k].ToString()) >= x)
                        {
                            break;
                        }
                    }

                    int score = l * r * u * d;

                    if(score > highestScore)
                    {
                        highestScore = score;
                        Console.WriteLine("new highest score: " + highestScore + ", row " + i + ", column " + j + ", height " + x + ", values: " + l + "," + r + "," + u + "," + d);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
