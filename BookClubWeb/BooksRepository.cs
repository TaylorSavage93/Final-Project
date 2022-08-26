using Dapper;
using LibraryInventoryWeb.Models;
using System.Data;

namespace LibraryInventoryWeb
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

        public Books GetBook(double id)
        {
            return _conn.QuerySingle<Books>("SELECT * FROM BOOKS WHERE ID = @id", new { id });
        }

        public void InsertBook(Books bookstoInsert)
        {
            _conn.Execute("INSERT INTO books (TITLE, ID, GENRE, AUTHOR, CATEGORYID, DESCRIPTION, INSTOCK) VALUES (@title, @id, @genre, @author, @categoryid, @description, @instock);", new { bookstoInsert.Title, author = bookstoInsert.Author, genre = bookstoInsert.Genre, id = bookstoInsert.Id, bookstoInsert.CategoryId, bookstoInsert.Description, bookstoInsert.InStock });

        }
        public void DeleteBook(Books books)
        {
            _conn.Execute("DELETE FROM BOOKS WHERE ID = @id;", new { id = books.Id });
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
            _conn.Execute("UPDATE books SET Title = @title, author = @author, Genre = @Genre, InStock = @instock WHERE Id = @Id", new { title = books.Title, author = books.Author, books.Genre, books.Id, books.InStock });
        }


    }
}
