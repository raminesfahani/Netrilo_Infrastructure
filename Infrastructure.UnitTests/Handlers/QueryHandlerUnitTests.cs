using Infrastructure.Common.Abstractions.Events;
using Infrastructure.Common.Abstractions.Queries;
using MediatR;
using Moq;

namespace Infrastructure.Common.Abstractions.UnitTests.Handlers
{
    public class QueryHandlerUnitTests
    {
        // init
        class TestQuery : IQuery<TestResponse>
        {
            public Guid Id { get; init; }
        }
        class TestResponse
        {
            public Guid Id { get; init; }
        }

        class TestEvent : IEvent
        { }

        class TestQueryHandler(IMediator mediator) : IQueryHandler<TestQuery, TestResponse>
        {
            public IMediator Mediator { get; set; } = mediator;

            public async Task<TestResponse> Handle(TestQuery request, CancellationToken cancellationToken)
            {
                //do some stuff

                await Mediator.Publish(new TestEvent(), cancellationToken);
                return new TestResponse() { Id = request.Id };
            }
        }

        [Fact]
        public async Task Check_Binded_Query_Handler_Is_Valid()
        {
            //Arrange
            var mediator = new Mock<IMediator>();

            Guid id = Guid.NewGuid();
            TestQuery command = new() { Id = id };
            TestQueryHandler handler = new(mediator.Object);

            //Act
            TestResponse x = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.NotNull(x);
            Assert.Equal(id, x.Id);
        }
    }
}