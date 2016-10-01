using NUnit.Framework;
using System;


namespace SudokuTests
{
	[TestFixture ()]
	public class Sudoku
	{
		[Test ()]
		public void CreateInstance ()
		{
			SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku ();
		}
	}
}