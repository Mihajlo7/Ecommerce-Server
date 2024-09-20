using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charts.Core.DTOs;

namespace Charts.Infrastructure
{
    public interface IHistoryChartRepository
    {
        public Task<int> InsertHistoryChart(ChartHistoryDTO chartHistoryDTO);
    }
}
