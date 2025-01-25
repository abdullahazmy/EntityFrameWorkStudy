namespace EFCore2.Models
{
    public class Blog
    {
        public int BlogId { get; set; }


        // This changes the column name to BlogUrl using Data Annotations
        //[Column("BlogUrl")]

        // This changes the data type of the column to varchar(150) using Data Annotations
        // [Column(TypeName = "varchar(150)")]
        // This also
        //[MaxLength(150)]
        public string Url { get; set; }

        //[Comment("This is a comment in the database, behind Posts")]
        public List<Post> Posts { get; set; }
    }
}
