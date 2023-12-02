using System;

using AdventOfCodeSupport;

namespace AdventOfCode._2023;

public class Day01 : AdventBase
{
    protected override object InternalPart1()
    {
        int sum = 0;

        foreach (var line in Input.Lines)
        {
            int first = int.MinValue;
            int last = int.MinValue;

            int i = 0;
            for (; i < line.Length; i++)
            {
                if (line[i] is >= '0' and <= '9')
                {
                    first = last = line[i] - '0';
                    break;
                }
            }

            for (; i < line.Length; i++)
            {
                if (line[i] is >= '0' and <= '9')
                {
                    last = line[i] - '0';
                }
            }

            sum += (first * 10) + last;
        }

        return sum;
    }

    protected override object InternalPart2()
    {
        int sum = 0;

        foreach (var line in Input.Lines)
        {
            var span = line.AsSpan();

            int first = 0;
            int last = 0;
            while (!span.IsEmpty)
            {
                if (TryExtractDigit(span, out var digit))
                {
                    span = span[1..];
                    first = last = digit;
                    break;
                }

                span = span[1..];
            }

            while (!span.IsEmpty)
            {
                if (TryExtractDigit(span, out var digit))
                {
                    last = digit;
                }

                span = span[1..];
            }

            sum += (first * 10) + last;
        }

        return sum;
    }

    private static bool TryExtractDigit(ReadOnlySpan<char> s, out int digit)
    {
        (digit, bool result) = s switch
        {
            [>= '0' and <= '9' and var d, ..] => (d - '0', true),
            ['o', 'n', 'e', ..] => (1, true),
            ['t', 'w', 'o', ..] => (2, true),
            ['t', 'h', 'r', 'e', 'e', ..] => (3, true),
            ['f', 'o', 'u', 'r', ..] => (4, true),
            ['f', 'i', 'v', 'e', ..] => (5, true),
            ['s', 'i', 'x', ..] => (6, true),
            ['s', 'e', 'v', 'e', 'n', ..] => (7, true),
            ['e', 'i', 'g', 'h', 't', ..] => (8, true),
            ['n', 'i', 'n', 'e', ..] => (9, true),
            _ => (0, false),
        };
        return result;
    }
}