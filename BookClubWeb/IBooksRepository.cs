using BookClubWeb.Models;

namespace BookClubWeb
{
    public interface IBooksRepository
    {
        public IEnumerable<Books> GetAllBooks();
        public Books GetBook(int id);
        public void UpdateBook(Books books);
    }
}
