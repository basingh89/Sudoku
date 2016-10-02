using NUnit.Framework;
using System;

namespace SudokuTests
{
    [TestFixture]
    public class Sudoku
    {
        [Test]
        public void CreateInstance()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            Assert.NotNull(sudoku);
        }

        [Test]
        public void Rank()
        {
            uint rank = 3U;
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(rank);
            Assert.AreEqual(rank, sudoku.Rank);
        }

        [Test]
        public void Length()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            Assert.AreEqual(9U, sudoku.Length);
        }

        [Test]
        public void Count()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            Assert.AreEqual(81U, sudoku.Count);
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ColumnIndex()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            SudokuSolver.Cell cell = sudoku[100U, 0U];
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RowIndex()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            SudokuSolver.Cell cell = sudoku[0U, 100U];
        }

        [Test]
        public void IndexAcessor()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            SudokuSolver.Cell cell = sudoku[3U, 3U];
            Assert.NotNull(cell);
        }

        [Test]
        public void IndexCheck()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(4U);
            SudokuSolver.Cell cell = sudoku[15U, 3U];
            Assert.AreEqual(15U, cell.Column);
            Assert.AreEqual(3U, cell.Row);
        }

        [Test]
        public void CountUnknown()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            Assert.AreEqual(81U, sudoku.CountUnknown);
        }

        [Test]
        public void NotSolved()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            Assert.False(sudoku.IsSolved);
        }

        [Test]
        public void EmptySolve()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            sudoku.Solve(true);
            Assert.False(sudoku.IsSolved);
        }
    }
}