using System;
using System.Linq;

namespace SudokuSolver
{
	public class Cell
	{
		private readonly Sudoku sudoku;
		private readonly uint sudokuColumn, sudokuRow;
		private uint givenValue, solvedValue;

		/// <summary>
		/// Initializes a new instance with unknown value.
		/// </summary>
		/// <param name="sudoku">Sudoku</param>
		/// <param name="column">Column</param>
		/// <param name="row">Row</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public Cell (Sudoku sudoku, uint column, uint row)
		{
			// sudoku
			if (sudoku == null)
				throw new ArgumentNullException ("Sudoku");
			this.sudoku = sudoku;

			// column
			if (column >= this.sudoku.Length)
				throw new IndexOutOfRangeException ("Column");
			sudokuColumn = column;

			//row
			if (row >= this.sudoku.Length)
				throw new IndexOutOfRangeException ("Row");
			sudokuRow = row;

			// Initialize values
			Reset ();
		}

		/// <summary>
		/// Initializes a new instance with the given value.
		/// </summary>
		/// <param name="sudoku">Sudoku</param>
		/// <param name="column">Column</param>
		/// <param name="row">Row</param>
		/// <param name="value">Value</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="IndexOutOfRangeException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Cell (Sudoku sudoku, uint column, uint row, uint value) : this (sudoku, column, row)
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
		/// Gets the column.
		/// </summary>
		/// <value>The column.</value>
		public uint Column { get { return sudokuColumn; } }

		/// <summary>
		/// Gets the row.
		/// </summary>
		/// <value>The row.</value>
		public uint Row { get { return sudokuRow; } }

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
		/// <exception cref="ArgumentException"></exception>
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
					throw new ArgumentOutOfRangeException (this + ": Value greater than Sudoku length");

				// save old value before reset
				uint old = givenValue;
				Reset ();

				// check if value is allowed
				uint[] allowed = AllowedValue;
				if (!allowed.Contains (value)) {
					givenValue = old;
					throw new ArgumentException (this + ": Value now allowed");
				}

				givenValue = value;
			}
		}

		public uint[] AllowedValue {
			get {
				if (IsGiven)
					return new uint[] { givenValue };

				bool[] taken = new bool[sudoku.Length + 1U];

				for (uint index = 0U; index < sudoku.Length; index++) {

					// column vector
					if (index != Column)
						taken [sudoku [index, sudokuRow].Value] = true;

					// row vector
					if (index != Row)
						taken [sudoku [sudokuColumn, index].Value] = true;

					// square box
					uint boxIndex = index % sudoku.Rank;
					uint column = (sudokuColumn % sudoku.Rank) + (index - boxIndex) / sudoku.Rank;
					uint row = (sudokuRow % sudoku.Rank) + boxIndex;
					if ((column != sudokuColumn) && (row != sudokuRow))
						taken [sudoku [column, row].Value] = true;
				}

				uint[] allowed = new uint[taken.Where ((value, index) => index > 0).Count (value => !value)];
				if (allowed.Length == 0)
					throw new ArgumentException (this + ": No values allowed");

				uint allowedIndex = 0U;
				for (uint index = 1U; index < taken.Length; index++)
					if (!taken [index])
						allowed [allowedIndex++] = index;

				return allowed;
			}
		}


		/// <summary>
		/// Solve the value of the cell.
		/// </summary>
		/// <param name="force">If set to <c>true</c>, force to resolve
		public bool Solve (bool force)
		{
			if (IsGiven)
				return false;
			
			if (!force && IsSolved)
				return false;


			uint[] allowed = AllowedValue;

			if (allowed.Length != 1)
				return false;

			solvedValue = allowed [0];
			return true;
		}

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Cell"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Cell"/>.</returns>
		public override string ToString ()
		{
			return string.Format ("Cell[{0}, {1}]", sudokuColumn, sudokuRow);
		}
	}
}