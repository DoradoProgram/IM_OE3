using Dapper;
using Microsoft.Data.SqlClient;
using LoginApp.Api.Models;

namespace LoginApp.Api.Data
{
    public class UserRepository
    {
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration config) => _config = config;

        public async Task<UserRecord> GetByUsernameAsync(string username)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            string sql = "SELECT * FROM Users WHERE Username = @Username";
            return await conn.QueryFirstOrDefaultAsync<UserRecord>(sql, new { Username = username});
        }
    }
}
