using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Finds symmetric pairs of words in O(n) time using sets.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var set = new HashSet<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (set.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            else
            {
                set.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Summarizes degrees from a file into a dictionary.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length < 4) continue;

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

        return degrees;
    }

    /// <summary>
    /// Determines if two words are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string Normalize(string word) =>
            new string(word.ToLower().Where(char.IsLetter).OrderBy(c => c).ToArray());

        return Normalize(word1) == Normalize(word2);
    }

    /// <summary>
    /// Reads earthquake JSON data and returns a summary of locations and magnitudes.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var response = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(response, options);

        if (featureCollection?.Features == null) return Array.Empty<string>();

        return featureCollection.Features
            .Where(f => f.Properties.Mag.HasValue)
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag:F2}")
            .ToArray();
    }
}

/// <summary>
/// Represents the structure of the earthquake JSON data.
/// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public FeatureProperties Properties { get; set; }
}

public class FeatureProperties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}
    
