using System;
using System.Linq;
using System.Collections.Generic;

namespace SudokuSolver
{
    /// <summary>
    /// Sudoku: Stores and solves Sudoku.
    /// </summary>
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
        public Sudoku(uint rank)
        {
            this.rank = rank;
            InitializeCells();
        }

        /// <summary>
        /// Initializes the cells.
        /// </summary>
        private void InitializeCells()
        {
            cells = new Cell[Count];

            for (uint index = 0U; index < Count; index++)
            {
                uint row = index % Length;
                uint column = (index - row) / Length;

                cells[index] = new Cell(this, column, row);
            }
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
        public uint CountUnknown { get { return (uint)cells.Count(cell => cell.IsUnknown); } }

        /// <summary>
        /// Gets the <see cref="Cell"/> at the specified column and row.
        /// </summary>
        /// <param name="column">Column</param>
        /// <param name="row">Row</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Cell this [uint column, uint row]
        {
            get
            { 
                if (column >= Length)
                    throw new IndexOutOfRangeException("Column");
                if (row >= Length)
                    throw new IndexOutOfRangeException("Row");

                return cells[row + column * Length];
            }
        }

        /// <summary>
        /// Returns an enumrable at the given column index.
        /// </summary>
        /// <param name="column">Column Index</param>
        public IEnumerable<Cell> Column(uint column)
        {
            return cells.Where((cell, index) => column == (index - index % Length) / Length);
        }

        /// <summary>
        /// Returns an enumrable at the given row index.
        /// </summary>
        /// <param name="row">Row Index</param>
        public IEnumerable<Cell> Row(uint row)
        {
            return cells.Where((cell, index) => row == index % Length);
        }

        /// <summary>
        /// Returns whether Sudoku is solved.
        /// </summary>
        /// <value><c>true</c> if this Sudoku is solved; otherwise, <c>false</c>.</value>
        public bool IsSolved { get { return cells.All(cell => !cell.IsUnknown); } }

        /// <summary>
        /// Solve the Sudoku.
        /// </summary>
        /// <param name="force">If set to <c>true</c>, resolve.</param>
        public void Solve(bool force)
        {
            bool anySolved = false;

            do
            {
                anySolved = false;
                foreach (Cell cell in cells)
                    anySolved |= cell.Solve(force);
            } while(anySolved);
        }
    }
}