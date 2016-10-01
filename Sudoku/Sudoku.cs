using System;

namespace SudokuSolver
{
	public class Sudoku
	{
		/// <summary>
		/// Stores the rank of the <see cref="Sudoku"/>.
		/// </summary>
		private readonly uint rank;

		/// <summary>
		/// Initializes a new instance of the <see cref="Sudoku"/> class.
		/// </summary>
		/// <param name="rank">Rank</param>
		public Sudoku (uint rank)
		{
			this.rank = rank;
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
	}
}