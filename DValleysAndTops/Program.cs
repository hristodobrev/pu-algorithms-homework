using System;
using System.Collections.Generic;

namespace DValleysAndTops
{
    class Program
    {
        static void Main()
        {
            //string input = @"/\-/-\/\-/"; // 2 tops, 1 plateau, 3 valleys
            //string input = @"/---\/\/---\---/\--/--\"; // 2 tops, 3 plateau, 4 valleys
            string input = Console.ReadLine();

            // /\     - top
            // /-\    - plateau
            // \/ \-/ - valley

            int tops = 0;
            int plateaus = 0;
            int valleys = 0;
            // Let us keep the current element's symbols in a queue (top, valley or plateau)
            // if we reach out / or \, this means either we start a new element or we reach end of one
            Queue<char> currentElement = new Queue<char>();
            for (int i = 0; i < input.Length; i++)
            {
                currentElement.Enqueue(input[i]); // push each element in the queue

                // If we reach out / and the first element was \ this means we have found a valley
                if (input[i] == '/' && currentElement.Peek() == '\\')
                {
                    valleys++;
                    currentElement.Clear();
                    // When we clear the current element add the current symbol in the queue,
                    // since, the last symbol of an element is the first symbol of the next element
                    currentElement.Enqueue(input[i]);
                }

                // If we reach out \ and the first element was / this means we have either
                // reached a top or plateau
                if (input[i] == '\\' && currentElement.Peek() == '/')
                {
                    // We can simply check if the queue count is more than 2, then we have
                    // found a plateau, otherwise we have found a top
                    if (currentElement.Count > 2)
                    {
                        plateaus++;
                    }
                    else
                    {
                        tops++;
                    }

                    currentElement.Clear();
                    // When we clear the current element add the current symbol in the queue,
                    // since, the last symbol of an element is the first symbol of the next element
                    currentElement.Enqueue(input[i]);
                }
            }

            Console.WriteLine($"Tops - {tops}");
            Console.WriteLine($"Plateaus - {plateaus}");
            Console.WriteLine($"Valleys - {valleys}");
        }
    }
}
