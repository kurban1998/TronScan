using System.Text.Json.Serialization;

namespace TronScan.Models
{
    public sealed class TransactionData
    {
        [JsonPropertyName("hash")]
        public string Hash { get; init; }

        [JsonPropertyName("riskTransaction")]
        public bool IsRisk { get; init; }

        // можно добавить оставльные свойства
    }
}
