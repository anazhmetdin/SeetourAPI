using System.Text.Json.Serialization;

namespace SeetourAPI.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BookedTourStatus
    {
        Cart, Booked, Completed, Cancelled
    }
}
