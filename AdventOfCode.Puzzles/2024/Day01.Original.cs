namespace AdventOfCode.Puzzles._2024;

[Puzzle(2024, 01, CodeType.Original)]
public class Day01Original : IPuzzle
{
	public (string, string) Solve(PuzzleInput input)
	{
		var part2 = string.Empty;

		return (Part1(input), part2);
	}

	private string Part1(PuzzleInput input)
	{
		List<int> left = [];
		List<int> right = [];

		foreach (var line in input.Lines)
		{
			var pieces = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
			left.Add(int.Parse(pieces[0]));
			right.Add(int.Parse(pieces[1]));
		}

		left.Sort();
		right.Sort();

		var sum = 0;

		for (var i = 0; i < input.Lines.Length; i++)
		{
			sum += Math.Abs(left[i] - right[i]);
		}

		return sum.ToString();
	}
}
