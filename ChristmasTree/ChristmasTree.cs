
namespace BenScr.ChristmasTree
{
    using static Utility;

    public static class ChristmasTree
    {
        public static void RunShiningTree(int height = 14, int sparkleCount = 80, int ledUpdateDelayMs = 120, int iterations = 400, int seed = 0)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var rng = (seed == 0) ? new Random() : new Random(seed);

            int treeWidth = height * 2 - 1;
            int startLeft = Math.Max(0, (Console.WindowWidth - treeWidth) / 2);
            int startTop = Math.Max(0, (Console.WindowHeight - (height + 4)) / 2);

            var leds = BuildTreeLedPositions(height, startLeft, startTop);

            Console.Clear();
            DrawTreeSkeleton(height, startLeft, startTop);
            DrawTrunk(height, startLeft, startTop);

            for (int i = 0; i < iterations; i++)
            {
                for (int s = 0; s < sparkleCount; s++)
                {
                    var p = leds[rng.Next(leds.Count)];
                    var color = RandomLedColor(rng);

                    Console.SetCursorPosition(p.Left, p.Top);
                    Console.ForegroundColor = color;
                    Console.Write('*');
                }

                Thread.Sleep(ledUpdateDelayMs);
            }

            Console.ResetColor();
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, Math.Min(Console.WindowHeight - 1, startTop + height + 5));
        }
    }
}
