using System;
using System.Collections.Generic;

namespace EBracketsChecker
{
    class Program
    {
        static void Main()
        {
            // ()()))((

            string invalid = "()()))((";
            string valid = "(())()(()())";

            checkValidBracketsAndWarn(invalid);
            checkValidBracketsAndWarn(valid);
            checkValidBracketsAndWarn("()())(");
            checkValidBracketsAndWarn("(()((()))(()))");
            checkValidBracketsAndWarn(")(())))((()))(())(()(");
        }

        private static void checkValidBracketsAndWarn(string text)
        {
            Stack<int> bracketsStack = new Stack<int>();
            int closingBracketsCount = 0; // ')'
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    bracketsStack.Push(1);
                }
                else if (bracketsStack.Count == 0)
                {
                    // This time we don't return, but just increase the closing brackets count,
                    // so we can warn the user to remove them to acomplish valid expression
                    closingBracketsCount++;
                }
                else
                {
                    bracketsStack.Pop();
                }
            }

            if (closingBracketsCount > 0 || bracketsStack.Count > 0)
            {
                Console.WriteLine($"Invalid Expression '{text}'");
                Console.WriteLine($"Remove {bracketsStack.Count} '(' to achieve correct expression"); // What remains in stack is what the user should remove as opening brackets
                Console.WriteLine($"Remove {closingBracketsCount} ')' to achieve correct expression");
            }
            else
            {
                Console.WriteLine($"Expression '{text}' is valid!");
            }

            Console.WriteLine();
        }

        private static bool checkValidBrackets(string text)
        {
            // Use stack to push some number (1 for example) for each '('
            // Then pop an element when reaching out ')'
            Stack<int> bracketsStack = new Stack<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    bracketsStack.Push(1);
                }
                else if (bracketsStack.Count == 0)
                {
                    // If we encounter ')' and the stack is empty, this means that we have incorrect syntax
                    return false;
                }
                else
                {
                    // Pop out an element if the stack is not empty
                    bracketsStack.Pop();
                }
            }

            // At the end we should have empty stack, because if we have '()(' we will not return false,
            // but will have one element in the stack which will means that we have unclosed bracket
            return bracketsStack.Count == 0;
        }
    }
}
