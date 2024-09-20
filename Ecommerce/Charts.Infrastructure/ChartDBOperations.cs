using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Charts.Infrastructure
{
    public interface ChartDBOperations
    {
        public const string INSERT_CHART = "[dbo].[InsertOrReplaceChart]";
        public const string INSERT_HISTORY_CHART = "[dbo].[InsertHistoryChart]";
        public const string GET_ACTIVE_CHART_BY_PERSON = "[dbo].[GetActiveChartByPersonId]";
        public const string DELETE_CHART = "[dbo].[DeleteChart]";
    }
}
