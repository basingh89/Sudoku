using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SudokuSolver
{
    /// <summary>
    /// Utitilies to read from and write to a file.
    /// </summary>
    public static class File
    {
        /// <summary>
        /// Read from a file.
        /// </summary>
        /// <param name="path">File Path</param>
        /// <exception cref="IOException"></exception>
        static Sudoku Read(string path)
        {
            List<uint[]> rows = new List<uint[]>();

            using (StreamReader reader = new StreamReader(path))
            {
                int index = 0;
                while (!reader.EndOfStream)
                    rows[index++] = reader.ReadLine().Split(',').Select(str => uint.Parse(str)).ToArray();
            }

            if (rows.Count == 0)
                throw new ArgumentException("File is empty");


            // get Rank
            uint rank = 0;
            for (uint tryRank = 0U; tryRank * tryRank <= rows.Count; tryRank++)
                if (tryRank * tryRank == rows.Count)
                {
                    rank = tryRank;
                    break;
                }

            if (rank == 0)
                throw new ArgumentException("Invalid rank");

            Sudoku sudoku = new Sudoku(rank);

            // try to copy data.
            for (uint row = 0U; row < sudoku.Length; row++)
                for (uint column = 0U; column < sudoku.Length; column++)
                    sudoku[column, row].Value = rows[(int)row][column];

            return sudoku;
        }

        /// <summary>
        /// Write the Sudoku to the given path.
        /// </summary>
        /// <param name="path">File Path</param>
        /// <param name="sudoku">Sudoku</param>
        /// <exception cref="IOException"></exception>
        static void Write(string path, Sudoku sudoku)
        {
            using (StreamWriter writer = new StreamWriter(path))
                for (uint row = 0U; row < sudoku.Length; row++)
                    writer.WriteLine(string.Join(",", sudoku.Row(row).Select(cell => cell.Value)));
        }
    }
}
