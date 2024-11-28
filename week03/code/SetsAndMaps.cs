using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

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

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

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
}

public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}

   
   
   
