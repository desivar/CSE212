using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
// Ensure the following `using` directive matches the namespace of your `FeatureCollection` file:
using YourNamespaceForFeatureCollection;

public static class SetsAndMaps
{
    private static readonly HttpClient HttpClient = new();

    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var wordSet = new HashSet<string>(words);

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (wordSet.Contains(reversed) && (word != reversed || wordSet.Count(x => x == word) > 1))
            {
                result.Add($"{word} & {reversed}");
                wordSet.Remove(word); // Avoid duplicates
                wordSet.Remove(reversed);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename, char delimiter = ',')
    {
        var degrees = new Dictionary<string, int>();

        try
        {
            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(delimiter);
                if (fields.Length > 3)
                {
                    var degree = fields[3].Trim();
                    if (!string.IsNullOrEmpty(degree))
                    {
                        degrees[degree] = degrees.GetValueOrDefault(degree) + 1;
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
        var charCounts = new Dictionary<char, int>();

        foreach (var c in word1.ToLower().Where(char.IsLetterOrDigit))
        {
            charCounts[c] = charCounts.GetValueOrDefault(c) + 1;
        }

        foreach (var c in word2.ToLower().Where(char.IsLetterOrDigit))
        {
            charCounts[c] = charCounts.GetValueOrDefault(c) - 1;
        }

        return charCounts.Values.All(count => count == 0);
    }

    public static async Task<string[]> EarthquakeDailySummaryAsync()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        try
        {
            var json = await HttpClient.GetStringAsync(uri);
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            if (featureCollection?.Features == null)
            {
                return Array.Empty<string>();
            }

            return featureCollection.Features
                .Where(f => f.Properties != null && !string.IsNullOrEmpty(f.Properties.Place))
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
