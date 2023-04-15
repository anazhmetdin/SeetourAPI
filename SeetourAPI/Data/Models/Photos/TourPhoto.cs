namespace SeetourAPI.Data.Models.Photos
{
    public class TourPhoto
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public virtual Photo? Photo { get; set; }
        public int TourId { get; set; }
        public virtual Tour? Tour { get; set; }
        public string Url { get => Photo?.Url ?? ""; }
    }
}
