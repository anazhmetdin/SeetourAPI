namespace SeetourAPI.Data.Models.Photos
{
    public class ReviewPhoto
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public virtual Photo? Photo { get; set; }
        public int ReviewId { get; set; }
        public virtual Review? Review { get; set; }
        public string Url { get => Photo?.Url??""; }
    }
}
