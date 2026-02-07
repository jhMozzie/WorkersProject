using AutoMapper;
using WorkersProject.Model.Entity;
using WorkersProject.Model.Requests.Worker;
using WorkersProject.Model.Responses.Worker;

namespace WorkersProject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateWorkerRequest, Worker>();
            CreateMap<UpdateWorkerRequest, Worker>();

            CreateMap<Worker, WorkerResponse>();
        }
    }
}
