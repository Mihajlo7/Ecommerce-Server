using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DBOperations
{
    public static class RelationDBOperation
    {
        // Preparing query for operations
        private static string GenerateSqlQuery(string query, SqlParameter[] parameters,bool output)
        {
            var formatedQuery = $"{query} ";
            if (parameters != null && parameters.Length > 0)
            {
                formatedQuery += string.Join(", ", parameters.Select(x => $"{x.ParameterName} = '{x.Value}'"));
            }
            return formatedQuery;
        }
        // Getting entities by stored procedure
        public static async Task<IEnumerable<T>> GetEntitiesByStoredProcedure<T>
            (this DbContext dbContext,string query, SqlParameter[] parameters,bool output = false)
        {
            var dbQuery=GenerateSqlQuery(query, parameters, output);
            return  await dbContext.Database.SqlQueryRaw<T>(dbQuery,parameters).ToListAsync();
        }
        // Getting one entity by stored procedure
        public static async Task<T> GetEntityByStoredProcedure<T>
            (this DbContext dbContext, string query, SqlParameter[] parameters, bool output = false)
        {
            var dbQuery = GenerateSqlQuery(query, parameters, output);
            return await dbContext.Database.SqlQueryRaw<T>(dbQuery, parameters).FirstAsync();
        }
        // Insert, Update, Delete entity in stored procedure
        public static async Task<int> ChangeStateEntityByStoredProcedure
            (this DbContext dbContext, string query, SqlParameter[] parameters, bool output = false)
        {
            var dbQuery = GenerateSqlQuery(query, parameters, output);
            return await dbContext.Database.ExecuteSqlRawAsync(dbQuery,parameters);
        }

    }
}
