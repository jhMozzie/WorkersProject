using WorkersProject.Model.Requests.Worker;
using WorkersProject.Model.Responses.Worker;

namespace WorkersProject.Services.Interfaces
{
    public interface IWorkerService
    {
        Task<IEnumerable<WorkerResponse>> GetAllAsync();
        Task<WorkerResponse> GetByIdAsync(int id);
        Task<WorkerResponse> CreateWorkerAsync(CreateWorkerRequest request);
        Task<WorkerResponse> UpdateWorkerAsync(int id, UpdateWorkerRequest request);
        Task DeleteWorkerAsync(int id);

    }
}
