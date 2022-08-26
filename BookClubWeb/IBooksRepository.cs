using LibraryInventoryWeb.Models;

namespace LibraryInventoryWeb
{
    public interface IBooksRepository
    {
        public IEnumerable<Books> GetAllBooks();
        public Books GetBook(double id);
        public void UpdateBook(Books books);
        public void InsertBook(Books bookstoInsert);
        public void DeleteBook(Books books);
        public IEnumerable<Category> GetCategories();
        public Books AssignCategory();

    }
}
