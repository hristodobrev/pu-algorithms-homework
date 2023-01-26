using System;
using System.Collections.Generic;

namespace FRoomArea
{
/*
5
*****
**..*
*.*.*
*..**
*****
2 4
Answer: 3

8
********
**.....*
*.*....*
***...**
*.....**
*.....**
*.....**
********
2 4
Answer: 27
*/
    struct Point
    {
        public int x;
        public int y;
    }

    class Program
    {
        static List<Point> roomPoints = new List<Point>();

        static void Main()
        {
            int roomSize = int.Parse(Console.ReadLine());
            char[][] roomArray = new char[roomSize][];
            for (int i = 0; i < roomSize; i++)
            {
                roomArray[i] = Console.ReadLine().ToCharArray();
            }

            string[] coordinates = Console.ReadLine().Split(' ');
            int y = int.Parse(coordinates[0]) - 1;
            int x = int.Parse(coordinates[1]) - 1;

            CheckRoom(x, y, roomArray);
            Console.WriteLine($"Room Size: {roomPoints.Count}");
        }

        private static void CheckRoom(int x, int y, char[][] roomArray)
        {
            // If we reach * element or some of the coordinates are out of the matrix - return
            if (roomArray[y][x] == '*' || x < 0 || y < 0 || x >= roomArray.Length || y >= roomArray[x].Length)
                return;

            Point point = new Point { x = x, y = y };

            // If we already have that point (coordinate) in the room, return
            if (roomPoints.Contains(point))
                return;

            // Add the current point in the room
            roomPoints.Add(point);

            // Check all siblings
            CheckRoom(x - 1, y, roomArray); // Left
            CheckRoom(x, y - 1, roomArray); // Top
            CheckRoom(x + 1, y, roomArray); // Right
            CheckRoom(x, y + 1, roomArray); // Down
        }
    }
}
