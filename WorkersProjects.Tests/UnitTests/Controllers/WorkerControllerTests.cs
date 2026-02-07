using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkersProject.Controllers;
using WorkersProject.Model.Entity;
using WorkersProject.Model.Responses.Worker;
using WorkersProject.Services.Interfaces;

namespace WorkersProjects.Tests.UnitTests.Controllers
{
    public class WorkerControllerTests
    {
        private readonly Mock<IWorkerService> _mockService;
        private readonly WorkersController _controller;

        public WorkerControllerTests()
        {
            // Simulamos el servicio para no depender de la DB real
            _mockService = new Mock<IWorkerService>();
            _controller = new WorkersController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WithListOfWorkers()
        {
            // Arrange (Preparar)
            var workers = new List<WorkerResponse> { new WorkerResponse { Id = 1, FirstName = "Joseph" } };
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(workers);

            // Act (Actuar)
            var result = await _controller.GetAll();

            // Assert (Verificar)
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenWorkerDoesNotExist()
        {
            // Arrange
            _mockService.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((WorkerResponse)null);

            // Act
            var result = await _controller.GetById(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
