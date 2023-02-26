using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MvcMovie.Models;
using Npgsql;
using System.Configuration;
using System.Data;

namespace MovieProject.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private string? connection;
        IConfiguration? configuration;

        public MovieRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("connstring");
        }

        public async Task<List<Movie>> SelectAllMovie()
        {
            using (var db = new SqlConnection(connection))
            {
                var result = await db.QueryAsync<Movie>(@"SELECT * FROM ""movie"";");
                return result.ToList();
            }
        }

        public async Task<bool> Insert(Movie movie)
        {
            using (var db = new SqlConnection(connection))
            {
                var result = await db.QueryAsync<Movie>(@"INSERT INTO ""movie""
                            (""title"", ""price"")
                            VALUES 
                            (@Title, @Price)
                            ;", movie);
                return true;
            }
        }

        public async Task<Movie?> GetById(int id)
        {
            using (var db = new SqlConnection(connection))
            {
                var result = await db.QueryAsync<Movie>($@"SELECT * FROM ""movie""
                            WHERE ""id"" = {id} ;");
                return result?.FirstOrDefault();
            }
        }

        public async Task<bool> Update(Movie movie)
        {
            using (var db = new SqlConnection(connection))
            {
                var result = await db.QueryAsync<Movie>($@"UPDATE ""movie""
                            SET ""title"" = @Title,
                                 
                                
                                ""price"" = @Price
                            WHERE ""id"" = @Id;", movie);

                return true;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var db = new SqlConnection(connection))
            {
                var result = await db.QueryAsync<Movie>($@"DELETE FROM ""movie""
                            WHERE ""id"" = {id};");

                return true;
            }
        }

        public async Task<List<Movie>> GetAllSearch(string search)
        {
            search = "%" + search + "%";

            using (var db = new SqlConnection(connection))
            {
                var result = await db.QueryAsync<Movie>(@"SELECT * FROM ""movie"" 
                WHERE ""title"" like @search ;", search);
                return result.ToList();
            }
        }




    }
}
