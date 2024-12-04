using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var wordSet = new HashSet<string>(words);

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (wordSet.Contains(reversed) && word != reversed)
            {
                result.Add($"{word} & {reversed}");
                wordSet.Remove(word); // Avoid duplicates
                wordSet.Remove(reversed);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        try
        {
            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(',');
                if (fields.Length > 3)
                {
                    var degree = fields[3].Trim();
                    if (degrees.ContainsKey(degree))
                    {
                        degrees[degree]++;
                    }
                    else
                    {
                        degrees[degree] = 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        var cleanWord1 = new string(word1.ToLower().Where(char.IsLetterOrDigit).ToArray());
        var cleanWord2 = new string(word2.ToLower().Where(char.IsLetterOrDigit).ToArray());

        var charCount1 = cleanWord1.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        var charCount2 = cleanWord2.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

        return charCount1.Count == charCount2.Count && charCount1.All(kvp => charCount2.TryGetValue(kvp.Key, out var count) && count == kvp.Value);
    }

    public static async Task<string[]> EarthquakeDailySummaryAsync()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        try
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync(uri);
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            if (featureCollection?.Features == null)
            {
                return Array.Empty<string>();
            }

            return featureCollection.Features
                .Where(f => f.Properties != null)
                .Select(f => $"Location: {f.Properties.Place}, Magnitude: {f.Properties.Mag}")
                .ToArray();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
            return Array.Empty<string>();
        }
    }
}

// Entry point for running the code
public static class Program
{
    public static async Task Main(string[] args)
    {
        // Example usage of FindPairs
        string[] words = { "am", "at", "ma", "if", "fi" };
        string[] pairs = SetsAndMaps.FindPairs(words);
        Console.WriteLine("Found pairs:");
        foreach (string pair in pairs)
        {
            Console.WriteLine(pair);
        }

        // Example usage of SummarizeDegrees
        var degreesSummary = SetsAndMaps.SummarizeDegrees("degrees.csv");
        Console.WriteLine("Degree summary:");
        foreach (var entry in degreesSummary)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

        // Example usage of EarthquakeDailySummaryAsync
        var earthquakeSummary = await SetsAndMaps.EarthquakeDailySummaryAsync();
        Console.WriteLine("Earthquake summary:");
        foreach (string summary in earthquakeSummary)
        {
            Console.WriteLine(summary);
        }
    }
}

       

   
