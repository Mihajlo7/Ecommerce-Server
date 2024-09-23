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
    public class HistoryChartRepository : IHistoryChartRepository
    {
        private readonly ChartDbContext _context;

        public HistoryChartRepository(ChartDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertHistoryChart(ChartHistoryDTO chartHistoryDTO)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonId",SqlDbType.UniqueIdentifier){Value=chartHistoryDTO.PersonId},
                new SqlParameter("@Products",SqlDbType.VarChar){Value=chartHistoryDTO.Products },
                new SqlParameter("@Total",SqlDbType.Decimal){Value=chartHistoryDTO.Total},
                new SqlParameter("@Status",SqlDbType.Int){Value=chartHistoryDTO.Status}
            };

            var insertedHistoryChart = await _context.ChangeStateEntityByStoredProcedure
                (ChartDBOperations.INSERT_HISTORY_CHART,parameters);
            return insertedHistoryChart;
        }
    }
}
