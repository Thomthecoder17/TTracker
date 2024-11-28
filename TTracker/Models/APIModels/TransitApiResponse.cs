using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TTracker.Models.APIModels;

public class TransitApiResponse
{
    [JsonPropertyName("data")]
    public Data[] data { get; set; }
}

public class Data
{
    [JsonPropertyName("attributes")]
    public Attributes attributes { get; set; }
}

public class Attributes
{
    [JsonPropertyName ("arrival_time")]
    public DateTime arrival_time { get; set; }
    [JsonPropertyName("revenue")]
    public string revenue { get; set; }
}