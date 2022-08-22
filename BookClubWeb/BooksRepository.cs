using BookClubWeb.Models;
using Dapper;
using System.Data;

namespace BookClubWeb
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IDbConnection _conn;
        public BooksRepository(IDbConnection conn)
        {
            _conn = conn;
        }       
        public IEnumerable<Books> GetAllBooks()
        {
            return _conn.Query<Books>("SELECT * FROM BOOKS;");
        }

        public Books GetBook(int id)
        {
            return _conn.QuerySingle<Books>("SELECT * FROM BOOKS WHERE ID = @id", new { id = id });
        }

        public void UpdateBook(Books books)
        {
            _conn.Execute("UPDATE books SET Title = @title, author = @author, Genre = @Genre WHERE Id = @Id", new { title = books.Title, author = books.Author, Genre = books.Genre });
        }
    }
}
