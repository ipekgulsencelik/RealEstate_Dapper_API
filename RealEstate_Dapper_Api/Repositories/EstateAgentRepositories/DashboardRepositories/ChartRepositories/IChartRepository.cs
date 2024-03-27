using RealEstate_Dapper_API.DTOs.ChartDTOs;

namespace RealEstate_Dapper_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
        Task<List<ResultChartDTO>> Get5CityForChart();
    }
}