using System;

namespace SudokuSolver
{
	public class Cell
	{
		private readonly Sudoku sudoku;
		private uint givenValue;
		private uint solvedValue;

		/// <summary>
		/// Initializes a new instance with unknown value.
		/// </summary>
		/// <param name="sudoku">Sudoku</param>
		/// <exception cref="ArgumentNullException"></exception>
		public Cell (Sudoku sudoku)
		{
			if (sudoku == null)
				throw new ArgumentNullException ("Sudoku");

			this.sudoku = sudoku;
			Reset ();
		}

		/// <summary>
		/// Initializes a new instance with the given value.
		/// </summary>
		/// <param name="sudoku">Sudoku</param>
		/// <param name="value">Value</param>
		/// <exception cref="ArgumentNullException"></exception>
		public Cell (Sudoku sudoku, uint value) : this (sudoku)
		{
			Value = value;
		}

		/// <summary>
		/// Resets the cell to unknown.
		/// </summary>
		public void Reset ()
		{
			givenValue = 0U;
			solvedValue = 0U;
		}

		/// <summary>
		/// Returns whether the cell has a given value.
		/// </summary>
		/// <value><c>true</c> if this cell value is given; otherwise, <c>false</c>.</value>
		public bool IsGiven { get { return givenValue != 0U; } }

		/// <summary>
		/// Returns whether the cell has a solved value.
		/// </summary>
		/// <value><c>true</c> if this cell value is solved; otherwise, <c>false</c>.</value>
		public bool IsSolved { get { return solvedValue != 0U; } }

		/// <summary>
		/// Returns whether the cell value is known.
		/// </summary>
		/// <value><c>true</c> if this cell value is unknown; otherwise, <c>false</c>.</value>
		public bool IsUnknown { get { return !(IsGiven || IsSolved); } }

		/// <summary>
		/// Gets or sets the value of the cell
		/// </summary>
		/// <value>The value of the cell</value>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public uint Value {
			get {
				if (IsGiven)
					return givenValue;
				if (IsSolved)
					return solvedValue;

				return 0U;
			}
			set {
				if (value > sudoku.Length)
					throw new ArgumentOutOfRangeException ("Value greater than Sudoku length");

				Reset ();
				givenValue = value;
			}
		}
	}
}