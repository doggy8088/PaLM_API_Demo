﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaLM_API_Demo.Results
{// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class TextCandidate
    {
        [JsonPropertyName("output")]
        public string Output { get; set; }

        [JsonPropertyName("safetyRatings")]
        public List<SafetyRating> SafetyRatings { get; set; }
    }

    public class TextResult
    {
        [JsonPropertyName("candidates")]
        public List<TextCandidate> Candidates { get; set; }
    }

    public class SafetyRating
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("probability")]
        public string Probability { get; set; }
    }
}
