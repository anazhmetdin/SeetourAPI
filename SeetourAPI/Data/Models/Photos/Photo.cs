using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeetourAPI.Data.Models.Photos
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        [DataType(DataType.ImageUrl)]
        [StringLength(512)]
        // TODO: use all photos in thumbnail gallery
        public string Url { get; set; } = string.Empty;
    }
}
