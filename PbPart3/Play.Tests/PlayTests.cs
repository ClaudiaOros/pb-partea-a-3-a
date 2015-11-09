using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Play;

namespace Play.Tests
{
    [TestClass]
    public class PlayTests
    {
       [Ignore]
        [TestMethod]
        public void Play1()
        {
            char[,] board = 
            {
               {' ',' ',' ',' '},
               {' ',' ',' ',' '},
               {' ','X',' ',' '},
               {' ',' ',' ',' '},
            };

            var expectedMoves = 11;
            var totalMoves = 0;

            var moves = Play.ReturnMoves(board, 0, 0, ref totalMoves);

            Assert.AreEqual(expectedMoves, totalMoves);
        }

        [Ignore]
        [TestMethod]
        public void Play2()
        {
            char[,] board = 
            {
               {' ',' ',' ',' '},
               {' ',' ',' ',' '},
               {' ',' ',' ',' '},
               {' ',' ',' ',' '},
            };

            var expectedMoves = 10;
            var totalMoves = 0;

            var moves = Play.ReturnMoves(board, 0, 0, ref totalMoves);

            Assert.AreEqual(expectedMoves, totalMoves);
        }

        [Ignore]
        [TestMethod]
        public void Play3()
        {
            char[,] board = 
            {
               {' ','X',' ','X'},
               {' ',' ','X',' '},
               {' ','X',' ',' '},
               {'X',' ',' ','X'},
            };

            var expectedMoves = 0;
            var totalMoves = 0;

            var moves = Play.ReturnMoves(board, 0, 0, ref totalMoves);

            Assert.AreEqual(expectedMoves, totalMoves);
        }

        [Ignore]
        [TestMethod]
        public void Play4()
        {
            char[,] board = 
            {
               {'X',' ',' ','X'},
               {' ',' ','X',' '},
               {' ','X',' ',' '},
               {'X',' ',' ','X'},
            };

            var expectedMoves = 0;
            var totalMoves = 0;

            var moves = Play.ReturnMoves(board, 0, 0, ref totalMoves);

            Assert.AreEqual(expectedMoves, totalMoves);
        }
    }
}
