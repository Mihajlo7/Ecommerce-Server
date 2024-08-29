using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Models;
using Microsoft.EntityFrameworkCore;

namespace DBOperations
{
    public class DbOperations<TDbContext> : IDbOperations<TDbContext> where TDbContext:DbContext
    {
        private readonly TDbContext _dbContext;

        public DbOperations(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<TDTO>> GetObjectsByProcedure<TDTO>(string procedureName) where TDTO : GenericDTO
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDTO>> GetObjectsByView<TDTO>(string viewName) where TDTO : GenericDTO
        {
            throw new NotImplementedException();
        }

        public async Task UpdateObjectStoredProcedureWithOutResult(string procedureName, params SqlParameter[] inputParams)
        {
            var query=GenerateQuery(procedureName, inputParams);
            await _dbContext.Database.ExecuteSqlRawAsync(query);
        }

        public async Task<Guid> UpdateObjectStoredProcedureWithResult(SqlParameter outputParam,string procedureName, params SqlParameter[] sqlParameters)
        {
            var query = GenerateQuery(procedureName, sqlParameters);
            query = $"{query},@{outputParam.ParameterName} OUTPUT";
            
            await _dbContext.Database.ExecuteSqlRawAsync(query,sqlParameters,outputParam );
            return (Guid)outputParam.Value;
        }

        private string GenerateQuery(string procedureName,SqlParameter[] sqlParameters) 
        {
            return $"EXEC {procedureName} {string.Join(", ", sqlParameters.Select(s => $"@{s.ParameterName}"))}";
        }
    }
}
