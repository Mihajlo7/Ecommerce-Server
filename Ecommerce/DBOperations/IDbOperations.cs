using Microsoft.Data.SqlClient;
using Generic.Models;
using Microsoft.EntityFrameworkCore;

namespace DBOperations
{
    public interface IDbOperations<TDbContext> where TDbContext: DbContext
    {
        Task<IList<T>> GetAllAsync<T>(string sql);
        Task<IList<T>> GetAllAsync<T>(string sql, params object[] parameters);
        Task<T> GetAsync<T>(string sql, params object[] parameters);
        Task<int> CreateAsync(string sql,bool output=false,params object[] parameters);
        Task<T> CreateAsync<T>(string sql, bool output = false, params object[] parameters);
        Task<int> UpdateAsync(string sql, bool output = false, params object[] parameters);
        Task<bool> DeleteAsync(string sql, bool output = false, params object[] parameters);
        //protected string GenerateSqlQuery(string sql, SqlParameter[] parameters, bool output = false);
    }
}
