using System.Text.Json.Serialization;

namespace NearEarthObjects.Models
{
    public class NearEarthObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardous { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameter Diameter { get; set; } = new EstimatedDiameter();

        [JsonPropertyName("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; } = new List<CloseApproachData>();
    }

    public class EstimatedDiameter
    {
        [JsonPropertyName("kilometers")]
        public Diameter Kilometers { get; set; }
    }

    public class Diameter
    {
        public MinMax Kilometers { get; set; } = new MinMax();
    }

    public class MinMax
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }

    public class CloseApproachData
    {
        [JsonPropertyName("close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocity Velocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistance MissDistance { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonPropertyName("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }
    }

    public class MissDistance
    {
        [JsonPropertyName("kilometers")]
        public string Kilometers { get; set; }
    }
}