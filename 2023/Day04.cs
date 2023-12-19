using AdventOfCodeSupport;

namespace AdventOfCode._2023;

public class Day04 : AdventBase
{
    protected override object InternalPart1()
    {
        var winning = new HashSet<int>();
        int points = 0;
        for (var i = 0; i < Input.Span2D.Height; i++)
        {
            var line = Input.Span2D.GetRowSpan(i);
            var pipeIndex = line.IndexOf((byte)'|');
            GetWinningNumbers(line[(pipeIndex + 1)..], winning);

            winning.Clear();
        }
    }

    private static void GetWinningNumbers(ReadOnlySpan<byte> span, HashSet<int> winning)
    {
        var i = 0;
        while (span[i] == ' ')
        {
            i++;
        }

        var num = 0;
        while ()
    }

    protected override object InternalPart2()
    {
        throw new NotImplementedException();
    }
}