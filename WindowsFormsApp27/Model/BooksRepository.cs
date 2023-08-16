using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEx.Model
{
    class BooksRepository : IRepository<Book>, IDisposable
    {
        SqlConnection connection = null;
        public BooksRepository()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        }
        public int Create(Book obj)
        {
            string sql = "INSERT INTO Books(Name, Pages, YearPress, Id_Press, Quantity) VALUES (@Name, @Pages, @YearPress, @Id_Press, @Quantity)";
            return connection.Execute(sql, obj);
        }

        public int Delete(Book obj)
        {
            string sql = "DELETE FROM Books WHERE ID = @Id";
            return connection.Execute(sql, obj);
        }

        public void Dispose()
        {
            connection?.Dispose();
        }

        public IList<Book> GetAll()
        {
            string sql = "SELECT * FROM Books";
            var books = connection.Query<Book>(sql).ToList();
            return books;
        }

        public Book GetById(int id)
        {
            string sql = "SELECT * FROM Books WHERE Id = @Id";
            Book book = connection.QueryFirstOrDefault<Book>(sql, new { Id = id });
            return book;
        }

        public int Update(Book obj)
        {
            string sql = "UPDATE Books SET Name = @Name, Pages = @Pages, YearPress = @YearPress, Id_Press = @Id_Press, Quantity = @Quantity WHERE Id = @Id";
            return connection.Execute(sql, obj);
        }
    }
}
