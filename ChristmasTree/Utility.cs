
namespace BenScr.ChristmasTree
{
    internal static class Utility
    {
        internal static void DrawTreeSkeleton(int height, int left, int top)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            for (int row = 0; row < height; row++)
            {
                int stars = row * 2 + 1;
                int rowLeft = left + (height - 1 - row);

                Console.SetCursorPosition(rowLeft, top + row);
                Console.Write(new string('*', stars));
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(left + (height - 1), top - 1);
            Console.Write('★');

            Console.ResetColor();
        }

        internal static void DrawTrunk(int height, int left, int top)
        {
            int trunkWidth = Math.Max(3, height / 3);
            if (trunkWidth % 2 == 0) trunkWidth++;
            int trunkHeight = Math.Max(2, height / 4);

            int trunkLeft = left + (height - 1) - (trunkWidth / 2);
            int trunkTop = top + height;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int r = 0; r < trunkHeight; r++)
            {
                Console.SetCursorPosition(trunkLeft, trunkTop + r);
                Console.Write(new string('|', trunkWidth));
            }
            Console.ResetColor();
        }

        internal static List<(int Left, int Top)> BuildTreeLedPositions(int height, int left, int top)
        {
            var list = new List<(int Left, int Top)>(height * height);

            for (int row = 0; row < height; row++)
            {
                int stars = row * 2 + 1;
                int rowLeft = left + (height - 1 - row);
                int rowTop = top + row;

                for (int col = 0; col < stars; col++)
                    list.Add((rowLeft + col, rowTop));
            }

            return list;
        }

        internal static ConsoleColor RandomLedColor(Random rng)
        {
            ConsoleColor[] palette =
            {
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.White
        };

            return palette[rng.Next(palette.Length)];
        }
    }
}
