using Microsoft.EntityFrameworkCore;
using WorkersProject.Data;
using WorkersProject.Model.Entity;
using WorkersProject.Repositories.Interfaces;

namespace WorkersProject.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly ApplicationDbContext _context;
        public WorkerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Worker>> GetAllAsync()
        {
            return await _context.Workers
                .FromSqlRaw("EXEC sp_GetWorkers")
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<Worker> GetByIdAsync(int id)
        {
            return await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
        }
       
        public async Task AddWorkerAsync(Worker worker)
        {
            await _context.Workers.AddAsync(worker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkerAsync(int id, Worker worker)
        {
            if (id != worker.Id)
            {
                throw new ArgumentException("Worker ID mismatch");
            }

            _context.Entry(worker).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task DeleteWorkerAsync(int id)
        {
            var worker = await GetByIdAsync(id);
            if (worker != null)
            {
                worker.IsActive = false;
                _context.Workers.Update(worker);
                await _context.SaveChangesAsync();
            }
        }




    }
}
