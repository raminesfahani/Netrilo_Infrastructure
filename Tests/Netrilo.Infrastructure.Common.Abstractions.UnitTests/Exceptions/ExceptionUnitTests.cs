using Infrastructure.Common.Abstractions.Dto;
using Infrastructure.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Abstractions.UnitTests.Exceptions
{
    public class ExceptionUnitTests
    {
        /// <summary>
        /// Checking the validation of created and last modified date of an updated entity base class
        /// </summary>
        [Fact]
        public void Check_Base_Exception_Response_Instance_Is_ValidAsync()
        {
            // Arrange
            var title = "Error";
            HttpStatusCode status = HttpStatusCode.Unauthorized;
            string[] errors = ["Unathorized error"];
            BaseExceptionResponse exception = new(title, string.Empty, (int)status, errors);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(title, exception.Title);
            Assert.Equal(errors, exception.Errors);
            Assert.Equal((int)status, exception.Status);
        }

        [Fact]
        public void Check_Custom_Application_Exception_Is_Valid()
        {
            // Arrange
            var title = "Error";
            HttpStatusCode status = HttpStatusCode.Unauthorized;
            string[] errors = ["Unathorized error"];
            CustomApplicationException exception = new(title, status, errors);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(title, exception.Message);
            Assert.Equal(errors, exception.Errors);
            Assert.Equal(status, exception.StatusCode);
        }

        [Fact]
        public void Check_Not_Found_Exception_Is_Valid()
        {
            // Arrange
            var title = "Error";
            NotFoundException exception = new(title);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(title, exception.Message);
        }

        [Fact]
        public void Check_Validation_Exception_Is_Valid()
        {
            // Arrange
            var title = "Error";
            ValidationException exception = new(title);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(title, exception.Message);
        }
    }
}
