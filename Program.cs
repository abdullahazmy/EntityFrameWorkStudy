using EFCore2.Models;

namespace EFCore2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();

            var blog = new Blog { Url = "https://www.google.com" };
            _context.Blogs.Add(blog);

            _context.SaveChanges();
        }
    }
}
