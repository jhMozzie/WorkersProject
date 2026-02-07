using System.Threading.Tasks;
using Moq;
using Xunit;
using WorkersProject.Model.Entity;
using WorkersProject.Model.Responses.Worker;
using WorkersProject.Repositories.Interfaces;
using WorkersProject.Services;
using AutoMapper;

namespace WorkersProjects.Tests.UnitTests.Services
{
    public class WorkerServiceTests
    {
        [Fact]
        public async Task GetWorkerById_ShouldReturnWorker_WhenExists()
        {
            // Arrange
            var mockRepo = new Mock<IWorkerRepository>();
            var mockMapper = new Mock<IMapper>();

            var expectedWorker = new Worker { Id = 1, FirstName = "Joseph" };
            mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(expectedWorker);

            mockMapper
                .Setup(m => m.Map<WorkerResponse>(It.IsAny<Worker>()))
                .Returns((Worker w) => new WorkerResponse
                {
                    Id = w.Id,
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                    DocumentType = w.DocumentType,
                    DocumentNumber = w.DocumentNumber,
                    Gender = w.Gender,
                    BirthDate = w.BirthDate,
                    Photo = w.Photo,
                    Address = w.Address
                });

            var service = new WorkerService(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Joseph", result.FirstName);
        }
    }
}
