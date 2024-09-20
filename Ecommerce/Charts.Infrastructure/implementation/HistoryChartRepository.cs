using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts.Infrastructure.implementation
{
    public class HistoryChartRepository
    {
        private readonly ChartDbContext _context;

        public HistoryChartRepository(ChartDbContext context)
        {
            _context = context;
        }
    }
}
