using System.ComponentModel.DataAnnotations;

namespace EFCore2.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string Bio { get; set; }

        [MaxLength(200)]
        public string DisplayName { get; set; }
    }
}
