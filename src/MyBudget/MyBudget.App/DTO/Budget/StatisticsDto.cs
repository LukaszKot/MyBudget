using System.Collections.Generic;

namespace MyBudget.App.DTO.Budget
{
    public record StatisticsDto(IEnumerable<StatisticDto> Statistics);
}