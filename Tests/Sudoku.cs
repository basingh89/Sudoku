using NUnit.Framework;
using System;


namespace SudokuTests
{
	[TestFixture]
	public class Sudoku
	{
		[Test]
		public void CreateInstance ()
		{
			SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku (3U);
			Assert.IsNotNull (sudoku);
		}

		[Test]
		public void CheckRank ()
		{
			SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku (3U);
			Assert.AreEqual (3U, sudoku.Rank);
		}

		[Test]
		public void CheckLength ()
		{
			SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku (3U);
			Assert.AreEqual (9U, sudoku.Length);
		}

		[Test]
		public void CheckCount ()
		{
			SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku (3U);
			Assert.AreEqual (81U, sudoku.Count);
		}
	}
}