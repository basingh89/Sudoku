using System;
using System.Linq;

namespace SudokuSolver
{
	public class Sudoku
	{
		/// <summary>
		/// Stores the rank of the <see cref="Sudoku"/>.
		/// </summary>
		private readonly uint rank;

		/// <summary>
		/// Stores the cells in the <see cref="Sudoku"/>.
		/// </summary>
		private Cell[] cells;

		/// <summary>
		/// Initializes a new instance of the <see cref="Sudoku"/> class.
		/// </summary>
		/// <param name="rank">Rank</param>
		public Sudoku (uint rank)
		{
			this.rank = rank;
			InitializeCells ();
		}

		/// <summary>
		/// Initializes the cells.
		/// </summary>
		private void InitializeCells ()
		{
			cells = new Cell[Count];

			for (uint index = 0U; index < Count; index++)
				cells [index] = new Cell ();
		}

		/// <summary>
		/// Gets the rank.
		/// </summary>
		/// <value>The rank.</value>
		public uint Rank { get { return rank; } }

		/// <summary>
		/// Gets the length of each side.
		/// </summary>
		/// <value><see cref="Rank"/>^2</value>
		public uint Length { get { return rank * rank; } }

		/// <summary>
		/// Gets the total number of cells.
		/// </summary>
		/// <value><see cref="Length"/>^2</value>
		public uint Count { get { return Length * Length; } }

		/// <summary>
		/// Gets the count of unknown cells.
		/// </summary>
		/// <value>Number of unknown cells</value>
		public uint CountUnknown { get { return (uint)cells.Count (cell => cell.IsUnknown); } }

		/// <summary>
		/// Gets the <see cref="Cell"/> at the specified column and row.
		/// </summary>
		/// <param name="column">Column</param>
		/// <param name="row">Row</param>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public Cell this [uint column, uint row] {
			get { 
				if (column >= Length)
					throw new IndexOutOfRangeException ("Column");
				if (row >= Length)
					throw new IndexOutOfRangeException ("Row");

				return cells [row + column * Length];
			}
		}
	}
}