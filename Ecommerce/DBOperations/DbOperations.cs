using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Models;
using Microsoft.EntityFrameworkCore;

namespace DBOperations
{
    public class DbOperations<TDbContext> : IDbOperations<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbOperations(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string sql, bool output = false, params object[] parameters)
        {
            var query = GenerateSqlQuery(sql, (SqlParameter[])parameters, output);
            Console.WriteLine(query);
            var result = await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
            return result;
        }

        public async Task<T> CreateAsync<T>(string sql, bool output = false, params object[] parameters)
        {
            var query = GenerateSqlQuery(sql, (SqlParameter[])parameters, output);
            var result = _dbContext.Database.SqlQueryRaw<T>(sql, parameters);
            //var result = _dbContext.Set<T>().FromSqlRaw(sql, parameters).AsEnumerable();
            return await result.FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(string sql, bool output = false, params object[] parameters)
        {
            var query = GenerateSqlQuery(sql, (SqlParameter[])parameters, output);
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public async Task<bool> DeleteAsync(string sql, bool output = false, params object[] parameters)
        {
            var result = await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            return result > 0;
        }

        public async Task<IList<T>> GetAllAsync<T>(string sql)
        {
            return await _dbContext.Database.SqlQueryRaw<T>(sql).ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync<T>(string sql, params object[] parameters)
        {
            return await _dbContext.Database.SqlQueryRaw<T>(sql, parameters).ToListAsync();
        }

        public async Task<T> GetAsync<T>(string sql, params object[] parameters)
        {
            return await _dbContext.Database.SqlQueryRaw<T>(sql, parameters).FirstAsync();
        }

        string GenerateSqlQuery(string sql, SqlParameter[] parameters, bool output)
        {
            var query = $"{sql} ";
            if (parameters != null && parameters.Length > 0)
            {
                query += string.Join(", ", parameters.Select(x => $"{x.ParameterName} = '{x.Value}'"));
            }
            return query;
        }
    }
}
