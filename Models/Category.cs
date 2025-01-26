using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Models
{
    public class Category
    {
        /// <summary>
        /// This is the primary key for the Category table => used with Byte
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // using Data Annotations
        public byte CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
    }
}
