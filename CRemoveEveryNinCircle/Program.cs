using System;
using System.Collections.Generic;
using System.Linq;

namespace CRemoveEveryNinCircle
{
    class Program
    {
        static void Main()
        {
            // n - count of people
            // k - remove each k position from the circle until 1 is left
            // We can simulate the circle with list/array of n numbers. We can then start removing
            // each k element until the list contains only 1 number

            //List<int> nums = new List<int> { 1, 3, 7, 3, 9, 4, 5, 9 }; // 5
            //List<int> nums = new List<int> { 1, 3, 7 }; // 3
            List<int> nums = new List<int> { 1, 3, 7, 3, 5, 3, 9, 4, 5, 9, 5, 2 };
            // Initial Array - 1, 3, 7, 3, 5, 3, 9, 4, 5, 9, 5, 2
            // 1. Iteration - 1, 3, 3, 5, 9, 4, 9, 5 - we should remove 3 and 4, but then we should remove the first element, since the last one is the 2nd, while we need the 3rd which will be 1
            // 2. Iteration - 3, 5, 9, 9, 5 - we remove 9 and then 5 is again the 2nd and we should remove 3
            // 3. Iteration - 5, 9, 5 - here we remove 5
            // 4. Iteration - 5, 9 - and here we should remove 5, since 1st is 5, second is 9 and we reach the end and begin again at 5, so the last one is 9

            Console.WriteLine($"nums: {string.Join(", ", nums)}");
            int k = 3;
            int counter = 0;
            int currentIndex = 0;
            while (nums.Count() > 1)
            {
                // Keep counting endless, so we can check if the current iteration divides evenly on k
                counter++;

                // Check if we reached out the end of the array and reset the counter (this simulates counting in circle)
                if (currentIndex >= nums.Count())
                    currentIndex = 0;

                if (counter % k == 0)
                {
                    // When removing element, we use continue, since we don't want to increase the iteration index, as the array reduces its count with 1
                    nums.RemoveAt(currentIndex);
                    continue;
                }

                // Increase the iteration index
                currentIndex++;
            }

            Console.WriteLine($"lastNum: {string.Join(", ", nums)}");
        }
    }
}
