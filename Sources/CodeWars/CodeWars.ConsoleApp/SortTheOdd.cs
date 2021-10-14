using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.ConsoleApp
{
    public class SortTheOdd
    {
        public static int[] SortArray(int[] array)
        {
            var odds = array.Where(num => num % 2 == 1).OrderBy(num => num).ToArray();
            int oddIndex = 0;

            array = array.Select(arrayItem => arrayItem % 2 != 0 ? odds[oddIndex++] : arrayItem).ToArray();
            return array;
        }
    }
}