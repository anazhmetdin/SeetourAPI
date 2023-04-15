using System.Text.Json.Serialization;

namespace SeetourAPI.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TourGuideStatus
    {
        Applied, Rejected, Accepted, Blocked
    }
}
