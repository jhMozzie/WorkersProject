using AutoMapper;
using WorkersProject.Model.Entity;
using WorkersProject.Model.Requests.Worker;
using WorkersProject.Model.Responses.Worker;
using WorkersProject.Repositories.Interfaces;
using WorkersProject.Services.Interfaces;

namespace WorkersProject.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _repository;
        private readonly IMapper _mapper;

        public WorkerService(IWorkerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkerResponse>> GetAllAsync()
        {
            var workers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<WorkerResponse>>(workers);
        }

        public async Task<WorkerResponse> GetByIdAsync(int id)
        {
            var worker = await _repository.GetByIdAsync(id);
            return _mapper.Map<WorkerResponse>(worker);
        }
       
        public async Task<WorkerResponse> CreateWorkerAsync(CreateWorkerRequest request)
        {
            var worker =  _mapper.Map<Worker>(request);
            worker.IsActive = true;
            await _repository.AddWorkerAsync(worker);
            return _mapper.Map<WorkerResponse>(worker);
        }

        public async Task<WorkerResponse> UpdateWorkerAsync(int id, UpdateWorkerRequest request)
        {
            var existingWorker = await _repository.GetByIdAsync(id);
            if (existingWorker == null) return null;
            
            _mapper.Map(request, existingWorker);
            await _repository.UpdateWorkerAsync(id, existingWorker);
            return _mapper.Map<WorkerResponse>(existingWorker);
        }

        public async Task DeleteWorkerAsync(int id)
        {
            await _repository.DeleteWorkerAsync(id);
        }

      

       
    }
}
