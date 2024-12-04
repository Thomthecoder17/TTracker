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
    public Data[] Data { get; set; }
}

public class Data
{
    [JsonPropertyName("attributes")]
    public Attributes Attributes { get; set; }
}

public class Attributes
{
    [JsonPropertyName("arrival_time")]
    public DateTime Arrival_time { get; set; }

    [JsonPropertyName("direction_id")]
    public int Direction_id { get; set; }
}