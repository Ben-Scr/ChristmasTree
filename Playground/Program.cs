
using BenScr.ChristmasTree;

static class Program
{
    static void Main()
    {
        ChristmasTree.RunShiningTree(height: 16, sparkleCount: 15, ledUpdateDelayMs: 120, iterations: 600);
    }
}