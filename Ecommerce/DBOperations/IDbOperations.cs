using System.Data.SqlClient;
using Generic.Models;
using Microsoft.EntityFrameworkCore;

namespace DBOperations
{
    public interface IDbOperations<TDbContext> where TDbContext: DbContext
    {
        Task UpdateObjectStoredProcedureWithOutResult(string procedureName,params SqlParameter[] inputParams);
        Task<Guid> UpdateObjectStoredProcedureWithResult(SqlParameter outputParam,string procedureName, params SqlParameter[] sqlParameters);
        Task<IEnumerable<TDTO>> GetObjectsByView<TDTO>(string viewName) where TDTO : GenericDTO;
        Task<IEnumerable<TDTO>> GetObjectsByProcedure<TDTO>(string procedureName) where TDTO : GenericDTO;
    }
}
