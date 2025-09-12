using AutoMapper;
using Infrastructure.Common.Abstractions.Dto;
using Infrastructure.Common.Abstractions.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Abstractions.UnitTests.Mappings
{
    public class MappingUnitTests
    {
        class MappingUnitTestSourceClass
        {
            public Guid Id { get; set; }
        }

        class MappingUnitTestDestinationClass : Profile
        {
            public Guid Id { get; set; }
            public MappingUnitTestDestinationClass()
            {
                CreateMap<MappingUnitTestSourceClass, MappingUnitTestDestinationClass>().ReverseMap();
            }
        }

        private static IMapper InitTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            var provider = serviceCollection.BuildServiceProvider();

            return provider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Testing the AutoMapper configuration and mapping
        /// </summary>
        [Fact]
        public void Check_AutoMapper_Mapping_Config_Is_Valid()
        {
            // Arrange
            var mapper = InitTest();
            MappingUnitTestSourceClass source = new()
            {
                Id = Guid.NewGuid()
            };

            // Act
            var destination = mapper.Map<MappingUnitTestDestinationClass>(source);

            // Assert
            Assert.NotNull(destination);
            Assert.Equal(source.Id, destination.Id);
        }

        /// <summary>
        /// Testing the AutoMapper configuration and reverse mapping
        /// </summary>
        [Fact]
        public void Check_AutoMapper_Reverse_Mapping_Config_Is_Valid()
        {
            // Arrange
            var mapper = InitTest();
            MappingUnitTestDestinationClass source = new()
            {
                Id = Guid.NewGuid()
            };

            // Act
            var destination = mapper.Map<MappingUnitTestSourceClass>(source);

            // Assert
            Assert.NotNull(destination);
            Assert.Equal(source.Id, destination.Id);
        }
    }
}
