using System.ComponentModel.DataAnnotations;

namespace BookClubWeb.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
    }
}
