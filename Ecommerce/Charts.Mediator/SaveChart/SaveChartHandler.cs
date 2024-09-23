using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charts.Core.DTOs;
using Charts.Core.Mappers;
using Charts.Infrastructure;
using Generic.Mediator;

namespace Charts.Mediator.SaveChart
{
    internal class SaveChartHandler : ICommandHandler<SaveChartCommand, ChartResponseDTO>
    {
        private readonly IChartRepository _chartRepository;
        private readonly IHistoryChartRepository _historyChartRepository;

        public SaveChartHandler(IChartRepository chartRepository,IHistoryChartRepository historyChartRepository)
        {
            _chartRepository = chartRepository;
            _historyChartRepository = historyChartRepository;
        }
        public async Task<ChartResponseDTO> Handle(SaveChartCommand request, CancellationToken cancellationToken)
        {
            // check if active chart exists
            var foundedActiveChart = await _chartRepository.GetActiveChart(request.ChartDTO.PersonId);

            // not exists, create new active chart
            if (foundedActiveChart == null)
            {
                var newChart = request.ChartDTO.toRawChart();
                var createdChart = await _chartRepository.UpdateChart(newChart);

                return new ChartResponseDTO
                {
                    Success = true,
                    Message = "Chart has been created"
                };
            }
            // if exists, update active chart and add new in history
            var updatedChart= request.ChartDTO.toRawChart();
            var updatedChartNum = await _chartRepository.UpdateChart(updatedChart);
            // background proccess
            _ = Task.Run(async () =>
            {
                request.ChartDTO.Status = ChartStatus.Updated;
                await _historyChartRepository.InsertHistoryChart(request.ChartDTO.toChartHistory())
                .ConfigureAwait(false);
            });

            var success = updatedChartNum > 0;
            return success ? new ChartResponseDTO { Success = true, Message = "Chart has been updated" }: 
                new ChartResponseDTO { Success = true, Message = "Error" };
        }
    }
}
