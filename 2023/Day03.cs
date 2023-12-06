using AdventOfCodeSupport;

using CommunityToolkit.HighPerformance;

namespace AdventOfCode._2023;

public class Day03 : AdventBase
{
    protected override object InternalPart1()
    {
        int sum = 0;
        ReadOnlySpan2D<byte> span2D = Input.Span2D;
        for (int row = 0; row < span2D.Height; row++)
        {
            ReadOnlySpan<byte> line = span2D.GetRowSpan(row);
            int prefix = 0;
            while (TryFindNumberRange(line, prefix, out int start, out int end))
            {
                ReadOnlySpan2D<byte> searchSpace = GetSymbolSearchSpace(span2D, row, start, end);
                foreach (byte b in searchSpace)
                {
                    if (b is not (byte)'.' and (< (byte)'0' or > (byte)'9'))
                    {
                        sum += int.Parse(line[start..end]);
                        break;
                    }
                }
                prefix = end;
            }
        }

        return sum;
    }

    private static bool TryFindNumberRange(ReadOnlySpan<byte> span, int prefix, out int start, out int end)
    {
        start = span[prefix..].IndexOfAnyInRange((byte)'0', (byte)'9');
        if (start is -1)
        {
            end = 0;
            return false;
        }

        start += prefix;

        end = span[start..].IndexOfAnyExceptInRange((byte)'0', (byte)'9') switch
        {
            -1 => span.Length,
            var i => i + start,
        };
        return true;
    }

    private static ReadOnlySpan2D<byte> GetSymbolSearchSpace(ReadOnlySpan2D<byte> span2D, int numberRow, int numberStartCol, int numberEndCol)
    {
        int rowMax = span2D.Width - 1;
        int colMax = span2D.Height;

        int row = numberRow switch
        {
            0 => 0,
            _ => numberRow - 1,
        };

        int col = numberStartCol switch
        {
            0 => 0,
            _ => numberStartCol - 1,
        };

        int height = numberRow switch
        {
            0 => 2,
            _ when numberRow == rowMax => 2,
            _ => 3,
        };

        int numberWidth = numberEndCol - numberStartCol;
        int width = (numberStartCol, colMax - numberEndCol) switch
        {
            // 1234
            (0, 0) => numberWidth,
            // .123 or 123.
            (> 0, 0) or (0, > 0) => numberWidth + 1,
            // .12. and others
            _ => numberWidth + 2,
        };

        return span2D.Slice(row, col, height, width);
    }

    protected override object InternalPart2()
    {
        throw new NotImplementedException();
    }
}