using System.ComponentModel.DataAnnotations;

namespace BookClubWeb.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
