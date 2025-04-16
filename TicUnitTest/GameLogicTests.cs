using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TicGame;
using TicTacToeWPF;

namespace TicUnitTests
{
    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        public void CheckWin_RowWin_ReturnsTrue()
        {
            var board = new char[3, 3]
            {
                { 'X', 'X', 'X' },
                { 'O', ' ', ' ' },
                { 'O', ' ', ' ' }
            };
            bool result = GameWinLogic.CheckWin(board, 'X', out List<(int, int)> line);
            Assert.IsTrue(result);
            Assert.AreEqual(3, line.Count);
        }

        [TestMethod]
        public void CheckWin_ColumnWin_ReturnsTrue()
        {
            var board = new char[3, 3]
            {
                { 'O', 'X', ' ' },
                { 'O', 'X', ' ' },
                { 'O', ' ', 'X' }
            };
            bool result = GameWinLogic.CheckWin(board, 'O', out List<(int, int)> line);
            Assert.IsTrue(result);
            Assert.AreEqual(3, line.Count);
        }

        [TestMethod]
        public void CheckWin_DiagonalWin_ReturnsTrue()
        {
            var board = new char[3, 3]
            {
                { 'X', 'O', ' ' },
                { 'O', 'X', ' ' },
                { ' ', ' ', 'X' }
            };
            bool result = GameWinLogic.CheckWin(board, 'X', out List<(int, int)> line);
            Assert.IsTrue(result);
            Assert.AreEqual(3, line.Count);
        }

        [TestMethod]
        public void CheckWin_NoWin_ReturnsFalse()
        {
            var board = new char[3, 3]
            {
                { 'X', 'O', 'X' },
                { 'O', 'O', 'X' },
                { 'X', 'X', 'O' }
            };
            bool result = GameWinLogic.CheckWin(board, 'X', out List<(int, int)> line);
            Assert.IsFalse(result);
        }
    }
}