using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkersProject.Data;
using WorkersProject.Model.Entity;
using WorkersProject.Repositories;

namespace WorkersProjects.Tests.IntegrationTests.Repositories
{
    public class WorkerRepositoryTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddWorker_ShouldSaveInDatabase()
        {
            var context = GetDbContext();
            var repository = new WorkerRepository(context);
            var worker = new Worker { FirstName = "QA", LastName = "Test", DocumentType = "DNI", DocumentNumber = "1", Gender = "M" };

            // Use the repository method that exists in the implementation
            await repository.AddWorkerAsync(worker);

            var count = await context.Workers.CountAsync();
            Assert.Equal(1, count);
        }
    }
}
