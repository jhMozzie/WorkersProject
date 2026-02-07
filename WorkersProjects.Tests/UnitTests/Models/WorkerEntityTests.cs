using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WorkersProject.Model.Entity;

namespace WorkersProjects.Tests.UnitTests.Models
{
    public class WorkerEntityTests
    {
        [Fact]
        public void Worker_ValidData_ShouldNotHaveErrors()
        {
            var worker = new Worker
            {
                FirstName = "Joseph",
                LastName = "Flores",
                DocumentType = "DNI",
                DocumentNumber = "77777777",
                Gender = "M",
                BirthDate = new System.DateTime(2000, 1, 1)
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(worker);
            bool isValid = Validator.TryValidateObject(worker, context, results, true);

            Assert.True(isValid);
        }

        [Fact]
        public void Worker_InvalidGender_ShouldFail()
        {
            var worker = new Worker { Gender = "X" }; // Solo permite M o F

            var results = new List<ValidationResult>();
            var context = new ValidationContext(worker);
            Validator.TryValidateObject(worker, context, results, true);

            Assert.Contains(results, v => v.ErrorMessage.Contains("Genter must be M or F"));
        }
    }
}
