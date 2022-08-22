using BookClubWeb.Models;

namespace BookClubWeb
{
    public interface IBooksRepository
    {
        public IEnumerable<Books> GetAllBooks();
    }
}
