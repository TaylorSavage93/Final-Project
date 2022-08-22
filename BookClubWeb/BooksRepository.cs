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

        public void InsertBook(Books bookstoInsert)
        {
            _conn.Execute("INSERT INTO books (TITLE, ID, GENRE, AUTHOR, CATEGORYID) VALUES (@title, @id, @genre, @author, @categoryid);", new { Title = bookstoInsert.Title, author = bookstoInsert.Author, genre = bookstoInsert.Genre, id = bookstoInsert.Id, bookstoInsert.CategoryId });

        }
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }
        public Books AssignCategory()
        {
            var categoryList = GetCategories();
            var books = new Books();
            books.Categories = categoryList;
            return books;
        }

        public void UpdateBook(Books books)
        {
            _conn.Execute("UPDATE books SET Title = @title, author = @author, Genre = @Genre WHERE Id = @Id", new { title = books.Title, author = books.Author, Genre = books.Genre, books.Id });
        }
    }
}
