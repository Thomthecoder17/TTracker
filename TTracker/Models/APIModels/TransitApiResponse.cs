using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TTracker.Models.APIModels;

public class TransitApiResponse
{
    [JsonPropertyName("data")]
    [AllowNull]
    public Data[] Data { get; set; }
}

public class Data
{
    [JsonPropertyName("attributes")]
    [AllowNull]
    public Attributes Attributes { get; set; }
}

public class Attributes
{
    [JsonPropertyName ("arrival_time")]
    [AllowNull]
    public DateTime Arrival_time { get; set; }

    [JsonPropertyName("direction_id")]
    [AllowNull]
    public int Direction_id { get; set; }

    [JsonPropertyName("revenue")]
    [AllowNull]
    public string Revenue { get; set; }
}