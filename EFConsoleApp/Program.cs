using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusicContext())
            {
                var count = context.Albums.Count();

                Console.WriteLine(count);

                //context.Albums.Add(new Album() { Title = "Starboy", Price = 14.99m});
                //context.Albums.Add(new Album() { Title = "Thriller", Price = 9.99m });
                //context.SaveChanges();

                //count = context.Albums.Count();
                //Console.WriteLine(count);

                var album = context.Albums
                    .Where(o => o.Title.Contains("Thriller")).ToList();
                Console.WriteLine(album.Count());

                Console.ReadLine();
            }
        }
    }

    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public class MusicContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
    }

}
