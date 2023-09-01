using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaLM_API_Demo.Results
{
    public class Embedding
    {
        [JsonPropertyName("value")]
        public List<double> Values { get; set; }
    }

    public class EmbeddingResult
    {
        [JsonPropertyName("embedding")]
        public Embedding Embedding { get; set; }
    }
}
