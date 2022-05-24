using System.ComponentModel.DataAnnotations;

namespace MacabiSongsAPI.Models
{
    public class Song
    {
        [Key]
        public int _id { get; set; }
        public string title { get; set; } = string.Empty;
        public string words { get; set; } = string.Empty;
        public string subWords { get; set; }
        public string video { get; set; }
        public bool isSelected { get; set; }


    }
}
