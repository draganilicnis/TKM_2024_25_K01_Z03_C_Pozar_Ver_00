// https://arena.petlja.org/sr-Latn-RS/competition/2024-2025-kv1-testiranje#tab_137833
// https://algora.petlja.org/t/2024-2025/9035/3
// https://github.com/draganilicnis/TKM_2024_25_K01_Z03_C_Pozar_Ver_00/blob/main/TKM_2024_25_K01_Z03_C_Pozar.cs
// Dobrosavljevic Vukasin C++

using System;
using System.Collections.Generic;
class TKM_2024_25_K01_Z03_C_Pozar_Ver_00
{
    static void Main()
    {
        char[,] mz = new char[1000, 1000];
        int[,] ft = new int[1000, 1000];
        int[,] st = new int[1000, 1000];
        Queue<(int, int)> fq = new Queue<(int, int)>();
        Queue<(int, int)> sq = new Queue<(int, int)>();
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        string[] dimensions = Console.ReadLine().Split();
        int n = int.Parse(dimensions[0]);
        int m = int.Parse(dimensions[1]);

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < m; j++)
            {
                mz[i, j] = line[j];
                ft[i, j] = -1;
                st[i, j] = -1;
                if (mz[i, j] == 'X')
                {
                    fq.Enqueue((i, j));
                    ft[i, j] = 0;
                }
                if (mz[i, j] == 'S')
                {
                    sq.Enqueue((i, j));
                    st[i, j] = 0;
                }
            }
        }

        while (fq.Count > 0)
        {
            var (x, y) = fq.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i], ny = y + dy[i];
                if (nx >= 0 && nx < n && ny >= 0 && ny < m && mz[nx, ny] != '*' && ft[nx, ny] == -1)
                {
                    ft[nx, ny] = ft[x, y] + 1;
                    fq.Enqueue((nx, ny));
                }
            }
        }

        while (sq.Count > 0)
        {
            var (x, y) = sq.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i], ny = y + dy[i];
                if (nx >= 0 && nx < n && ny >= 0 && ny < m && mz[nx, ny] != '*' && st[nx, ny] == -1)
                {
                    st[nx, ny] = st[x, y] + 1;
                    sq.Enqueue((nx, ny));
                }
            }
        }

        int br = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (mz[i, j] == '.' && st[i, j] != -1 && (ft[i, j] == -1 || st[i, j] < ft[i, j]))
                {
                    br++;
                }
            }
        }

        Console.WriteLine(br);
    }
}
