
using BenchmarkDotNet.Running;
using TestConsole;
using TestConsole.HashBasedLookup;
using FirstNonRepeatingCharacter = TestConsole.HashBasedLookup.FirstNonRepeatingCharacter;
using LongestSubstring = TestConsole.HashBasedLookup.LongestSubstring;

Console.WriteLine("Running...");
Console.WriteLine($"{Environment.NewLine}Finished");

//BenchmarkRunner.Run<FirstNonRepeatingBenchmarks>();