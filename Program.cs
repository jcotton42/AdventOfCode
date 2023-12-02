// https://github.com/Zaneris/AdventOfCodeSupport/tree/main#adventofcodesupport
using AdventOfCodeSupport;

var solutions = new AdventSolutions();
var day = solutions.GetMostRecentDay();
// await day.DownloadInputAsync();
// var day3 = solutions.GetDay(2023, 3);
// var day4 = solutions.First(x => x.Year == 2023 && x.Day == 4);
day.Part1();
day.Part2();
day.Benchmark();