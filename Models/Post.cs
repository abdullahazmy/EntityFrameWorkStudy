namespace EFCore2.Models
{
    //[Table("Posts")]  

    /// <summary>
    /// This changes the table name to Posts using Data Annotations
    /// </summary>
    /// 

    //[Table("Posts", Schema = "Blogging")]     || This Data Annotation changes the table name to Posts and the schema to Blogging
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
