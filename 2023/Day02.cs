using AdventOfCodeSupport;

namespace AdventOfCode._2023;

public class Day02 : AdventBase
{
    protected override object InternalPart1()
    {
        const int redLimit = 12;
        const int greenLimit = 13;
        const int blueLimit = 14;

        int idSum = 0;
        foreach (string line in Input.Lines)
        {
            (int id, int red, int green, int blue) = ParseGame(line);
            if (red <= redLimit && green <= greenLimit && blue <= blueLimit)
            {
                idSum += id;
            }
        }

        return idSum;
    }

    private static (int Id, int MaxRed, int MaxGreen, int MaxBlue) ParseGame(ReadOnlySpan<char> line)
    {
        int maxRed = int.MinValue;
        int maxGreen = int.MinValue;
        int maxBlue = int.MinValue;

        int spaceIndex = line.IndexOf(' ');
        int colonIndex = line.IndexOf(':');

        ReadOnlySpan<char> idSpan = line[(spaceIndex + 1)..colonIndex];
        int id = int.Parse(idSpan);
        line = line[(colonIndex + 1)..];
        while (!line.IsEmpty)
        {
            int index = line.IndexOf(';');
            int red;
            int green;
            int blue;
            if (index < 0)
            {
                (red, green, blue) = ParsePart(line);
                line = ReadOnlySpan<char>.Empty;
            }
            else
            {
                (red, green, blue) = ParsePart(line[..index]);
                line = line[(index + 1)..];
            }
            maxRed = Math.Max(maxRed, red);
            maxGreen = Math.Max(maxGreen, green);
            maxBlue = Math.Max(maxBlue, blue);
        }

        return (id, maxRed, maxGreen, maxBlue);
    }

    private static (int Red, int Green, int Blue) ParsePart(ReadOnlySpan<char> s)
    {
        int red = 0;
        int green = 0;
        int blue = 0;
        Span<Range> ranges = stackalloc Range[3];
        int count = s.Split(ranges, ',', StringSplitOptions.TrimEntries);

        foreach (Range range in ranges[..count])
        {
            switch (s[range])
            {
                case [.. var number, ' ', 'r', 'e', 'd']:
                    red = int.Parse(number);
                    break;
                case [.. var number, ' ', 'g', 'r', 'e', 'e', 'n']:
                    green = int.Parse(number);
                    break;
                case [.. var number, ' ', 'b', 'l', 'u', 'e']:
                    blue = int.Parse(number);
                    break;
            }
        }

        return (red, green, blue);
    }

    protected override object InternalPart2()
    {
        throw new NotImplementedException();
    }
}