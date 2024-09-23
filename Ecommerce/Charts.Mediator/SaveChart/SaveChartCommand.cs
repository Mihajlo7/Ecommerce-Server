using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charts.Core.DTOs;
using Generic.Mediator;

namespace Charts.Mediator.SaveChart
{
    public record SaveChartCommand(ChartDTO ChartDTO): ICommand<ChartResponseDTO>;
    
}
