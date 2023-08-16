using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DapperEx.Model
{
    class AuthorsRepository : IRepository<Author>, IDisposable
    {
        SqlConnection connection = null;

        public AuthorsRepository()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        }
        public int Create(Author obj)
        {
            string sql = "INSERT INTO Authors(FirstName, LastName) VALUES (@FirstName, @LastName)";
            return connection.Execute(sql, obj);
        }

        public int Delete(Author obj)
        {
            string sql = "DELETE FROM Authors WHERE ID = @Id";
            return connection.Execute(sql, obj);
        }

        public void Dispose()
        {
            connection?.Dispose();
        }

        public IList<Author> GetAll()
        {
            string sql = "SELECT * FROM Authors";
            var authors = connection.Query<Author>(sql).ToList();
            return authors;
        }

        public Author GetById(int id)
        {
            string sql = "SELECT * FROM Authors WHERE Id = @Id";
            Author author = connection.QueryFirstOrDefault<Author>(sql, new { Id = id });
            return author;
        }

        public int Update(Author obj)
        {
            string sql = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";
            return connection.Execute(sql, obj);
        }

        
    }
}
