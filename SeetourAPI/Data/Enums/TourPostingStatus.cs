using System.Text.Json.Serialization;

namespace SeetourAPI.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TourPostingStatus
    {
        Pending, Accepted, Rejected, EditRequested
    }
}
