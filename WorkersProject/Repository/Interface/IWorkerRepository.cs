using WorkersProject.Model.Entity;

namespace WorkersProject.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> GetAllAsync();
        Task<Worker> GetByIdAsync(int id);
        Task AddWorkerAsync(Worker worker);
        Task UpdateWorkerAsync(int id, Worker worker);
        Task DeleteWorkerAsync(int id);
    }
}
