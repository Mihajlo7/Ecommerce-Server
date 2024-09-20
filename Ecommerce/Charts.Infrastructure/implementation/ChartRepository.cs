using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charts.Core.DTOs;
using DBOperations;
using Microsoft.Data.SqlClient;

namespace Charts.Infrastructure.implementation
{
    public class ChartRepository : IChartRepository
    {
        private readonly ChartDbContext _context;
        public ChartRepository(ChartDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteActiveChart(Guid personId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=personId}
            };
            var deletedChart = await _context.ChangeStateEntityByStoredProcedure
                (ChartDBOperations.DELETE_CHART, parameters);
            return deletedChart > 0;
        }

        public async Task<ChartRawDTO> GetActiveChart(Guid personId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=personId}
            };

            var activeChart = await _context.GetEntityByStoredProcedure<ChartRawDTO>
                (ChartDBOperations.GET_ACTIVE_CHART_BY_PERSON,parameters);
            return activeChart;
        }

        public async Task<int> UpdateChart(ChartRawDTO chart)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonId",SqlDbType.UniqueIdentifier){ Value=chart.PersonId },
                new SqlParameter("@Products",SqlDbType.VarChar){Value=chart.Products}
            };

            var updatedChart = await _context.ChangeStateEntityByStoredProcedure
                (ChartDBOperations.INSERT_CHART, parameters);

            return updatedChart;
        }
    }
}
