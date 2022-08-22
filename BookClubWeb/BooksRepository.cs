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
    }
}
