using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.ConsoleApp
{
    public class SudokuSolutionValidator
    {
        private const int BoardSize = 9; 
        
        public static bool ValidateSolution(int[][] board)
        {
            return RowsValid(board) && ColumnsValid(board) && SubGridsValid(board);
        }

        private static bool SubGridsValid(int[][] board)
        {
            bool allValid = true;
            int subGridSize = BoardSize / 3;
            for (int rowIndex = 0; rowIndex < subGridSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < subGridSize; columnIndex++)
                {
                    int rowLowerIndex = rowIndex * subGridSize;
                    int columnLowerIndex = columnIndex * subGridSize;
                
                    var values = 
                        Enumerable.Range(rowLowerIndex, subGridSize)
                            .SelectMany(ri => Enumerable.Range(columnLowerIndex, subGridSize)
                                .Select(ci => board[ri][ci]).ToList()).ToList();

                    if (!IsSetValid(values))
                    {
                        allValid = false;
                        break;
                    }
                }
            }

            return allValid;
        }

        private static bool RowsValid(int[][] board)
        {
            var rowValues = 
                Enumerable.Range(0, BoardSize)
                    .Select(rowIndex => Enumerable.Range(0, BoardSize)
                        .Select(columnIndex => board[rowIndex][columnIndex]).ToList()).ToList();

            return rowValues.All(IsSetValid);
        }
        
        private static bool ColumnsValid(int[][] board)
        {
            var columnValues = 
                Enumerable.Range(0, BoardSize)
                    .Select(columnIndex => Enumerable.Range(0, BoardSize)
                        .Select(rowIndex => board[rowIndex][columnIndex]).ToList()).ToList();

            return columnValues.All(IsSetValid);
        }

        private static bool IsSetValid(List<int> set)
        {
            var doesNotContainZero = !set.Contains(0);
            var containsAllValues = Enumerable.Range(1, BoardSize).Select(set.Contains).All(pred => pred);
            return doesNotContainZero && containsAllValues;
        }
    }
}