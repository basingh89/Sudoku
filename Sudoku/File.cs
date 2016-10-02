﻿using System;
using System.IO;
using System.Linq;

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
            using (StreamReader reader = new StreamReader(path))
            {
                throw new NotImplementedException();
            }
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
