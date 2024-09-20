using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charts.Core.DTOs;

namespace Charts.Infrastructure
{
    public interface IChartRepository
    {
        public Task<ChartRawDTO> GetActiveChart(Guid personId);
        public Task<bool> DeleteActiveChart(Guid personId);
        public Task<int> UpdateChart(ChartRawDTO chart);
    }
}
