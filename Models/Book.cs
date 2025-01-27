namespace EFCore2.Models
{
    public class Book
    {
        // This is the primary key using Data Annotations
        //[Key]
        public int BookKey { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }

    }
}
