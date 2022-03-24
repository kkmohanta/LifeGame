using System.Text.Json.Serialization;

namespace LifeGame
{
    public class GameOfLife
    {
        public int[,] SimulateNextGeneration(int[,] initialState)
        {
            for(int i = 0; i < initialState.GetLength(0); i++)
            {
                for(var j = 0; j < initialState.GetLength(1); j++)
                {
                    int liveNeighboursCount = GetLiveNeighboursCount(initialState, i, j);
                    if(liveNeighboursCount < 2 || liveNeighboursCount > 3)
                    {
                        initialState[i, j] = 0;
                    }
                    if(initialState[i, j] == 0)
                    {
                        if(liveNeighboursCount == 3)
                        {
                            initialState[i, j] = 1;
                        }
                    }
                }
            }
            return initialState;
        }

        private static int GetLiveNeighboursCount(int[,] initialState, int i, int j)
        {
            int liveNeighboursCount = 0;
            for (int k = -1; k <= 1; k++)
            {
                for (int l = -1; l <= 1; l++)
                {
                    if (k == 0 && l == 0)
                    {
                        continue;
                    }
                    if (i + k < 0 || j + l < 0 || i + k >= initialState.GetLength(0)
                        || j + l >= initialState.GetLength(1))
                    {
                        continue;
                    }
                    liveNeighboursCount += initialState[i + k, j + l];
                }
            }
            return liveNeighboursCount;
        }
    }
}