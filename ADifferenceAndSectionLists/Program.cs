using System;
using System.Collections.Generic;

namespace ADifferenceAndSectionLists
{
    class Program
    {
        static void Main()
        {
            List<int> list1 = new List<int> { 3, 7, 1, 5, 6, 3 };
            List<int> list2 = new List<int> { 6, 3, 2, 9 };

            List<int> differenceList = new List<int>();
            // Add all numbers from the first list distincted which are not contained in the second list
            foreach (int num in list1)
                if (!list2.Contains(num) && !differenceList.Contains(num))
                    differenceList.Add(num);

            // Add all numbers from the second list distincted if they are not already contained in the differenceList and in the first list
            foreach (int num in list2)
                if (!list1.Contains(num) && !differenceList.Contains(num))
                    differenceList.Add(num);

            List<int> sectionList = new List<int>();
            // Each number from list 1 which is not contained in the differenceList should be added to the sectionList
            foreach (int num in list1)
                if (!differenceList.Contains(num) && !sectionList.Contains(num))
                    sectionList.Add(num);

            // Each number from list 2 which is not contained in the differenceList should be added to the sectionList as well
            foreach (int num in list2)
                if (!differenceList.Contains(num) && !sectionList.Contains(num))
                    sectionList.Add(num);

            Console.WriteLine($"list1: {string.Join(", ", list1)}");
            Console.WriteLine($"list2: {string.Join(", ", list2)}");
            Console.WriteLine($"difference list: {string.Join(", ", differenceList)}");
            Console.WriteLine($"section list: {string.Join(", ", sectionList)}");
        }
    }
}
