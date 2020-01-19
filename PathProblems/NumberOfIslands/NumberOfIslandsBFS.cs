using System;

namespace NumberOfIslands
{
    using System.Collections.Generic;

    public class NumberOfIslandsBFS
    {
        public int NumIslands(char[][] grid)
        {
            if (grid.Length == 0) return 0;
            int max_x = grid.Length;
            int max_y = grid[0].Length;
            var numIslands = 0;
            for (int i = 0; i < max_x; i++)
            {
                for (int j = 0; j < max_y; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numIslands++;
                        grid[i][j] = '0';
                        FindAllConnectedNodes(i, j, grid);
                    }
                }
            }

            return numIslands;
        }

        private void FindAllConnectedNodes(int i, int j, char[][] grid)
        {
            Queue<KeyValuePair<int, int>> coordinateQueue = new Queue<KeyValuePair<int, int>>();
            //check left
            if (i - 1 >= 0)
            {
                if (grid[i - 1][j] == '1')
                {
                    grid[i - 1][j] = '0';
                    coordinateQueue.Enqueue(new KeyValuePair<int, int>(i - 1, j));
                }
            }
            //check right
            if (i + 1 < grid.Length)
            {
                if (grid[i + 1][j] == '1')
                {
                    grid[i + 1][j] = '0';
                    coordinateQueue.Enqueue(new KeyValuePair<int, int>(i + 1, j));
                }
            }

            //check up
            if (j - 1 >= 0)
            {
                if (grid[i][j - 1] == '1')
                {
                    grid[i][j - 1] = '0';
                    coordinateQueue.Enqueue(new KeyValuePair<int, int>(i, j - 1));
                }
            }

            //check down
            if (j + 1 < grid[0].Length)
            {
                if (grid[i][j + 1] == '1')
                {
                    grid[i][j + 1] = '0';
                    coordinateQueue.Enqueue(new KeyValuePair<int, int>(i, j + 1));
                }
            }

            while (coordinateQueue.Count>0)
            {
                var front = coordinateQueue.Dequeue();
                FindAllConnectedNodes(front.Key, front.Value, grid);
            }
        }
    }
}
