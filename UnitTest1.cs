using System;
using LifeGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaeOfLifeTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void OneAliveTest()
        {
            var game = new GameOfLife();
            int[,] inputState = new int[4, 4] {
               {1, 0, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0}
            };

            int[,] initialState = new int[4, 4] {
               {1, 0, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0}
            };

            int[,] expectedState = new int[4, 4] {
               {0, 0, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0}
            };
            var nextState = game.SimulateNextGeneration(inputState);
            VerifyState(expectedState, nextState);

            nextState = game.SimulateNextGeneration(nextState);
            VerifyState(expectedState, nextState);
        }

        [TestMethod]
        public void ThreeNeighboursaliveTest()
        {
            var game = new GameOfLife();
            int[,] inputState = new int[4, 4] {
               {0, 1, 0, 0} ,
               {1, 1, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0}
            };

            int[,] expectedState = new int[4, 4] {
               {1, 1, 0, 0} ,
               {1, 1, 0, 0} ,
               {0, 0, 0, 0} ,
               {0, 0, 0, 0}
            };
            var nextState = game.SimulateNextGeneration(inputState);
            VerifyState(expectedState, nextState);

            nextState = game.SimulateNextGeneration(nextState);
            VerifyState(expectedState, nextState);
        }

        [TestMethod]
        public void FourNeighboursDieTest()
        {
            var game = new GameOfLife();
            int[,] inputState = new int[4, 4] {
               {0, 0, 0, 0} ,
               {1, 1, 1, 0} ,
               {0, 1, 1, 0} ,
               {0, 0, 0, 0}
            };

            int[,] expectedState = new int[4, 4] {
               {0, 1, 1, 0} ,
               {1, 0, 1, 0} ,
               {0, 1, 1, 0} ,
               {0, 0, 0, 0}
            };
            var nextState = game.SimulateNextGeneration(inputState);
            VerifyState(expectedState, nextState);
        }

        private static void VerifyState(int[,] expectedState, int[,] nextState)
        {
            for (int i = 0; i < nextState.GetLength(0); i++)
            {
                for (int j = 0; j < nextState.GetLength(1); j++)
                {
                    Assert.AreEqual(expectedState[i, j], nextState[i, j]);
                }
            }
        }
    }
}