using System;
using System.Collections.Generic;

namespace BRemoveSubsequentSumOf5
{
    class Program
    {
        static void Main()
        {
            //List<int> nums = new List<int> { 1, 2, 3, 2, 5, 0 };
            List<int> nums = new List<int> { 1, 3, 2, 1, 3, 4, 1, 1, 2 };
            Console.WriteLine($"initial values: {string.Join(", ", nums)}");

            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] + nums[i + 1] == 5)
                {
                    // Remove the current and next number. Since the list will reduce with 1 number, we can remove the element at the current index twice.
                    nums.RemoveAt(i);
                    nums.RemoveAt(i);

                    // Reduce the current index since we should continue the checks from the same index and the next loop will increase it.
                    i--;
                }
            }

            Console.WriteLine($"filtered list: {string.Join(", ", nums)}");
        }
    }
}
