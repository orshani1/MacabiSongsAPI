using System.ComponentModel.DataAnnotations;

namespace MacabiSongsAPI.Models
{
    public class User
    {
        [Key]
        public int _id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

        public bool isAdmin { get; set; }
    }
}
