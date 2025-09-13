using Netrilo.Infrastructure.Common.Abstractions.Commands;
using Netrilo.Infrastructure.Common.Abstractions.Abstracts;

namespace Netrilo.Infrastructure.Common.Abstractions.UnitTests.Abstracts
{
    public class BaseEntitiesUnitTests
    {
        private class TestEntityClass<T> : BaseAuditableEntity<T>
        {
        }

        /// <summary>
        /// Checking the validation of generic type and date created by BaseEntity class
        /// </summary>
        [Fact]
        public void Check_New_Entity_Instance_Is_Valid()
        {
            // Arrange
            TestEntityClass<Guid> entity = new();

            // Assert
            Assert.True(entity.Id.GetType() == typeof(Guid));
            Assert.True(entity.Created.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Checking the validation of created and last modified date of an updated entity base class
        /// </summary>
        [Fact]
        public void Check_Updated_Entity_Class_Is_Valid()
        {
            // Arrange
            TestEntityClass<int> entity = new();


            // Assert

            Assert.True(entity.Id.GetType() == typeof(int));
            Assert.True(entity.Created.Date == DateTime.UtcNow.Date);
            Assert.False(entity.LastModified.HasValue);

            entity.Update();
            Assert.True(entity.LastModified.HasValue);
        }
    }
}